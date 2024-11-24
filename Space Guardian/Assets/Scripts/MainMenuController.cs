using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Slider volumeSlider; // Ссылка на ползунок громкости

    void Start()
    {
        // Установить ползунок на текущую громкость
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void StartGame()
    {
        // Замените "GameScene" на имя вашей игровой сцены
        SceneManager.LoadScene("Scenes/Battle");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Игра завершена!"); // Не сработает в редакторе Unity
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}