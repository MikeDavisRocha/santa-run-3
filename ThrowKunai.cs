using UnityEngine;

public class ThrowKunai : MonoBehaviour
{    
    public GameObject _kunaiPrefab;

    public void ActivateShoot()
    {
        GameObject bullet = Instantiate(_kunaiPrefab);
        bullet.transform.parent = GameObject.Find("PlayerPurpleNinja").transform;
        bullet.transform.position = GameObject.Find("KunaiPosition").transform.position;
    }
}
