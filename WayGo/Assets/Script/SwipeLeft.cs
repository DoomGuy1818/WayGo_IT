using UnityEngine;

public class SwipeLeftCanvasSwitcher : MonoBehaviour
{
    public Canvas canvasToOpen;
    public Canvas canvasToClose;

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

                if (swipeMagnitude > swipeDistance && touchEndPos.x < touchStartPos.x) // Swipe left
                {
                    OpenAndCloseCanvases();
                }
            }
        }
    }

    void OpenAndCloseCanvases()
    {
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
