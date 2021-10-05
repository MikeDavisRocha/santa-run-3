using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButton;
    public Text[] lockText;
    private LoadTotalCandies loadTotalCandies;
    public CanvasGroup notEnoughCurrencyMessage;
    private int indexLevel;

    private void Awake()
    {
        loadTotalCandies = FindObjectOfType<LoadTotalCandies>();
    }

    private void Start()
    {
        ShowUnlockedLevels();
    }

    public void SelectLevel(int index)
    {
        indexLevel = index;
    }

    public void UnlockNewLevel(int price)
    {
        int totalCandies = PlayerPrefs.GetInt("Highscore");
        string levelNumber = "Level" + indexLevel;
        bool isLevelLocked = PlayerPrefs.GetInt(levelNumber) == 0 ? true : false;

        if (isLevelLocked)
        {
            if (price > totalCandies)
            {
                ShowNotEnoughCurrencyMessage();
            }
            else
            {
                Buy(price);
                SaveLevelUnlocked(indexLevel);
                levelButton[indexLevel].interactable = true;
                lockText[indexLevel].text = "";
            }
        }
    }

    private void Buy(int price)
    {
        int totalCandies = GetTotalCandies();
        UpdateTotalCandies(totalCandies, price);
    }

    private void SaveLevelUnlocked(int number)
    {
        // 0 = Locked, 1 = Unlocked
        string levelName = "Level" + number.ToString();
        PlayerPrefs.SetInt(levelName, 1);
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

    public void ShowNotEnoughCurrencyMessage()
    {
        notEnoughCurrencyMessage.alpha = 1;
        notEnoughCurrencyMessage.blocksRaycasts = true;
    }

    public void HideNotEnoughCurrencyMessage()
    {
        notEnoughCurrencyMessage.alpha = 0;
        notEnoughCurrencyMessage.blocksRaycasts = false;
    }

    private void ShowUnlockedLevels()
    {
        for (int i = 0; i < levelButton.Length; i++)
        {
            string levelNumber = "Level" + i;
            bool isLevelLocked = PlayerPrefs.GetInt(levelNumber) == 0 ? true : false;
            if (!isLevelLocked)
            {
                levelButton[i].interactable = true;
                lockText[i].text = "";
            }
            else
            {
                levelButton[i].interactable = false;
                lockText[i].text = "LOCKED";
            }
        }
    }
}
