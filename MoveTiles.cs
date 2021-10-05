using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTiles : MonoBehaviour
{
    private float startpos;
    private float speed = 0;
    private float speedAccelerationPerSecond = 3f;
    [SerializeField] private float maxSpeed = 5f;
    private int index;
    private float currentTime;
    private GameManager gameManager;

    public enum TileType
    {
        Sky,
        Floor
    }

    public TileType myTileType;

    void Start()
    {
        startpos = transform.position.x;
        index = 0;
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!gameManager.isPaused)
        {
            Accelerate();
            Move();
            RunTime();
        }
    }

    public void Accelerate()
    {
        if (speed < maxSpeed)
        {
            speed += speedAccelerationPerSecond * Time.deltaTime;
        }
        else
        {
            speed = maxSpeed;
        }
    }

    private void Move()
    {
        Vector3 newPosition = transform.position + new Vector3(startpos - speed, transform.position.y, transform.position.z) * Time.deltaTime;
        transform.position = newPosition;        
    }      

    public void RunTime()
    {
        currentTime += Time.deltaTime;
    }
}
