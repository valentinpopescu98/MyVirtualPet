using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeController : MonoBehaviour
{
    public GameObject gamesMenu;
    public GameObject closeMenuBtn;

    public GameObject gameUI;
    public GameObject gameOver;

    public GameObject cancelBtn;
    public GameObject restartBtn;

    public Text[] boxesTextLst;
    public Text turnBoxText;

    Color32 sideColor = new Color32(0, 204, 204, 150);
    string sideMark = "X";
    int moveCount = 0;

    void Start()
    {
        StartCoroutine(ComputerMove());
    }

    public void StartGame()
    {
        gamesMenu.SetActive(false);
        closeMenuBtn.GetComponent<Image>().enabled = false;

        gameUI.SetActive(true);
        SetControllerReferences();

        for (int i = 0; i < boxesTextLst.Length; i++)
        {
            boxesTextLst[i].GetComponentInParent<Button>().interactable = true;
            boxesTextLst[i].text = "";
        }

        sideColor = new Color32(0, 204, 204, 150);
        sideMark = "X";
        turnBoxText.color = sideColor;
        turnBoxText.text = "X";
        moveCount = 0;
    }

    public void RestartGame()
    {
        StartGame();
        gameOver.SetActive(false);

        cancelBtn.SetActive(false);
        restartBtn.SetActive(false);
    }

    public void QuitGame()
    {
        RestartGame();

        gameUI.SetActive(false);
    }

    public string GetSideMark()
    {
        return sideMark;
    }

    public Color32 GetSideColor()
    {
        return sideColor;
    }

    public void EndTurn()
    {
        moveCount++;

        if (boxesTextLst[0].text == sideMark && boxesTextLst[1].text == sideMark && boxesTextLst[2].text == sideMark ||
            boxesTextLst[3].text == sideMark && boxesTextLst[4].text == sideMark && boxesTextLst[5].text == sideMark ||
            boxesTextLst[6].text == sideMark && boxesTextLst[7].text == sideMark && boxesTextLst[8].text == sideMark ||

            boxesTextLst[0].text == sideMark && boxesTextLst[3].text == sideMark && boxesTextLst[6].text == sideMark ||
            boxesTextLst[1].text == sideMark && boxesTextLst[4].text == sideMark && boxesTextLst[7].text == sideMark ||
            boxesTextLst[2].text == sideMark && boxesTextLst[5].text == sideMark && boxesTextLst[8].text == sideMark ||

            boxesTextLst[0].text == sideMark && boxesTextLst[4].text == sideMark && boxesTextLst[8].text == sideMark ||
            boxesTextLst[2].text == sideMark && boxesTextLst[4].text == sideMark && boxesTextLst[6].text == sideMark)
        {
            GameOver(sideMark);
        }
        else if (moveCount >= 9)
        {
            GameOver("N/A");
        }

        ChangeSides();
    }

    // Set references for all tic tac toe game controllers
    void SetControllerReferences()
    {
        for (int i = 0; i < boxesTextLst.Length; i++)
        {
            boxesTextLst[i].GetComponentInParent<Box>().SetControllerReference(this);
        }
    }

    void ChangeSides()
    {
        if (sideMark == "X")
        {
            sideColor = new Color32(255, 0, 102, 150);
            sideMark = "O";
        }
        else
        {
            sideColor = new Color32(0, 204, 204, 150);
            sideMark = "X";
        }

        turnBoxText.color = sideColor;
        turnBoxText.text = sideMark;
    }

    void GameOver(string winner)
    {
        for (int i = 0; i < boxesTextLst.Length; i++)
        {
            boxesTextLst[i].GetComponentInParent<Button>().interactable = false;
        }

        if (winner == "X")
        {
            SetGameOverText("YOU WIN!");

            GetComponent<ExperienceSystem>().crtXP++;
        }
        else if (winner == "O")
        {
            SetGameOverText("YOU LOSE!");
        }
        else
        {
            SetGameOverText("DRAW!");
        }

        cancelBtn.SetActive(true);
        restartBtn.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        gameOver.SetActive(true);
        gameOver.transform.GetChild(0).GetComponent<Text>().text = value;
    }

    IEnumerator ComputerMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (sideMark == "O")
            {
                int value = Random.Range(0, 8);
                if (boxesTextLst[value].GetComponentInParent<Button>().interactable == true)
                {
                    boxesTextLst[value].GetComponentInParent<Box>().SetBox();
                }
            }
        }
    }
}
