using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSaw : MonoBehaviour
{
    [SerializeField] private int speed;
    public bool canMoveSaw = false;
    private Vector3 sawInitialPosition;

    private void Start()
    {
        sawInitialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (canMoveSaw)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void ResetSawPosition()
    {
        transform.localPosition = sawInitialPosition;
    }
}
