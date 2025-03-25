using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetSelectionAndMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private GameObject randomTarget;
    void Start()
    {
        //Invoke("FindRandomTarget", 0.5f);
        
    }

    void Update()
    {
        if(target !=null)
        {
            transform.GetComponent<NavMeshAgent>()?.SetDestination(target.transform.position);
            FaceTarget(target.transform.position);
            BackUp();
            
        }
        else
        {
            FindRandomTarget();
            
        }    

    }

    void FindRandomTarget()
    {
        //find random target
        randomTarget = BattleManager.unitsList[Random.Range(0,BattleManager.unitsList.Count)];
        target = randomTarget;

        //switch target if unit happens to target self
        while(target == gameObject)
        {
            randomTarget = BattleManager.unitsList[Random.Range(0,BattleManager.unitsList.Count)];
            target = randomTarget;
        }
        
    }

    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.025f);  
    }

    //move back a little if your target is too close. This is necessary for when the weapon is too long to reach the target.
    void BackUp()
    {
        
        if(Vector3.Distance(target.transform.position,transform.position)<2.5f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, -2.5f * Time.deltaTime);
        }
    }
}
