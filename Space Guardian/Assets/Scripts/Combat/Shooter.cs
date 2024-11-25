using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    [SerializeField] private EntityType entityType;

    public GameObject bulletPrefab; // Префаб пули
    public Transform spawnPoint1; // Первая точка спавна пули
    public Transform spawnPoint2; // Вторая точка спавна пули

    public float fireRate = 0.5f; // Скорость стрельбы (в секундах между выстрелами)
    public float bulletSpeed = 10f; // Скорость пули

    private bool canShoot; // Флаг для контроля стрельбы

    [Header("Audio Settings")] public AudioClip shootSound; // Звук стрельбы
    private AudioSource audioSource; // Источник звука

    void Start()
    {
        // Получаем AudioSource на объекте
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource не найден! Добавьте его на объект.");
        }
        StartCoroutine(Reload());
    }

    // Метод для стрельбы
    public void Shoot(Vector2 direction)
    {
        if (!canShoot) return;

        canShoot = false;

        // Создаём пулю из первой точки спавна
        GameObject bullet1 = Instantiate(bulletPrefab, spawnPoint1.position, Quaternion.identity);
        InitializeBullet(bullet1, direction, bulletSpeed);

        // Создаём пулю из второй точки спавна
        GameObject bullet2 = Instantiate(bulletPrefab, spawnPoint2.position, Quaternion.identity);
        InitializeBullet(bullet2, direction, bulletSpeed);

        // Проигрываем звук стрельбы
        PlayShootSound();

        // Запускаем корутину для задержки между выстрелами
        StartCoroutine(Reload());
    }

    // Инициализация пули
    private void InitializeBullet(GameObject bullet, Vector2 direction, float speed)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.Initialize(direction, speed, entityType);
            bullet.SetActive(false);
        }

        StartCoroutine(EnableBulletAfterDelay(bullet));
    }

    // Корутину для включения пули
    private IEnumerator EnableBulletAfterDelay(GameObject bullet)
    {
        yield return new WaitForSeconds(0.1f);
        bullet.SetActive(true);
    }

    // Корутину для задержки между выстрелами
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    // Метод для воспроизведения звука стрельбы
    private void PlayShootSound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}