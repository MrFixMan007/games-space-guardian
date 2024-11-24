using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction; // Направление полёта
    private float speed; // Скорость полёта

    public float lifetime = 5f; // Время жизни пули в секундах

    public void Initialize(Vector2 dir, float spd)
    {
        direction = dir.normalized;
        speed = spd;

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
        // Уничтожаем пулю при столкновении
        Destroy(gameObject);
    }
}