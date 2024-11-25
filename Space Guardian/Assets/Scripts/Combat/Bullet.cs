using UnityEngine;

public class Bullet : MonoBehaviour, IEntity
{
    public EntityType entityType;
    public EntityType EntityType => entityType;
    public GameObject explosionPrefab;

    private Vector2 direction; // Направление полёта
    private float speed; // Скорость полёта

    public float lifetime = 5f; // Время жизни пули в секундах

    public void Initialize(Vector2 dir, float spd, EntityType type)
    {
        direction = dir.normalized;
        speed = spd;
        entityType = type;

        // Уничтожить пулю через lifetime секунд
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Двигаем пулю
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject targetObject = collision.gameObject;
        // Получаем объект, с которым произошёл контакт
        EntityType collidedEntity = targetObject.GetComponent<IEntity>().EntityType;

        // Уничтожаем пулю при столкновении
        if (entityType != collidedEntity)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            if (collidedEntity == EntityType.Player)
            {
                targetObject.GetComponent<PlayerController>().OnPlayerDeath();
                Destroy(gameObject);
            }
            else if (collidedEntity != EntityType.Dispawner)
            {
                Destroy(targetObject);
                Destroy(gameObject);
            }
        }
    }
}