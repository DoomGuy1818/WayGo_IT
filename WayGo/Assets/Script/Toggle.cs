using UnityEngine;
using UnityEngine.UI;

public class ToggleSync : MonoBehaviour
{
    public Toggle firstToggle;
    public Toggle secondToggle;

    void Start()
    {
        if (firstToggle != null && secondToggle != null)
        {
            firstToggle.onValueChanged.AddListener(OnFirstToggleValueChanged);
            secondToggle.onValueChanged.AddListener(OnSecondToggleValueChanged);
        }
    }

    // Обработчик изменения состояния первой кнопки Toggle
    void OnFirstToggleValueChanged(bool newValue)
    {
        // Установить состояние второй кнопки Toggle таким же, как у первой
        secondToggle.isOn = newValue;
    }

    // Обработчик изменения состояния второй кнопки Toggle
    void OnSecondToggleValueChanged(bool newValue)
    {
        // Установить состояние первой кнопки Toggle таким же, как у второй
        firstToggle.isOn = newValue;
    }
}
