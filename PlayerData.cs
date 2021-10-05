using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int numCandies, maxNumCandies;

    public PlayerData(CandiesController candiesController)
    {
        // numCandies = candiesController.GetNumCandies();
        // maxNumCandies = candiesController.GetMaxNumCandies();
    }
}
