using System.Collections;
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
    [SerializeField]
    int KStart = 3;
    [SerializeField]
    Text OnlineTest;

    void Start()
    {
        sqlConnection.Open();
        Global.k = KStart;
        if (Global.OnlineMode)
        {
            LoadSave();
            DataTable table = Tabel(new SqlDataAdapter("SELECT        Otchestvo, Famil, Name FROM            dbo.Student WHERE        (IdStudent = " + Global.IDUser + ") AND (Password = N'" + Global.UserPasword + "')", sqlConnection));
            OnlineTest.text = "Вы вошли как: " + table.Rows[0][2].ToString()+ " "+table.Rows[0][1].ToString()+ " "+table.Rows[0][0].ToString();
        }
        else
        {
            OflineloadSave();
            OnlineTest.text = "Вы находитесь в режиме офлайн";
        }
       
    }
    DataTable Tabel(SqlDataAdapter adapter)
    {
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;

    }
    void LoadSave()
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
    void OflineloadSave()
    {
        if (PlayerPrefs.HasKey("StepNumber" + Opit))
        {
           
            Global.Bal = PlayerPrefs.GetFloat("BalNumber" + Opit);
            Global.StepNumber = PlayerPrefs.GetInt("StepNumber" + Opit);
            Step[PlayerPrefs.GetInt("StepNumber" + Opit)].SetActive(true);
            if (PlayerPrefs.GetInt("StepNumber" + Opit) + 1 >= Step.Length)
            {
                FinTest.text += Global.Bal.ToString("N1");
            }
        }
        else
        {
             Step[0].SetActive(true);
        }
    }
}
