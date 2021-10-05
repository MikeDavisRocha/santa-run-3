using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSaw : MonoBehaviour
{
    public GameObject saw;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Activate();
            Invoke("ResetTrap", 3f);
        }        
    }

    private void Activate()
    {
        saw.GetComponent<MoveSaw>().canMoveSaw = true;
    }
    private void ResetTrap()
    {
        saw.GetComponent<MoveSaw>().canMoveSaw = false;
        saw.GetComponent<MoveSaw>().ResetSawPosition();
    }
}
