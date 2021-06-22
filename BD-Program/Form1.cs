using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BD_Program
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DiplimMDA.mssql.somee.com;Persist Security Info=True;User ID=Rexmast_SQLLogin_1;Password=9oven62qtd");
        int[] IdManager;
        public Form1()
        {
            sqlConnection.Open();
            InitializeComponent();
            UpdataStudent();
            UpdataGruppa();
            UpdataSave();
            UpdataDostup();
        }
        DataTable Tabel(SqlDataAdapter adapter)
        {
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        void UpdataStudent()
        {
            dataGridView1.DataSource = Tabel(new SqlDataAdapter("SELECT        dbo.Student.Name AS Имя, dbo.Student.Famil AS Фамилия, dbo.Student.Otchestvo AS Отчество, dbo.Student.Password AS Пароль, dbo.Gruppa.NameGruppa AS [Название группы],        dbo.Gruppa.TimePostypleniay AS [Год поступления] FROM            dbo.Gruppa INNER JOIN    dbo.Student ON dbo.Gruppa.IDGruppa = dbo.Student.IdGruppa", sqlConnection));
            DataTable table = Tabel(new SqlDataAdapter("SELECT        IdStudent FROM            dbo.Student", sqlConnection));
            IdManager = new int[table.Rows.Count];
            for(int i =0; i< IdManager.Length; i++)
            {
                IdManager[i] = int.Parse(table.Rows[i][0].ToString()); 
            }
        }
        void UpdataGruppa()
        {
            dataGridView2.DataSource = Tabel(new SqlDataAdapter("SELECT        NameGruppa AS Название, TimePostypleniay AS [Учебный год] FROM            dbo.Gruppa", sqlConnection));
        }
        void UpdataSave()
        {
            dataGridView3.DataSource = Tabel(new SqlDataAdapter("SELECT        dbo.Gruppa.NameGruppa AS Группа, dbo.Student.Famil AS Фамилия, dbo.Student.Name AS Имя, dbo.Student.Otchestvo AS Отчество, dbo.[Save].IDOpit AS [Номер опыта], dbo.[Save].Bal AS [Набраный бал],        dbo.[Save].Step AS [Этап прохождения] FROM            dbo.[Save] INNER JOIN  dbo.Student ON dbo.[Save].IDStudent = dbo.Student.IdStudent INNER JOIN  dbo.Gruppa ON dbo.Student.IdGruppa = dbo.Gruppa.IDGruppa", sqlConnection));
            
        }
        void UpdataDostup()
        {
            dataGridView4.DataSource = Tabel(new SqlDataAdapter("SELECT        dbo.Gruppa.NameGruppa AS Название, dbo.Dostyp.IDOpit AS [Номер опыта], dbo.Dostyp.Activ AS Состояние FROM            dbo.Dostyp INNER JOIN           dbo.Gruppa ON dbo.Dostyp.IDGruppa = dbo.Gruppa.IDGruppa", sqlConnection));
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            // обновлене таблицы разрешени по нажатию мыши
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Gruppa]([NameGruppa],[TimePostypleniay]) VALUES(N'"+textBox1.Text+"',"+textBox2.Text+")", sqlConnection);
            command.ExecuteNonQuery();
            UpdataGruppa();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            // сделать проверку на наличие записи в других таблица и ток потом удалять, и выбор одной строки 
           SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Gruppa] WHERE IDGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(TimePostypleniay = "+ dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString() + ") AND(NameGruppa = N'"+ dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString() + " ", sqlConnection);
           command.ExecuteNonQuery();
            UpdataGruppa();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Gruppa] SET [NameGruppa] =N'" + textBox1.Text + "'  ,[TimePostypleniay] = " + textBox2.Text + " WHERE IDGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(TimePostypleniay = " + dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString() + ") AND(NameGruppa = N'" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString() + " ", sqlConnection);
            command.ExecuteNonQuery();
            UpdataGruppa();
        }
    }
}
