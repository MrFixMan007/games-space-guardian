using UnityEngine;

public class RotatingBackground : MonoBehaviour
{
    public float rotationSpeed = 5f; // Скорость вращения (градусы в секунду)

    void Update()
    {
        // Вращение вокруг центра
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}