using UnityEngine;

public class EnemyController : MonoBehaviour, IEntity
{
    public EntityType entityType => EntityType.Enemy;

    private Shooter shooter;

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

}