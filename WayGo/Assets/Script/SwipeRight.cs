using UnityEngine;

public class SwipeRightCanvasSwitcher : MonoBehaviour
{
    public Canvas canvasToOpen;
    public Canvas canvasToClose;
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

                if (swipeMagnitude > swipeDistance && touchEndPos.x > touchStartPos.x) // Swipe right
                {
                    StartCoroutine(PlayAndCloseThenOpen());
                }
            }
        }
    }

    System.Collections.IEnumerator PlayAndCloseThenOpen()
    {
        if (objectAnimator != null)
        {
            objectAnimator.SetTrigger("MenuClose");
            yield return new WaitForSeconds(objectAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        if (canvasToClose != null)
        {
            canvasToClose.gameObject.SetActive(false);
        }

        if (canvasToOpen != null)
        {
            canvasToOpen.gameObject.SetActive(true);
        }
    }
}
