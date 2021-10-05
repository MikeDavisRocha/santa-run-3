using UnityEngine;

public class LevelNumber : MonoBehaviour
{
    private static int levelNumber;

    public void SelectLevel(int number)
    {
        levelNumber = number;
    }

    public int GetLevelNumber()
    {
        return levelNumber;
    }
}
