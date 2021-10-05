using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowballController : MonoBehaviour
{
    private ThrowSnowball throwSnowball;
    [SerializeField]
    int stepTime;

    float timeStart = 0f;
    bool looping = true;

    IEnumerator Start()
    {
        do
        {
            timeStart += Time.deltaTime;
            yield return StartCoroutine(CallAttackCoroutine());
        }
        while (looping);
    }

    private void Awake()
    {
        throwSnowball = GetComponent<ThrowSnowball>();
    }

    private IEnumerator CallAttackCoroutine()
    {
        if ((Mathf.RoundToInt(timeStart) % stepTime) == 0)
        {
            throwSnowball.Attack(true);
        }        
        yield return new WaitForSeconds(0f);
        throwSnowball.Attack(false);
    }
}
