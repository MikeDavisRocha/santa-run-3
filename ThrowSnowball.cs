using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{
    public GameObject golemSnowballPrefab;
    public Transform golemSnowballPosition;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack(bool state)
    {
        _animator.SetBool("Attack", state);
    }

    public void LaunchSnowBall()
    {
        GameObject snowballPrefab = Instantiate(golemSnowballPrefab, golemSnowballPosition);
        snowballPrefab.transform.parent = golemSnowballPosition;
    }
}
