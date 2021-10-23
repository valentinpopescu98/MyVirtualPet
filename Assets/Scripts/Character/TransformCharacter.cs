using UnityEngine;

public class TransformCharacter : MonoBehaviour
{
    [HideInInspector] public bool isOneActive = false, isTwoActive = false;
    [HideInInspector] public bool isMoved = false, isRotated = false, isRescaled = false;
    float multiplier = 5f;
    float? distance1 = null;
    //Color activeColor = new Color();

    void Update()
    {
        if (isOneActive)
        {
            //activeColor = Color.red;

            if (isMoved && Input.touchCount == 1)
            {
                Touch screenTouch = Input.GetTouch(0);

                if (screenTouch.phase == TouchPhase.Moved)
                {
                    transform.Translate(new Vector3(
                        -screenTouch.deltaPosition.x * Time.deltaTime / multiplier,
                        0f,
                        -screenTouch.deltaPosition.y * Time.deltaTime / multiplier));
                }

                if (screenTouch.phase == TouchPhase.Ended)
                {
                    isOneActive = false;
                }
            }

            if (isRotated && Input.touchCount == 1)
            {
                Touch screenTouch = Input.GetTouch(0);

                if (screenTouch.phase == TouchPhase.Moved)
                {
                    transform.Rotate(0f, -screenTouch.deltaPosition.x * Time.deltaTime * multiplier * 2, 0f);
                }

                if (screenTouch.phase == TouchPhase.Ended)
                {
                    isOneActive = false;
                }
            }
        }
        if (isTwoActive)
        {
            if (isRescaled && Input.touchCount == 2)
            {
                Touch screenTouch1 = Input.GetTouch(0);
                Touch screenTouch2 = Input.GetTouch(1);

                if (distance1 == null)
                {
                    distance1 = Vector2.Distance(screenTouch1.position, screenTouch2.position);
                }

                if (screenTouch1.phase == TouchPhase.Moved && screenTouch2.phase == TouchPhase.Moved)
                {
                    float distance2 = Vector2.Distance(screenTouch1.position, screenTouch2.position);

                    if (distance2 > distance1)
                    {
                        transform.localScale += new Vector3(1f, 1f, 1f) * Time.deltaTime * multiplier;
                    }
                    else
                    {
                        if (transform.localScale.x < 0.1f || transform.localScale.y < 0.1f || transform.localScale.z < 0.1f)
                        {
                            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        }

                        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime * multiplier;
                    }
                }

                if (screenTouch1.phase == TouchPhase.Ended && screenTouch2.phase == TouchPhase.Ended)
                {
                    distance1 = null;
                    isTwoActive = false;
                }
            }
        }
        else
        {
            //activeColor = Color.white;
        }

        //GetComponent<MeshRenderer>().material.color = activeColor;
    }
}
