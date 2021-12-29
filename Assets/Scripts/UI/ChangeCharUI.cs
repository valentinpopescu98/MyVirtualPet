using UnityEngine;
using UnityEngine.UI;

public class ChangeCharUI : MonoBehaviour
{
    public GameObject generalBtns;
    public GameObject charactersWrapper;
    public GameObject portrait;
    public GameObject cancelChangeChar;

    TransformsUI transformsUI_Script;
    ChangeChar changeCharScript;

    Transform changeCharLeftBtn;
    Transform changeCharRightBtn;

    void Start()
    {
        // Scripts
        transformsUI_Script = generalBtns.GetComponent<TransformsUI>();
        changeCharScript = charactersWrapper.GetComponent<ChangeChar>();

        // Set change character buttons
        changeCharLeftBtn = transform.GetChild(0);
        changeCharRightBtn = transform.GetChild(1);
    }

    void Update()
    {
        // Set portrait icon for the current character
        Transform portraitIcon = portrait.transform.GetChild(0).transform;

        for (int i = 0; i < portraitIcon.transform.childCount; i++)
        {
            portraitIcon.GetChild(i).GetComponent<Image>().enabled = false;
        }

        portraitIcon.GetChild((int)changeCharScript.activeChar).GetComponent<Image>().enabled = true;

        // Set portrait name for the current character (which is the only active character GameObject)
        Transform portraitBorder = portrait.transform.GetChild(1).transform;
        GameObject portraitName = portraitBorder.GetChild(1).gameObject;

        portraitName.GetComponent<Text>().text = GameObject.FindGameObjectWithTag("Character").name;

        // Make change character arrows transparent if the current character is first or last
        if ((int)changeCharScript.activeChar <= 0)
        {
            changeCharLeftBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }
        else if ((int)changeCharScript.activeChar >= System.Enum.GetValues(typeof(Characters)).Length - 1)
        {
            changeCharRightBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }
        else
        {
            changeCharLeftBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            changeCharRightBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    /* Opens the character change interface and hides UI buttons.
     * It also stops turns off any transforms in case they are activated.
     * Hides the UI buttons.
     */
    public void ActivateChangeChar()
    {
        transformsUI_Script.DeactivateMove();
        transformsUI_Script.DeactivateRotation();
        transformsUI_Script.DeactivateRescale();

        generalBtns.SetActive(false);

        changeCharLeftBtn.GetComponent<Image>().enabled = true;
        changeCharRightBtn.GetComponent<Image>().enabled = true;
        cancelChangeChar.SetActive(true);
    }

    // Exits character change interface. Shows the UI buttons again.
    public void DeactivateChangeChar()
    {
        generalBtns.SetActive(true);

        changeCharLeftBtn.GetComponent<Image>().enabled = false;
        changeCharRightBtn.GetComponent<Image>().enabled = false;
        cancelChangeChar.SetActive(false);
    }
}
