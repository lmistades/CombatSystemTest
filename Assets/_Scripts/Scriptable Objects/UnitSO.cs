using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitSO : ScriptableObject
{
    public int maxHealth;
    public new string name;
    public float movementSpeed;
    public Material material;
    
}
