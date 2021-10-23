using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    Toggle toggleMove, toggleRotatation, toggleRescale;
    Image imageOnMove, imageOnRotation, imageOnRescale;
    TransformCharacter objectScript;

    void Start()
    {
        objectScript = GameObject.FindGameObjectWithTag("Character").GetComponent<TransformCharacter>();


        toggleMove = transform.parent.GetChild(0).GetComponent<Toggle>();
        imageOnMove = toggleMove.transform.GetChild(0).GetComponent<Image>();

        toggleRotatation = transform.parent.GetChild(1).GetComponent<Toggle>();
        imageOnRotation = toggleRotatation.transform.GetChild(0).GetComponent<Image>();

        toggleRescale = transform.parent.GetChild(2).GetComponent<Toggle>();
        imageOnRescale = toggleRescale.transform.GetChild(0).GetComponent<Image>();
    }

    public void HandleMove()
    {
        if (toggleMove.isOn)
        {
            objectScript.isRotated = false;
            toggleRotatation.isOn = false;

            objectScript.isRescaled = false;
            toggleRescale.isOn = false;


            objectScript.isMoved = true;
            imageOnMove.enabled = true;
            Debug.Log("Moved " + objectScript.isMoved);
        }
        else if (!toggleMove.isOn)
        {
            objectScript.isMoved = false;
            imageOnMove.enabled = false;
            Debug.Log("Moved " + objectScript.isMoved);
        }
    }

    public void HandleRotation()
    {
        if (toggleRotatation.isOn)
        {
            objectScript.isMoved = false;
            toggleMove.isOn = false;

            objectScript.isRescaled = false;
            toggleRescale.isOn = false;


            objectScript.isRotated = true;
            imageOnRotation.enabled = true;
            Debug.Log("Rotated " + objectScript.isRotated);
        }
        else if (!toggleRotatation.isOn)
        {
            objectScript.isRotated = false;
            imageOnRotation.enabled = false;
            Debug.Log("Rotated " + objectScript.isRotated);
        }
    }

    public void HandleRescale()
    {
        if (toggleRescale.isOn)
        {
            objectScript.isMoved = false;
            toggleMove.isOn = false;

            objectScript.isRotated = false;
            toggleRotatation.isOn = false;


            objectScript.isRescaled = true;
            imageOnRescale.enabled = true;
            Debug.Log("Rescaled " + objectScript.isRescaled);
        }
        else if (!toggleRescale.isOn)
        {
            objectScript.isRescaled = false;
            imageOnRescale.enabled = false;
            Debug.Log("Rescaled " + objectScript.isRescaled);
        }
    }
}
