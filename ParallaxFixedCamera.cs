using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFixedCamera : MonoBehaviour
{
    private float startpos;
    private float speed = 0;
    private float speedAccelerationPerSecond = 3f;
    [SerializeField]
    private float maxSpeed = 5f;
    public GameObject[] tiles;
    private Vector2 lastTilePosition;
    private int index;
    private bool canInstantiate = false;
    private float currentTime;
    public Transform tilesToUse;
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
        lastTilePosition = new Vector2(tiles[2].transform.position.x * 2, tiles[2].transform.position.y);
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

    public Vector3 GetLastTilePosition()
    {
        return new Vector3(lastTilePosition.x, lastTilePosition.y, tiles[0].transform.position.z);
    }

    private void Move()
    {
        Vector3 newPosition = transform.position + new Vector3(startpos - speed, transform.position.y, transform.position.z) * Time.deltaTime;
        transform.position = newPosition;
        CheckTilePosition();
    }

    public void CheckTilePosition()
    {
        if(currentTime != 0 && Mathf.FloorToInt(currentTime) % 10 == 0)
        {
            CreateNewTile();
        }
    }

    public void CreateNewTile()
    {        
        canInstantiate = false;
    }

    public void RunTime()
    {
        currentTime += Time.deltaTime;
    }

    public void ChangeParentFromNotUsedTiles()
    {
        int numberElementsToBeMoved = transform.GetChild(0).childCount - 3;
        for (int i = 0; i < numberElementsToBeMoved; i++)
        {
            Transform childFloor = transform.GetChild(0).GetChild(3);
            childFloor.SetParent(tilesToUse);
        }
    }
}
