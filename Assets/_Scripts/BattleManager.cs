using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static readonly List<GameObject> unitsList = new List<GameObject>();
    [SerializeField] private int unitCount;
    public string result;
    [SerializeField] private GameObject winner;

    void Start()
    {
        //find units and add to static list.
        unitsList.AddRange(GameObject.FindGameObjectsWithTag("Unit"));
        unitCount = unitsList.Count;
        Debug.Log(unitCount);
    }

    void LateUpdate()
    {
        //when only 1 unit remains, display result and stop shooting
        if(unitCount == 1)
        {
            winner = GameObject.FindGameObjectWithTag("Unit");
            result = winner?.GetComponent<UnitStats>().unitName + " WINS!";
            winner.transform.GetChild(0).GetChild(0).GetComponent<Weapon>().CancelInvoke("Shoot");
            DisplayResult();
        }
        //catcher for unlikely draw
        if(unitCount == 0)
        {
            result = "Everybody Loses!";
            DisplayResult();
        }
        else
        {
            return;
        }
    }

    //acts as listener for OnDeath UnityEvent
    public void ReduceUnits()
    {
        unitCount--;
        Debug.Log(unitCount);
    }

    void DisplayResult()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().resultText.text = result + "                           press space to restart.";
        if(Input.GetKeyDown(KeyCode.Space))
        {
            unitsList.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    
}
