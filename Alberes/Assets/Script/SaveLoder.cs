using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using UnityEngine;

public class SaveLoder : MonoBehaviour
{
    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DiplimMDA.mssql.somee.com;Persist Security Info=True;User ID=Rexmast_SQLLogin_1;Password=9oven62qtd");
    [SerializeField]
    GameObject[] Step;
    [SerializeField]
    int Opit;
    void Start()
    {
        
    }
    DataTable Tabel(SqlDataAdapter adapter)
    {
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;
    }
    void loadSave()
    {
        DataTable table = Tabel(new SqlDataAdapter("SELECT NameGruppa FROM dbo.Gruppa", sqlConnection));
        if (table.Rows.Count != 0)
        {

        }
    }
}
