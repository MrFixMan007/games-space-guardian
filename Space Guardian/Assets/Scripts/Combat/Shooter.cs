using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    [SerializeField] private EntityType entityType;

    public GameObject bulletPrefab; // Префаб пули
    public Transform spawnPoint1; // Первая точка спавна пули
    public Transform spawnPoint2; // Вторая точка спавна пули

    public float fireRate = 0.5f; // Скорость стрельбы (в секундах между выстрелами)

    private bool canShoot = true; // Флаг, чтобы предотвратить слишком быстрые выстрелы
    public float bulletSpeed = 10f;

    // Метод для стрельбы
    public void Shoot(Vector2 direction)
    {
        if (!canShoot) return; // Если стрельба невозможна, выходим

        canShoot = false; // Запрещаем стрельбу до следующего времени

        // Создаём пулю из первой точки спавна
        GameObject bullet1 = Instantiate(bulletPrefab, spawnPoint1.position, Quaternion.identity);
        InitializeBullet(bullet1, direction, bulletSpeed);

        // Создаём пулю из второй точки спавна
        GameObject bullet2 = Instantiate(bulletPrefab, spawnPoint2.position, Quaternion.identity);
        InitializeBullet(bullet2, direction, bulletSpeed);

        // Запускаем корутину для контроля времени между выстрелами
        StartCoroutine(Reload());
    }

    // Инициализация пули
    private void InitializeBullet(GameObject bullet, Vector2 direction, float speed)
    {
        // Направляем пулю
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Инициализируем движение пули
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.Initialize(direction, speed, entityType);
            bullet.SetActive(false); // Делаем пулю невидимой сразу
        }

        // Запускаем корутину для того, чтобы пуля стала видимой после задержки
        StartCoroutine(EnableBulletAfterDelay(bullet));
    }

    // Корутину для перезарядки (задержка между выстрелами)
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(fireRate); // Ожидаем интервал между выстрелами
        canShoot = true; // Разрешаем следующий выстрел
    }

    // Корутину для включения пули через время
    private IEnumerator EnableBulletAfterDelay(GameObject bullet)
    {
        // Делаем паузу, чтобы пуля развернулась (например, 0.1 сек)
        yield return new WaitForSeconds(0.1f);

        // Делаем пулю видимой
        bullet.SetActive(true);
    }
}