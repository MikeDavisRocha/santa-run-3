using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;
    private Random rng = new Random();

    [SerializeField] private Transform pfTestingPlatform;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    // [SerializeField] private List<Transform> levelPartEasyList;
    // [SerializeField] private List<Transform> levelPartMediumList;
    // [SerializeField] private List<Transform> levelPartHardList;
    // [SerializeField] private List<Transform> levelPartImpossibleList;
    [SerializeField] private Player player;
    [SerializeField] private Transform tilesParent;

    private enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        Impossible
    }

    private Vector3 lastEndPosition;
    private int levelPartsSpawned;
    private int chosenLevelPartIndex;

    private void Awake()
    {
        HideAllSprites();
        Shuffle(levelPartList);
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        if (pfTestingPlatform != null)
        {
            Debug.Log("Using Debug Testing Platform!");
        }

        int startingSpawnLevelParts = 6;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }        
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        /*
        List<Transform> difficultyLevelPartList;
        switch (GetDifficulty())
        {
            default:
            case Difficulty.Easy:       difficultyLevelPartList = levelPartEasyList;        break;
            case Difficulty.Medium:     difficultyLevelPartList = levelPartMediumList;      break;
            case Difficulty.Hard:       difficultyLevelPartList = levelPartHardList;        break;
            case Difficulty.Impossible: difficultyLevelPartList = levelPartImpossibleList;  break;
        }                 
        */
        ShuffleListByDifficulty();
        levelPartList[chosenLevelPartIndex].gameObject.SetActive(true);
        ShowAllSprites();
        Transform chosenLevelPart = levelPartList[chosenLevelPartIndex];
        chosenLevelPartIndex++;

        if (pfTestingPlatform != null)
        {
            chosenLevelPart = pfTestingPlatform;
        }

        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        levelPartsSpawned++;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        //Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        Transform levelPartTransform = levelPart;
        levelPartTransform.position = spawnPosition;
        // levelPartTransform.parent = tilesParent;
        return levelPartTransform;
    }

    /*
    private Difficulty GetDifficulty()
    {
        if (levelPartsSpawned >= 15) return Difficulty.Impossible;
        if (levelPartsSpawned >= 10) return Difficulty.Hard;
        if (levelPartsSpawned >= 5) return Difficulty.Medium;
        return Difficulty.Easy;
    }
    */

    private void ShuffleListByDifficulty()
    {
        if (chosenLevelPartIndex == levelPartList.Count)
        {
            Shuffle(levelPartList);
            chosenLevelPartIndex = 0;            
        }        
    }

    private List<Transform> Shuffle(List<Transform> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Transform value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }    

    private void ShowAllSprites()
    {
        SpriteRenderer[] sprites = levelPartList[chosenLevelPartIndex].gameObject.GetComponentsInChildren<SpriteRenderer>();
        SetIndividualSpriteTrue(sprites);        
    }

    private void SetIndividualSpriteTrue(SpriteRenderer[] sprites)
    {
        StartCoroutine("SetIndividualSpriteTrueCoroutine", sprites);
    }

    IEnumerator SetIndividualSpriteTrueCoroutine(SpriteRenderer[] sprites)
    {
        foreach (SpriteRenderer s in sprites)
        {
            yield return new WaitForSeconds(0.03f);
            s.enabled = true;
        }
    }

    private void HideAllSprites()
    {
        for (int i = 0; i < levelPartList.Count; i++)
        {
            SpriteRenderer[] sprites = levelPartList[i].gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer s in sprites)
            {
                s.enabled = false;
            }
        }
    }
}
