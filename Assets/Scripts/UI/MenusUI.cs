using UnityEngine;
using UnityEngine.UI;

public class MenusUI : MonoBehaviour
{
    public GameObject generalBtns;
    public GameObject closeMenuBtn;
    public GameObject foodInventory, gamesMenu, animationsMenu;

    TransformsUI transformsUI_Script;

    void Start()
    {
        // Scripts
        transformsUI_Script = generalBtns.GetComponent<TransformsUI>();
    }

    /* Opens the food inventory and hides UI buttons.
     * It also stops turns off any transforms in case they are activated.
     * Hides the UI buttons.
     */
    public void ActivateFeed()
    {
        transformsUI_Script.DeactivateMove();
        transformsUI_Script.DeactivateRotation();
        transformsUI_Script.DeactivateRescale();

        generalBtns.SetActive(false);

        foodInventory.SetActive(true);
        closeMenuBtn.GetComponent<Image>().enabled = true;
    }

    // Exits food inventory. Shows the UI buttons again.
    public void DeactivateFeed()
    {
        generalBtns.SetActive(true);

        foodInventory.SetActive(false);
        closeMenuBtn.GetComponent<Image>().enabled = false;
    }

    /* Opens the food inventory and hides UI buttons.
     * It also stops turns off any transforms in case they are activated.
     * Hides the UI buttons.
     */
    public void ActivatePlay()
    {
        transformsUI_Script.DeactivateMove();
        transformsUI_Script.DeactivateRotation();
        transformsUI_Script.DeactivateRescale();

        generalBtns.SetActive(false);

        gamesMenu.SetActive(true);
        closeMenuBtn.GetComponent<Image>().enabled = true;
    }

    // Exits games inventory. Shows the UI buttons again.
    public void DeactivatePlay()
    {
        generalBtns.SetActive(true);

        gamesMenu.SetActive(false);
        closeMenuBtn.GetComponent<Image>().enabled = false;
    }

    public void ActivateAnimate()
    {
        transformsUI_Script.DeactivateMove();
        transformsUI_Script.DeactivateRotation();
        transformsUI_Script.DeactivateRescale();

        generalBtns.SetActive(false);

        animationsMenu.SetActive(true);
        closeMenuBtn.GetComponent<Image>().enabled = true;
    }

    public void DeactivateAnimate()
    {
        generalBtns.SetActive(true);

        animationsMenu.SetActive(false);
        closeMenuBtn.GetComponent<Image>().enabled = false;
    }
}
