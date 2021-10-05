using UnityEngine;

public class CheckTileCollider : MonoBehaviour
{
    private ParallaxFixedCamera parallaxFixedCamera;
    private Transform tilesToRemove;
    private static int skyOffset;
    private static int floorOffset;   
    private static int indexTile;
    private TileRandomSelector tileRandomSelector;
    private GameManager gameManager;

    private void Awake()
    {
        parallaxFixedCamera = transform.parent.parent.parent.GetComponent<ParallaxFixedCamera>();
        tilesToRemove = GameObject.Find("Tiles to Remove").transform;
        tileRandomSelector = FindObjectOfType<TileRandomSelector>();
        gameManager = FindObjectOfType<GameManager>();
        skyOffset = 2;
        floorOffset = 2;
    }

    private void Start()
    {
        parallaxFixedCamera.ChangeParentFromNotUsedTiles();
        indexTile = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (parallaxFixedCamera.myTileType.Equals(ParallaxFixedCamera.TileType.Sky))
            {
                Transform firstChild = parallaxFixedCamera.transform.GetChild(0).GetChild(0);
                firstChild.localPosition = new Vector3(17.76f * skyOffset, 0, 10f);
                firstChild.SetAsLastSibling();
                skyOffset += 1;
            }
            if (parallaxFixedCamera.myTileType.Equals(ParallaxFixedCamera.TileType.Floor))
            {
                if(gameManager.GetGameState())
                {
                    if(indexTile < 3)
                    {
                        Transform firstChildFloor = parallaxFixedCamera.transform.GetChild(0).GetChild(0);
                        firstChildFloor.SetParent(tilesToRemove);
                        firstChildFloor.transform.localPosition = new Vector3(0f, 0f, 5f);
                        int tileIndex = tileRandomSelector.RandomSelectTiles(parallaxFixedCamera.tilesToUse.childCount);
                        Transform firstChildTilesToUse = parallaxFixedCamera.tilesToUse.transform.GetChild(tileIndex);
                        firstChildTilesToUse.SetParent(parallaxFixedCamera.transform.GetChild(0));
                        firstChildTilesToUse.localPosition = new Vector3(19.1967f * floorOffset, -4f, 5f);
                        floorOffset += 1;
                        indexTile += 1;
                    }
                    else
                    {
                        Transform firstChildFloor = parallaxFixedCamera.transform.GetChild(0).GetChild(0);
                        firstChildFloor.SetParent(parallaxFixedCamera.tilesToUse);
                        firstChildFloor.transform.localPosition = new Vector3(0f, 0f, 5f);
                        int tileIndex = tileRandomSelector.RandomSelectTiles(parallaxFixedCamera.tilesToUse.childCount);
                        Transform firstChildTilesToUse = parallaxFixedCamera.tilesToUse.transform.GetChild(tileIndex);
                        firstChildTilesToUse.SetParent(parallaxFixedCamera.transform.GetChild(0));
                        firstChildTilesToUse.localPosition = new Vector3(19.1967f * floorOffset, -4f, 5f);
                        floorOffset += 1;
                        indexTile += 1;
                    }
                }
                else
                {
                    // Run this code only on pregame
                    Transform firstChildFloor = parallaxFixedCamera.transform.GetChild(0).GetChild(0);
                    firstChildFloor.SetParent(parallaxFixedCamera.tilesToUse);
                    firstChildFloor.transform.localPosition = new Vector3(0f, 0f, 5f);
                    Transform firstChildTilesToUse = parallaxFixedCamera.tilesToUse.transform.GetChild(0);
                    firstChildTilesToUse.SetParent(parallaxFixedCamera.transform.GetChild(0));
                    firstChildTilesToUse.localPosition = new Vector3(19.1967f * floorOffset, -3.2f, 5f);
                    floorOffset += 1;
                }
            }           
        }
    }
}
