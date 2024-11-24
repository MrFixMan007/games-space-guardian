using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Скорость движения

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Двигаем объект вниз с постоянной скоростью
        if (rb != null)
        {
            Vector2 newPosition = rb.position + Vector2.down * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }
}