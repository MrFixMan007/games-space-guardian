using UnityEngine;

public class Dispawner : MonoBehaviour, IEntity
{
    public EntityType EntityType => EntityType.Dispawner;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}