using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO bullet;

    void OnCollisionEnter(Collision hit)
    {
        IDamageable damageable = hit.gameObject.GetComponent<IDamageable>();
        
        if(damageable != null && bullet != null)
        {
            damageable.Damage(bullet.damage);
            
        }
        Destroy(this.gameObject);
        
    }

    void Update()
    {
        if(transform.position.y < -20f)
        {
            Destroy(this.gameObject);
        }
        
    }
}
