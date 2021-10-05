using UnityEngine;

public class CharacterNumber : MonoBehaviour
{    
    private static int characterSelected = 8;
    private int characterNumber;

    public void SelectCharacter(int number)
    {
        characterNumber = number;        
    }

    public int GetCharacterNumber()
    {
        return characterNumber;
    }

    public void SelectUnlockedCharacter(int index)
    {
        characterSelected = index;
    }

    public int GetUnlockedCharacterNumber()
    {
        return characterSelected;
    }
}
