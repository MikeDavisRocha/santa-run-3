using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    private CharacterNumber characterNumber;
    public Transform playerList;

    private void Awake()
    {
        characterNumber = FindObjectOfType<CharacterNumber>();
    }

    void Start()
    {
        ActivatePlayer();
    }
    
    private void ActivatePlayer()
    {
        for (int i = 0; i < playerList.childCount; i++)
        {
            if (i == characterNumber.GetUnlockedCharacterNumber())
            {
                playerList.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                playerList.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
