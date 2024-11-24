using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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
}