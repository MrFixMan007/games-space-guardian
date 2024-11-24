using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour
{
    private Animator animator;
    [Header("Audio Settings")] public AudioClip shootSound; // Звук стрельбы
    private AudioSource audioSource; // Источник звука

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayShootSound();
    }

    void Update()
    {
        // Проверяем, завершена ли анимация
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Explosion") ||
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            return; // Анимация еще не завершена
        }

        // Если анимация завершена, уничтожаем объект
        Destroy(gameObject);
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