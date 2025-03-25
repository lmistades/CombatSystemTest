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

    private GameObject resultUI;
    private GameObject unitsParent;

    void Start()
    {
        //find units and add to static list.
        unitsList.AddRange(GameObject.FindGameObjectsWithTag("Unit"));
        unitCount = unitsList.Count;
        Debug.Log(unitCount);
        resultUI = GameObject.FindGameObjectWithTag("UI");
        unitsParent = GameObject.FindGameObjectWithTag("UnitsParent");

    }

    void LateUpdate()
    {
        if(unitCount == 1)
        {
            winner = unitsParent.transform.GetChild(0).gameObject;
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
        resultUI.GetComponent<UIController>().resultText.text = result + "                           press space to restart.";
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
