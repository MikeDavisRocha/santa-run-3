using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyParallax : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_SKYPART_PART = 30f;
    private Vector3 lastEndPosition;
    [SerializeField] private Transform skyPart_Start;
    [SerializeField] private Transform skyTilesParent;
    [SerializeField] private List<Transform> skyList;
    [SerializeField] private Player player;

    private void Awake()
    {
        lastEndPosition = skyPart_Start.Find("EndPosition").position;
    }

    private void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_SKYPART_PART)
        {
            SpawnSkyPart();
        }
    }

    private void SpawnSkyPart()
    {       
        Transform chosenLevelPart = skyList[0];        
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        levelPartTransform.parent = skyTilesParent;
        return levelPartTransform;
    }

}
