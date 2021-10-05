using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandiesDailyRewardsController : MonoBehaviour
{
    public void CandiesDailyRewards(int candies)
    {
        int totalCandies = PlayerPrefs.GetInt("Highscore");
        PlayerPrefs.SetInt("Highscore", totalCandies + candies);
    }
}
