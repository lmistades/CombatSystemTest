using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet")]
public class BulletSO : ScriptableObject
{
    public float damage;
    public float speed;
    public Rigidbody bulletPrefab;
    
}
