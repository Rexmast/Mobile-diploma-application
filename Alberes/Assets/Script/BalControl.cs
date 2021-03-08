using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class BalControl : MonoBehaviour
{
    public GameObject[] Step = new GameObject[1];
    public double[] BalOneStep = new double[1];
    public double BalMinusOneError = -0.75;
    double LocalBal = 0;
    public GameObject fin;
    public Text fintext;
    
    void RashetBal()
    {
        LocalBal = BalOneStep[Global.StepNumber] +(BalMinusOneError * Global.ErrorCounter);
        if (LocalBal < 0) { LocalBal = 0; }
        Global.Bal += LocalBal;
        Debug.Log("Ошибок в ходе выполнения " + Global.ErrorCounter);
        Debug.Log("Набраный бал " + Global.Bal);

    }
    public void  Rezult()
    { 
      RashetBal();
      NextStep();
    }
     void NextStep() 
     {
        Step[Global.StepNumber].SetActive(false);
        Global.StepNumber++;
        if (Global.StepNumber < Step.Length) {
            
            Step[Global.StepNumber].SetActive(true);
        }
        else
        {
            fin.SetActive(true);
            fintext.text += Global.Bal.ToString();
            Debug.Log("Завершено с результатом " + Global.Bal);
        }

        
     }
}
