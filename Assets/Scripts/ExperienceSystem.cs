using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    public uint level = 1;
    public uint maxXP = 20;
    public uint crtXP;

    void Update()
    {
        // If level-up happens at current frame
        if (levelUp())
        {
            crtXP -= maxXP;
            level++;

            if (level < 10)
            {
                maxXP += 20;
            }
            else if (level < 20)
            {
                maxXP += 30;
            }
            else if (level < 30)
            {
                maxXP += 50;
            }
            else if (level < 40)
            {
                maxXP += 80;
            }
            else if (level < 50)
            {
                maxXP += 130;
            }
            else if (level < 60)
            {
                maxXP += 210;
            }
            else if (level < 70)
            {
                maxXP += 240;
            }
            else if (level < 80)
            {
                maxXP += 450;
            }
            else if (level < 90)
            {
                maxXP += 690;
            }
            else if (level < 100)
            {
                maxXP += 1140;
            }
            else
            {
                maxXP += 1050;
            }
        }
    }

    public bool levelUp()
    {
        return crtXP >= maxXP;
    }
}
