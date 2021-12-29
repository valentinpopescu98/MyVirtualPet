using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public Button boxBtn;
    public Text boxText;

    TicTacToeController controller;

    public void SetBox()
    {
        boxText.color = controller.GetSideColor();
        boxText.text = controller.GetSideMark();
        boxBtn.interactable = false;
        controller.EndTurn();
    }

    // Set reference to controller for one box
    public void SetControllerReference(TicTacToeController controller)
    {
        this.controller = controller;
    }
}
