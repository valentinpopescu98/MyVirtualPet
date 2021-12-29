using UnityEngine;
using UnityEngine.UI;

public class ExperienceSystemUI : MonoBehaviour
{
    public GameObject gameController;

    public GameObject xpBar;
    public GameObject level;

    ExperienceSystem xpSystemScript;

    void Start()
    {
        xpSystemScript = gameController.GetComponent<ExperienceSystem>();
    }

    void Update()
    {
        xpBar.GetComponent<Image>().fillAmount = xpSystemScript.crtXP / (float)xpSystemScript.maxXP;
        level.GetComponent<Text>().text = xpSystemScript.level.ToString();
    }
}
