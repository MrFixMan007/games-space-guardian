using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Синглтон для доступа из других скриптов
    private int score = 0; // Счётчик уничтоженных кораблей
    public TextMeshProUGUI scoreText; // Ссылка на текстовый UI-объект

    private void Awake()
    {
        // Реализуем синглтон
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText(); // Инициализация текста
    }

    public void AddScore(int amount)
    {
        score += amount; // Увеличиваем счёт
        UpdateScoreText(); // Обновляем отображение
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Устанавливаем текст
    }
}