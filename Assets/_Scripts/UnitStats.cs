using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class UnitStats : MonoBehaviour, IDamageable
{
    [SerializeField] private UnitSO unit;
    [SerializeField] private float health;
    [SerializeField] private UnityEvent onDeath;

    public string unitName;

    void Start()
    {
        transform.GetComponent<NavMeshAgent>().speed = unit.movementSpeed;
        health = unit.maxHealth;
        transform.GetComponent<Renderer>().material = unit.material;
        onDeath.AddListener(GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().ReduceUnits);
        unitName = unit.name;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 1)
        {
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
    
    void OnDisable()
    {
        onDeath.Invoke();
    }
}
