﻿using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoder : MonoBehaviour
{
    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DiplimMDA.mssql.somee.com;Persist Security Info=True;User ID=Rexmast_SQLLogin_1;Password=9oven62qtd");
    [SerializeField]
    GameObject[] Step;
    [SerializeField]
    int Opit;
    [SerializeField]
    Text FinTest;
    void Start()
    {
        sqlConnection.Open();
        loadSave();
    }
    DataTable Tabel(SqlDataAdapter adapter)
    {
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;

    }
    void loadSave()
    {
        DataTable table = Tabel(new SqlDataAdapter("SELECT        dbo.[Save].Bal, dbo.[Save].Step FROM            dbo.[Save] INNER JOIN   dbo.Student ON dbo.[Save].IDStudent = dbo.Student.IdStudent WHERE        (dbo.[Save].IDOpit = " + Opit + ") AND (dbo.Student.IdStudent = " + Global.IDUser + ") AND (dbo.Student.Password = N'" + Global.UserPasword + "')", sqlConnection));
        if (table.Rows.Count != 0)
        {
            Global.Bal = float.Parse(table.Rows[0][0].ToString());
            Global.StepNumber = int.Parse(table.Rows[0][1].ToString());
            Step[int.Parse(table.Rows[0][1].ToString())].SetActive(true);
            if(int.Parse(table.Rows[0][1].ToString())+1>= Step.Length)
            {
                FinTest.text += Global.Bal.ToString("N1");
            }
        }
        else
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Save] ([IDStudent],[IDOpit],[Bal],[Step]) " +
            "VALUES(" + Global.IDUser.ToString() + "," + Opit.ToString() + "," + 0 + "," + 0 + ")", sqlConnection);
            command.ExecuteNonQuery();
            Step[0].SetActive(true);
        }
    }
}
