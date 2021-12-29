[System.Serializable]
public class GameData
{
    public uint level, maxXP, crtXP;
    public Characters activeChar;

    public GameData(uint level, uint maxXP, uint crtXP, Characters activeChar)
    {
        this.level = level;
        this.maxXP = maxXP;
        this.crtXP = crtXP;
        this.activeChar = activeChar;
    }
}
