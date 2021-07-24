using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjective : MonoBehaviour
{
    public float numTargets = 11f;
    private float numKilled = 0f;

    public GameObject youWinUI;
    public GameObject objectiveUI;

    // Start is called before the first frame update
    void Start()
    {
        youWinUI.SetActive(false);
        objectiveUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfWin();
    }

    public void ConfirmKill()
    {
        numKilled++;
        Debug.Log("Killed " +  numKilled + " Enemies");
    }

    void CheckIfWin()
    {
        if (numKilled >= numTargets)
        {
            Win();
        }
    }

    void Win()
    {
        youWinUI.SetActive(true);
        objectiveUI.SetActive(false);
    }
}
