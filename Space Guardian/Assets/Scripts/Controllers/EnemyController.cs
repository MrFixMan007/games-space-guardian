using UnityEngine;

public class EnemyController : MonoBehaviour, IEntity
{
    public EntityType EntityType => EntityType.Enemy;

    private Shooter shooter;
    private bool deathing;

    void Start()
    {
        shooter = GetComponent<Shooter>();
    }

    void FixedUpdate()
    {
        if (Random.value > 0.8f)
        {
            shooter.Shoot(Vector2.down);
        }
    }

    public void Destroy()
    {
        if (!deathing)
        {
            ScoreManager.Instance.AddScore(1);
            Destroy(gameObject);
            deathing = true;
        }
    }
}