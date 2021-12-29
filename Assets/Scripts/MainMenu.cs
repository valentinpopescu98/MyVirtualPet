using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject playerPortrait;

    public GameObject mainMenu;
    public GameObject cancelBtn;

    public void ActivateMainMenu()
    {
        playerPortrait.SetActive(false);
        this.gameObject.SetActive(false); // general buttons

        mainMenu.SetActive(true);
        cancelBtn.SetActive(true);
    }

    public void DeactivateMainMenu()
    {
        playerPortrait.SetActive(true);
        this.gameObject.SetActive(true); // general buttons

        mainMenu.SetActive(false);
        cancelBtn.SetActive(false);
    }
}
