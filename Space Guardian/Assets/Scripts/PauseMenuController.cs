using UnityEngine;
using UnityEngine.SceneManagement; // Для смены сцен
using UnityEngine.UI; // Для работы с UI

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI; // Ссылка на Canvas с меню паузы
    public GameObject deathMenuUI; // Ссылка на Canvas с меню смерти
    public Slider volumeSlider; // Ссылка на ползунок громкости
    private bool isPaused = false; // Флаг паузы

    void Start()
    {
        // Изначально меню паузы скрыто
        pauseMenuUI.SetActive(false);
        deathMenuUI.SetActive(false);

        // Устанавливаем ползунок громкости на текущий уровень
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void Update()
    {
        // Проверяем нажатие Esc для открытия/закрытия меню паузы
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Останавливаем время (пауза игры)
        pauseMenuUI.SetActive(true); // Показываем меню
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Возвращаем нормальное время
        pauseMenuUI.SetActive(false); // Скрываем меню
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Снимаем паузу
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезагружаем текущую сцену
    }

    public void ExitGame()
    {
        Application.Quit(); // Выход из игры
        Debug.Log("Game Exited!"); // Лог для отладки
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Изменяем громкость
    }

    public void ShowOnPlayerDeath()
    {
        isPaused = true;
        Time.timeScale = 0f; // Останавливаем время (пауза игры)
        deathMenuUI.SetActive(true); // Показываем меню
    }
}