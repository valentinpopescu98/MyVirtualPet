using UnityEngine;

public class ChangeChar : MonoBehaviour
{
    public Characters activeChar;

    void Start()
    {
        // Set starting character
        transform.GetChild((int)activeChar).gameObject.SetActive(true);
    }

    public void ChangeLeft()
    {
        if ((int)activeChar > 0)
        {
            ChangeActiveChar(activeChar, activeChar - 1);
            activeChar--;
        }
    }

    public void ChangeRight()
    {
        if ((int)activeChar < System.Enum.GetValues(typeof(Characters)).Length - 1)
        {
            ChangeActiveChar(activeChar, activeChar + 1);
            activeChar++;
        }
    }

    public void ChangeActiveChar(Characters prevChar, Characters newChar)
    {
        transform.GetChild((int)prevChar).gameObject.SetActive(false);
        transform.GetChild((int)newChar).gameObject.SetActive(true);
    }
}
