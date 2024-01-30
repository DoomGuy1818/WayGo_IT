using UnityEngine;
using System.Collections;

public class SwipePanelSwitcher : MonoBehaviour
{
    public RectTransform upperPanel;
    public RectTransform lowerPanel;
    public Animator objectAnimator;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private float swipeDistance = 50f;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;
                float swipeMagnitude = (touchEndPos - touchStartPos).magnitude;

                if (swipeMagnitude > swipeDistance)
                {
                    if (touchEndPos.y > touchStartPos.y) // Swipe up
                    {
                        StartCoroutine(PlayAndClose(lowerPanel));
                        OpenPanel(upperPanel);
                    }
                    else if (touchEndPos.y < touchStartPos.y) // Swipe down
                    {
                        StartCoroutine(PlayAndClose(upperPanel));
                        OpenPanel(lowerPanel);
                    }
                }
            }
        }
    }

    void OpenPanel(RectTransform panel)
    {
        if (panel != null)
        {
            panel.gameObject.SetActive(true);
        }
    }

    void ClosePanel(RectTransform panel)
    {
        if (panel != null)
        {
            panel.gameObject.SetActive(false);
        }
    }

    IEnumerator PlayAndClose(RectTransform panel)
    {
        if (panel != null)
        {
            objectAnimator.SetTrigger("PanelClose");
            yield return new WaitForSeconds(objectAnimator.GetCurrentAnimatorStateInfo(0).length);
            ClosePanel(panel);
        }
    }
}
