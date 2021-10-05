using UnityEngine;

public class ShootBullet : MonoBehaviour
{       
    private Animator _muzzleAnimator;
    public GameObject _bulletPrefab;

    private void Start()
    {        
        _muzzleAnimator = GameObject.Find("Muzzle").GetComponent<Animator>();
    }    

    public void ActivateShoot()
    {        
        GameObject bullet = Instantiate(_bulletPrefab);
        bullet.transform.parent = GameObject.Find("PlayerRobot").transform;
        bullet.transform.position = GameObject.Find("BulletPosition").transform.position;        
        _muzzleAnimator.SetBool("Muzzle", true);
    }

    public void DeactivateShoot()
    {    
        _muzzleAnimator.SetBool("Muzzle", false);
    }       
}
