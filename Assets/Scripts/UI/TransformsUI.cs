using UnityEngine;
using UnityEngine.UI;

public class TransformsUI : MonoBehaviour
{
    public GameObject gameController;
    public GameObject moveBtn, rotateBtn, rescaleBtn;
    public Sprite movenSpriteOff, rotateSpriteOff, rescaleSpriteOff;
    public Sprite moveSpriteOn, rotateSpriteOn, rescaleSpriteOn;

    TransformChar transformsScript;
    Toggle toggleMove, toggleRotatation, toggleRescale;

    void Start()
    {
        // Scripts
        transformsScript = gameController.GetComponent<TransformChar>();

        // Toggle components of the buttons
        toggleMove = moveBtn.GetComponent<Toggle>();
        toggleRotatation = rotateBtn.GetComponent<Toggle>();
        toggleRescale = rescaleBtn.GetComponent<Toggle>();
    }

    // Triggers when move toggle changes its state
    public void ToggleMove()
    {
        if (toggleMove.isOn)
        {
            DeactivateRotation();
            DeactivateRescale();

            ActivateMove();
        }
        else
        {
            DeactivateMove();
        }
    }

    // Triggers when rotation toggle changes its state
    public void ToggleRotation()
    {
        if (toggleRotatation.isOn)
        {
            DeactivateMove();
            DeactivateRescale();

            ActivateRotation();
        }
        else
        {
            DeactivateRotation();
        }
    }

    // Triggers when rescale toggle changes its state
    public void ToggleRescale()
    {
        if (toggleRescale.isOn)
        {
            DeactivateMove();
            DeactivateRotation();

            ActivateRescale();
        }
        else
        {
            DeactivateRescale();
        }
    }

    // Activates the state so that translation is possible
    private void ActivateMove()
    {
        transformsScript.moveBtnClicked = true;
        moveBtn.GetComponent<Image>().sprite = moveSpriteOn;
    }

    // Deactivates the state so that translation is possible
    public void DeactivateMove()
    {
        transformsScript.moveBtnClicked = false;
        moveBtn.GetComponent<Image>().sprite = movenSpriteOff;
        toggleMove.isOn = false;
    }

    // Activates the state so that rotation is possible
    private void ActivateRotation()
    {
        transformsScript.rotateBtnClicked = true;
        rotateBtn.GetComponent<Image>().sprite = rotateSpriteOn;
    }

    // Deactivates the state so that translating is possible
    public void DeactivateRotation()
    {
        transformsScript.rotateBtnClicked = false;
        rotateBtn.GetComponent<Image>().sprite = rotateSpriteOff;
        toggleRotatation.isOn = false;
    }

    // Activates the state so that rescale is possible
    private void ActivateRescale()
    {
        transformsScript.rescaleBtnClicked = true;
        rescaleBtn.GetComponent<Image>().sprite = rescaleSpriteOn;
    }

    // Deactivates the state so that rescale is possible
    public void DeactivateRescale()
    {
        transformsScript.rescaleBtnClicked = false;
        rescaleBtn.GetComponent<Image>().sprite = rescaleSpriteOff;
        toggleRescale.isOn = false;
    }
}
