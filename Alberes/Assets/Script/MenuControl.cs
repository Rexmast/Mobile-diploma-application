using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Data;
using System.Data.SqlClient;

public class MenuControl : MonoBehaviour
{
    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DiplimMDA.mssql.somee.com;Persist Security Info=True;User ID=Rexmast_SQLLogin_1;Password=9oven62qtd");
    public GameObject buttonsMenu;
    public GameObject buttonsSetings;
    public GameObject buttonsVibor;
    public GameObject[] Pnl;

    public void ShowSeting()
    {
        buttonsMenu.SetActive(false);
        buttonsSetings.SetActive(true);
        buttonsVibor.SetActive(false);
    }
    public void ReturnMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsSetings.SetActive(false);
        buttonsVibor.SetActive(false);
    }
    public void ShowOpit()
    {
        buttonsMenu.SetActive(false);
        buttonsSetings.SetActive(false);
        buttonsVibor.SetActive(true);
        if (Global.OnlineMode)
        {
            DataTable table = Tabel(new SqlDataAdapter("SELECT        IdGruppa FROM            dbo.Student WHERE         (IdStudent = " + Global.IDUser + ") ", sqlConnection));
            table = Tabel(new SqlDataAdapter("SELECT        IDOpit, Activ FROM            dbo.Dostyp WHERE        (IDGruppa = " + table.Rows[0][0].ToString().Replace(" ","") + ") ", sqlConnection));
            for(int i = 0; i< table.Rows.Count; i++)
            {
                Debug.Log(int.Parse(table.Rows[i][0].ToString().Replace(" ", "")) - 1);
                Debug.Log(!bool.Parse(table.Rows[i][1].ToString().Replace(" ", "")));
                Pnl[int.Parse(table.Rows[i][0].ToString().Replace(" ", "")) - 1].SetActive(!bool.Parse(table.Rows[i][1].ToString().Replace(" ", "")));
            }
        }


    }
    public void ExitProgram()
    {
        Application.Quit();
    }
    public void LoadOpit8()
    {
        SceneManager.LoadScene("opit 8");
    }
    public void LoadOpit7()
    {
        SceneManager.LoadScene("opit 7");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    DataTable Tabel(SqlDataAdapter adapter)
    {
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;

    }
}
