using UnityEngine;
using UnityEngine.UI;

public class LoadTotalCandies : MonoBehaviour
{
    public Text numCandiesInGameText;

    void Start()
    {
        // PlayerPrefs.GetInt("Highscore");
        //PlayerData data = SaveSystem.LoadScore();
        // numCandiesInGameText.text = data.maxNumCandies.ToString();
        UpdateTotalCandies();
    }    

    public void UpdateTotalCandies()
    {
        numCandiesInGameText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}
