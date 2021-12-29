using UnityEngine;
using UnityEngine.UI;

public class AnimationsUI : MonoBehaviour
{
    public GameObject gameController;
    public GameObject waveBtn, angryBtn;

    ExperienceSystem xpSystemScript;

    void Start()
    {
        xpSystemScript = gameController.GetComponent<ExperienceSystem>();
    }

    void Update()
    {
        if (xpSystemScript.level < 10)
        {
            waveBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }
        else
        {
            waveBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        if (xpSystemScript.level < 20)
        {
            angryBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }
        else
        {
            angryBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
