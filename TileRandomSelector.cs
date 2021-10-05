using UnityEngine;

public class TileRandomSelector : MonoBehaviour
{
    public int RandomSelectTiles(int numberOfTiles)
    {
        return Random.Range(0, numberOfTiles);
    }
}
