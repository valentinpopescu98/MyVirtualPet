using UnityEngine;

public class GameDataExtractor : MonoBehaviour
{
    public GameObject gameController;

    ExperienceSystem xpSystemScript;
    ChangeChar changeCharScript;

    void Start()
    {
        xpSystemScript = gameController.GetComponent<ExperienceSystem>();
        changeCharScript = gameController.GetComponent<ChangeChar>();
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(xpSystemScript.level, xpSystemScript.maxXP, xpSystemScript.crtXP, changeCharScript.activeChar);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();

        xpSystemScript.level = data.level;
        xpSystemScript.maxXP = data.maxXP;
        xpSystemScript.crtXP = data.crtXP;

        changeCharScript.ChangeActiveChar(changeCharScript.activeChar, data.activeChar);
        changeCharScript.activeChar = data.activeChar;
    }
}
