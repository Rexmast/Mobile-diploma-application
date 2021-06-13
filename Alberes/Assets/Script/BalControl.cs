using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Data.SqlClient;

public  class BalControl : MonoBehaviour
{
    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DiplimMDA.mssql.somee.com;Persist Security Info=True;User ID=Rexmast_SQLLogin_1;Password=9oven62qtd");
    public GameObject[] Step = new GameObject[1];
    public double[] BalOneStep = new double[1];
    public double BalMinusOneError = -0.75;
    double LocalBal = 0;
    public GameObject fin;
    public Text fintext;
    public int Opit;

    private void Start()
    {
        if (Global.OnlineMode)
        {
            sqlConnection.Open();
        }
        
        
    }
    void RashetBal()
    {
        LocalBal = BalOneStep[Global.StepNumber] +(BalMinusOneError * Global.ErrorCounter);
        if (LocalBal < 0) { LocalBal = 0; }
        Global.Bal += LocalBal;
        Debug.Log("Ошибок в ходе выполнения " + Global.ErrorCounter);
        Debug.Log("Набранный балл " + Global.Bal);
        Global.ErrorCounter = 0;
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
            fintext.text += Global.Bal.ToString("N1") ;
            Debug.Log("Завершено с результатом " + Global.Bal);
        }
        if (Global.OnlineMode)
        {
            SqlCommand command = new SqlCommand("UPDATE[dbo].[Save] SET[IDStudent] = " + Global.IDUser + " ,[IDOpit] =" + Opit + "  ,[Bal] = " + Global.Bal.ToString().Replace(',', '.') + "  ,[Step] = " + Global.StepNumber + " " +
              "WHERE (IDStudent = " + Global.IDUser + ") AND (IDOpit = " + Opit + ")", sqlConnection);
            command.ExecuteNonQuery();
        }
        else
        {
            PlayerPrefs.SetInt("StepNumber"+Opit, Global.StepNumber);
            PlayerPrefs.SetFloat("BalNumber" + Opit, (float)Global.Bal);
        }
       


    }
}
