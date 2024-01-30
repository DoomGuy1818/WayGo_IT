using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public Button playPauseButton;
    public Button forwardButton;
    public Button backwardButton;
    public Button speedButton; // кнопка для изменения скорости воспроизведения
    public Text currentTimeText; // текстовое поле для отображения текущего времени
    public Text totalTimeText; // текстовое поле для отображения общего времени
    public Slider progressSlider; // ползунок для отображения прогресса воспроизведения

    public Sprite playSprite;
    public Sprite pauseSprite;

    private Image buttonImage;
    private float[] speeds = { 1.0f, 1.5f, 2.0f }; // массив доступных скоростей
    private int currentSpeedIndex = 0; // текущий индекс скорости

    void Start()
    {
        playPauseButton.onClick.AddListener(TogglePlayPause);
        forwardButton.onClick.AddListener(Forward);
        backwardButton.onClick.AddListener(Backward);
        speedButton.onClick.AddListener(ChangeSpeed);
        buttonImage = playPauseButton.GetComponent<Image>();

        // Привязываем ползунок к аудио
        progressSlider.minValue = 0f;
        progressSlider.maxValue = audioSource.clip.length;

        UpdateUI();
        UpdateSpeedButtonText();
    }

    void Update()
    {
        UpdateUI();
    }

    void TogglePlayPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            if (playSprite != null)
            {
                buttonImage.sprite = playSprite;
            }
        }
        else
        {
            audioSource.Play();
            if (pauseSprite != null)
            {
                buttonImage.sprite = pauseSprite;
            }
        }
    }

    void Forward()
    {
        if (audioSource.isPlaying)
        {
            audioSource.time += 10f;
        }
    }

    void Backward()
    {
        if (audioSource.isPlaying)
        {
            audioSource.time -= 10f;
        }
    }

    void ChangeSpeed()
    {
        currentSpeedIndex = (currentSpeedIndex + 1) % speeds.Length; // Переключаем скорость

        if (currentSpeedIndex < speeds.Length)
        {
            audioSource.pitch = speeds[currentSpeedIndex]; // Устанавливаем новую скорость
            UpdateSpeedButtonText();
        }
    }

    void UpdateUI()
    {
        if (audioSource != null && currentTimeText != null && totalTimeText != null && progressSlider != null)
        {
            currentTimeText.text = FormatTime(audioSource.time);
            totalTimeText.text = FormatTime(audioSource.clip.length);

            // Обновляем значение ползунка в соответствии с текущим временем воспроизведения
            progressSlider.value = audioSource.time;
        }
    }

    void UpdateSpeedButtonText()
    {
        if (speedButton != null)
        {
            float currentSpeed = speeds[currentSpeedIndex];
            speedButton.GetComponentInChildren<Text>().text = "x" + currentSpeed.ToString("F1").TrimEnd('0').TrimEnd(','); 
        }
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
