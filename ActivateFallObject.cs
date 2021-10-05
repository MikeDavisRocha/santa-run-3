using UnityEngine;

public class ActivateFallObject : MonoBehaviour
{
    public GameObject colliderThatHoldObject;
    private Vector3[] fallenObjectInitialPosition;
    public Transform[] fallenObjectTransform;

    private void Start()
    {
        SaveInitialPosition();
    }

    private void SaveInitialPosition()
    {
        fallenObjectInitialPosition = new Vector3[fallenObjectTransform.Length];
        for (int i = 0; i < fallenObjectTransform.Length; i++)
        {
            fallenObjectInitialPosition[i] = fallenObjectTransform[i].localPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            MakeItFall();
            Invoke("ResetTrap", 5f);
        }
    }

    private void MakeItFall()
    {
        colliderThatHoldObject.SetActive(false);
    }

    private void ResetTrap()
    {
        colliderThatHoldObject.SetActive(true);
        ResetPosition();
    }

    private void ResetPosition()
    {
        for (int i = 0; i < fallenObjectInitialPosition.Length; i++)
        {
            fallenObjectTransform[i].localPosition = fallenObjectInitialPosition[i];
        }
    }
}
