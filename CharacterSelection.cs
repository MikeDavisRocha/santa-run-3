using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Image[] selectButtonsImage;
    public Image[] backgroundCharactersImage;
    public Sprite selectButtonSprite;
    public Sprite selectedButtonSprite;
    public Sprite backgroundNotSelectedCharacterSprite;
    public Sprite backgroundSelectedCharacterSprite;
    public CanvasGroup notEnoughCurrencyMessage;
    private LoadTotalCandies loadTotalCandies;
    private CharacterNumber characterNumber;

    private void Awake()
    {
        loadTotalCandies = FindObjectOfType<LoadTotalCandies>();
        characterNumber = FindObjectOfType<CharacterNumber>();
    }

    private void Start()
    {
        ShowUnlockedCharacters();
        SaveCharacterUnlocked(0);
    }

    public void SelectCharacter()
    {
        ShowUnlockedCharacters();
        string characterName = "Character" + characterNumber.GetCharacterNumber();
        bool isCharacterLocked = PlayerPrefs.GetInt(characterName) == 0 ? true : false;
        int index = characterNumber.GetCharacterNumber();

        backgroundCharactersImage[index].GetComponent<CharacterStats>().Selected = isCharacterLocked ? false : true;
        bool isSelected = backgroundCharactersImage[index].GetComponent<CharacterStats>().Selected;
        
        for (int i = 0; i < backgroundCharactersImage.Length; i++)
        {
            if (i == characterNumber.GetCharacterNumber() && isSelected)
            {
                selectButtonsImage[i].sprite = selectedButtonSprite;
                backgroundCharactersImage[i].sprite = backgroundSelectedCharacterSprite;
                backgroundCharactersImage[i].GetComponent<CharacterStats>().Selected = true;
                characterNumber.SelectUnlockedCharacter(index);
            }            
        }
    }

    public void UnlockNewCharacter(int price)
    {
        int totalCandies = PlayerPrefs.GetInt("Highscore");
        string characterName = "Character" + characterNumber.GetCharacterNumber();
        bool isCharacterLocked = PlayerPrefs.GetInt(characterName) == 0 ? true : false;

        if (isCharacterLocked)
        {
            if (price > totalCandies)
            {
                ShowNotEnoughCurrencyMessage();
            }
            else
            {
                Buy(price);
                SaveCharacterUnlocked(characterNumber.GetCharacterNumber());
            }
        }
    }

    private void Buy(int price)
    {
        ShowUnlockedCharacters();
        ChangeButtonSprite();
        ChangeBackgroundCharacterImage();
        int totalCandies = GetTotalCandies();
        UpdateTotalCandies(totalCandies, price);
    }

    private void SaveCharacterUnlocked(int number)
    {
        // 0 = Locked, 1 = Unlocked
        string characterName = "Character" + number.ToString();
        PlayerPrefs.SetInt(characterName, 1);
    }

    private int GetTotalCandies()
    {
        return PlayerPrefs.GetInt("Highscore");
    }

    private void UpdateTotalCandies(int totalCandies, int price)
    {
        PlayerPrefs.SetInt("Highscore", totalCandies - price);
        loadTotalCandies.UpdateTotalCandies();
    }

    private void ChangeButtonSprite()
    {
        selectButtonsImage[characterNumber.GetCharacterNumber()].sprite = selectedButtonSprite;
        selectButtonsImage[characterNumber.GetCharacterNumber()].GetComponentInChildren<Text>().text = "";
    }

    private void ChangeBackgroundCharacterImage()
    {
        backgroundCharactersImage[characterNumber.GetCharacterNumber()].sprite = backgroundSelectedCharacterSprite;
    }

    public void ShowNotEnoughCurrencyMessage()
    {
        notEnoughCurrencyMessage.alpha = 1;
    }

    public void HideNotEnoughCurrencyMessage()
    {
        notEnoughCurrencyMessage.alpha = 0;
    }

    private void ShowUnlockedCharacters()
    {
        for (int i = 0; i < backgroundCharactersImage.Length; i++)
        {
            string characterName = "Character" + i;
            bool isCharacterLocked = PlayerPrefs.GetInt(characterName) == 0 ? true : false;
            if (!isCharacterLocked)
            {
                backgroundCharactersImage[i].sprite = backgroundNotSelectedCharacterSprite;
                selectButtonsImage[i].sprite = selectButtonSprite;
                backgroundCharactersImage[i].GetComponent<CharacterStats>().Locked = false;
                selectButtonsImage[i].GetComponentInChildren<Text>().text = "";
            }
            else
            {
                backgroundCharactersImage[i].GetComponent<CharacterStats>().Locked = true;
            }
        }
    }
}
