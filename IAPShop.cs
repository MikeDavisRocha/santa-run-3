using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;


public class IAPShop : MonoBehaviour
{
    private string candies = "com.company.santarun3.candies";
    public GameObject restorePurchaseBtn;

    private void Awake()
    {
        DisableRestorePurchaseBtn();
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == candies)
        {
            // Reward the player 4,000 candies
            Debug.Log("Give the player 4,000 candies");
            BuyCandies(4000);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + reason);
    }

    private void DisableRestorePurchaseBtn()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restorePurchaseBtn.SetActive(false);
        }
    }

    public void BuyCandies(int num)
    {
        int totalCandies = PlayerPrefs.GetInt("Highscore");
        PlayerPrefs.SetInt("Highscore", totalCandies + num);
    }
}
