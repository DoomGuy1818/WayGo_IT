using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelSwitcher : MonoBehaviour
{
    public Button switchButton;
    public GameObject panelToClose;
    public GameObject panelToOpen;
    public Animator panelAnimator;

    void Start()
    {
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(AnimateAndSwitch);
        }
    }

    void AnimateAndSwitch()
    {
        if (panelAnimator != null)
        {
            StartCoroutine(PlayAnimationThenSwitch());
        }
        else
        {
            SwitchPanels();
        }
    }

    IEnumerator PlayAnimationThenSwitch()
    {
        panelAnimator.SetTrigger("PointClose");

        yield return new WaitForSeconds(panelAnimator.GetCurrentAnimatorStateInfo(0).length);

        SwitchPanels();
    }

    void SwitchPanels()
    {
        if (panelToClose != null)
        {
            panelToClose.SetActive(false);
        }

        if (panelToOpen != null)
        {
            panelToOpen.SetActive(true);
        }
    }
}

