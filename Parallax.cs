using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    public Transform tilesToUse;
    private Vector3 originalPos;

    public enum TileType
    {
        Sky,
        Floor
    }

    public TileType myTileType;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        originalPos = new Vector3(0, 0 ,0);
    }        

    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) {
            startpos += length;
            ChangeMiddleTile();
            // ChangeLastTile();
        } 
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }

    public void ChangeMiddleTile()
    {
        if (myTileType.Equals(TileType.Floor))
        {
            Transform firstChildFloor = transform.GetChild(0).GetChild(0);
            firstChildFloor.SetParent(tilesToUse);
            Transform firstChildTilesToUse = tilesToUse.transform.GetChild(0);
            firstChildTilesToUse.SetParent(transform.GetChild(0));
            firstChildTilesToUse.SetAsFirstSibling();
            transform.GetChild(0).GetChild(0).localPosition = originalPos;
        }
    }

    public void ChangeLastTile()
    {
        if (myTileType.Equals(TileType.Floor))
        {
            Transform firstChildFloor = transform.GetChild(0).GetChild(2);
            firstChildFloor.SetParent(tilesToUse);
            Transform firstChildTilesToUse = tilesToUse.transform.GetChild(0);
            firstChildTilesToUse.SetParent(transform.GetChild(0));
            firstChildTilesToUse.SetAsLastSibling();
            transform.GetChild(0).GetChild(0).localPosition = new Vector3(0.1599669f, 0, 0);
        }
    }
}
