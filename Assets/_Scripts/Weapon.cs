using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSO weapon;
    [SerializeField] private BulletSO bullet;
    public Rigidbody bulletPrefab;
    public Transform spawnTarget;

    void Start()
    {

        bulletPrefab = bullet?.bulletPrefab;
        InvokeRepeating(nameof(Shoot),2f,weapon.attackSpeed);
    }

    void Update()
    {
        
    }

    void Shoot()
    {
        if(bulletPrefab!= null && bullet != null)
        {
            Rigidbody clone = Instantiate(bulletPrefab, spawnTarget.position,transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * bullet.speed);

        }
        
    }
}
