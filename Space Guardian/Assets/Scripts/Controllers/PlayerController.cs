using UnityEngine;

public class PlayerController : MonoBehaviour, IEntity
{
    public EntityType entityType => EntityType.Player;

    public float speed = 5f;
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float playerWidth;
    private Shooter shooter;

    void Start()
    {
        mainCamera = Camera.main;

        // Рассчитываем границы экрана в мировых координатах
        if (mainCamera != null)
            screenBounds =
                mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                    mainCamera.transform.position.z));

        playerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        shooter = GetComponent<Shooter>();
    }

    void FixedUpdate()
    {
        // Управление движением игрока
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);

        // Ограничение позиции игрока в пределах экрана
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenBounds.x + playerWidth, screenBounds.x - playerWidth);
        transform.position = clampedPosition;

        shooter.Shoot(Vector2.up);
    }

    public void OnPlayerDeath()
    {
        Destroy(gameObject);
        FindObjectOfType<PauseMenuController>().ShowOnPlayerDeath();
    }
}