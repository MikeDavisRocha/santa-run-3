using UnityEngine;
using UnityEngine.UI;

public class CandiesController : MonoBehaviour
{
    private int numCandies;
    public Text numCandiesInGameText, numCandiesGameOverText;

    void Start()
    {
        numCandies = 0;
    }

    public void AddCandy()
    {
        numCandies++;
        UpdateCandiesScore();
    }

    public void UpdateCandiesScore()
    {
        numCandiesInGameText.text = numCandies.ToString();
        numCandiesGameOverText.text = numCandies.ToString();
    }

    public int GetNumCandies()
    {
        return numCandies;        
    }

    /*
    public int GetMaxNumCandies()
    {
        PlayerData data = SaveSystem.LoadScore();

        if (data == null)
        {
            return numCandies;
        }
        else
        {
            return data.numCandies + numCandies;
        }
    }    
   */

    public void SaveCandyScore()
    {
        // SaveSystem.SaveScore(this);
        int totalCandies = PlayerPrefs.GetInt("Highscore");
        PlayerPrefs.SetInt("Highscore", totalCandies + numCandies);
    }    

    public void DoubleCandies()
    {
        numCandies *= 2;
    }
    public void GiveMoreCandies()
    {
        numCandies += 200;
    }    
}
