using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalControl : MonoBehaviour
{
    public GameObject[] Step = new GameObject[3];
    public double[] BalOneStep = new double[3];
    public double BalMinusOneError = -0.75;
    double LocalBal = 0;
    int LokalTemp = 0;
    void RashetBal()
    {
        LocalBal = BalOneStep[LokalTemp]-(BalMinusOneError * Global.ErrorCounter);
        if (LocalBal < 0) { LocalBal = 0; }
        Global.Bal += LocalBal;
        Debug.Log("Ошибок в ходе выполнения" + Global.ErrorCounter);
        Debug.Log("Набраный бал" + Global.Bal);

    }
    public void Rezult()
    {
        RashetBal();
        NextStep();
    }
     void NextStep() 
     {
        Step[LokalTemp].SetActive(false);
        if(LokalTemp < Step.Length) {
            LokalTemp++;
            Step[LokalTemp].SetActive(true);
        }
        
     }



}
