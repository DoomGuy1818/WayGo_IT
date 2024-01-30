using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CanvasSwitcher : MonoBehaviour
{
    public Button switchButton;
    public Canvas canvasToClose;
    public Canvas canvasToOpen;
    public Animator canvasAnimator;

    void Start()
    {
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(AnimateAndSwitch);
        }
    }

    void AnimateAndSwitch()
    {
        // Если есть аниматор, проиграйте анимацию
        if (canvasAnimator != null)
        {
            StartCoroutine(PlayAnimationThenSwitch());
        }
        else
        {
            // Если аниматора нет, просто переключите канвасы
            SwitchCanvases();
        }
    }

    IEnumerator PlayAnimationThenSwitch()
    {
        // Включите триггер анимации
        canvasAnimator.SetTrigger("MenuClose");

        // Подождите, пока анимация завершится
        yield return new WaitForSeconds(canvasAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Вызовите метод для закрытия и открытия канвасов
        SwitchCanvases();
    }

    void SwitchCanvases()
    {
        // Закройте один канвас
        if (canvasToClose != null)
        {
            canvasToClose.gameObject.SetActive(false);
        }

        // Откройте другой канвас
        if (canvasToOpen != null)
        {
            canvasToOpen.gameObject.SetActive(true);
        }
    }
}