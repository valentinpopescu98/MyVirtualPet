using UnityEngine;

public class TransformChar : MonoBehaviour
{
    public float multiplier = 5f;

    [HideInInspector]
    public bool moveBtnClicked = false, rotateBtnClicked = false, rescaleBtnClicked = false;

    void Update()
    {
        // Only transform when you glide your finger
        if (moveBtnClicked)
        {
            if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved)
            {
                Move();
            }
        }
        // Only transform when you glide your finger
        if (rotateBtnClicked)
        {
            if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved)
            {
                Rotate();
            }
        }
        // Only transform when you glide your fingers
        if (rescaleBtnClicked)
        {
            if (Input.touchCount == 2 && (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved))
            {
                Rescale();
            }
        }
    }

    // Translate on X and Y axis on world coords
    private void Move()
    {
        Touch screenTouch = Input.GetTouch(0);
        transform.Translate(new Vector3(
                screenTouch.deltaPosition.x * Time.deltaTime / multiplier,
                0f,
                screenTouch.deltaPosition.y * Time.deltaTime / multiplier), Space.World);
    }

    // Rotate on Y axis
    private void Rotate()
    {
        Touch screenTouch = Input.GetTouch(0);
        transform.Rotate(0f, -screenTouch.deltaPosition.x * Time.deltaTime * multiplier * 2, 0f);
    }

    // Rescale
    private void Rescale()
    {
        Touch screenTouch1 = Input.GetTouch(0);
        Touch screenTouch2 = Input.GetTouch(1);

        Vector2 curDistance = screenTouch1.position - screenTouch2.position;
        Vector2 prevDistance = (screenTouch1.position - screenTouch1.deltaPosition) - (screenTouch2.position - screenTouch2.deltaPosition);
        float touchDelta = curDistance.magnitude - prevDistance.magnitude;

        if (touchDelta > 1f)
        {
            transform.localScale += Vector3.one * Time.deltaTime * multiplier;
        }
        else
        {
            if (transform.localScale.x > 0.1f || transform.localScale.y > 0.1f || transform.localScale.z > 0.1f)
            {
                transform.localScale -= Vector3.one * Time.deltaTime * multiplier;
            }
        }
    }
}
