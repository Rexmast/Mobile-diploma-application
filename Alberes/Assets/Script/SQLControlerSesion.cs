using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class SQLControlerSesion : MonoBehaviour
{
    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DiplimMDA.mssql.somee.com;Persist Security Info=True;User ID=Rexmast_SQLLogin_1;Password=9oven62qtd");
    private void Start()
    {
        
        sqlConnection.Open();
        Click();
    }
    //for (int i = 0; i < table.Rows.Count;i++)
    //Debug.Log("Опыт : " + table.Rows[i][0].ToString() + "Название : "+ table.Rows[i][1].ToString());
    DataTable Tabel(SqlDataAdapter adapter)
    {
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;
    }
    private void Click()
    {
       DataTable table =  Tabel(new SqlDataAdapter("SELECT  * from Opit", sqlConnection));
    }
}
