using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelSwitch : MonoBehaviour, IPointerDownHandler
{
    public GameObject initialPanel; // Начальная панель
    public GameObject targetPanel; // Панель, на которую вы хотите переключиться

    private bool isTargetPanelActive = false;



    public void OnPointerDown(PointerEventData eventData)
    {
        if (isTargetPanelActive)
        {
            // Если целевая панель активна, переключаемся на начальную
            initialPanel.SetActive(true);
            targetPanel.SetActive(false);
        }
        else
        {
            // Если начальная панель активна, переключаемся на целевую
            initialPanel.SetActive(false);
            targetPanel.SetActive(true);
        }

        // Инвертируем состояние переменной isTargetPanelActive
        isTargetPanelActive = !isTargetPanelActive;
    }
}
