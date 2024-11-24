using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Скорость движения

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }
}