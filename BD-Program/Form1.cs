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
        bool TestTextBox(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        DataTable Tabel(SqlDataAdapter adapter)
        {
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Student]([IdGruppa],[Name],[Famil],[Otchestvo],[Password]) VALUES (" + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(NameGruppa = N'" + comboBox1.Text + "')", sqlConnection)).Rows[0][0].ToString() + ", N'" + textBox3.Text + "', N'" + textBox4.Text + "', N'" + textBox5.Text + "', N'" + textBox6.Text + "')", sqlConnection);
            command.ExecuteNonQuery();
            UpdataStudent();
        }
        void UpdataStudent()
        {
            dataGridView1.DataSource = Tabel(new SqlDataAdapter("SELECT        dbo.Student.Name AS Имя, dbo.Student.Famil AS Фамилия, dbo.Student.Otchestvo AS Отчество, dbo.Student.Password AS Пароль, dbo.Gruppa.NameGruppa AS [Название группы],        dbo.Gruppa.TimePostypleniay AS [Год поступления] FROM            dbo.Gruppa INNER JOIN    dbo.Student ON dbo.Gruppa.IDGruppa = dbo.Student.IdGruppa", sqlConnection));
            DataTable table = Tabel(new SqlDataAdapter("SELECT        IdStudent FROM            dbo.Student", sqlConnection));
            IdManager = new int[table.Rows.Count];
            for (int i = 0; i < IdManager.Length; i++)
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
            if (comboBox4.Text != "")
                dataGridView3.DataSource = Tabel(new SqlDataAdapter("SELECT        dbo.Gruppa.NameGruppa AS Группа, dbo.Student.Famil AS Фамилия, dbo.Student.Name AS Имя, dbo.Student.Otchestvo AS Отчество, dbo.[Save].IDOpit AS [Номер опыта], dbo.[Save].Bal AS [Набраный бал],        dbo.[Save].Step AS [Этап прохождения] FROM            dbo.[Save] INNER JOIN  dbo.Student ON dbo.[Save].IDStudent = dbo.Student.IdStudent INNER JOIN  dbo.Gruppa ON dbo.Student.IdGruppa = dbo.Gruppa.IDGruppa WHERE     (dbo.Student.IdGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(NameGruppa = N'" + comboBox4.Text + "')", sqlConnection)).Rows[0][0].ToString() + ")", sqlConnection));

        }
        void UpdataDostup()
        {
            if (comboBox4.Text !="")
            dataGridView4.DataSource = Tabel(new SqlDataAdapter("SELECT        dbo.Gruppa.NameGruppa AS [Названи группы], dbo.Opit.IDOpit AS [Номер опыта], dbo.Dostyp.Activ AS Доступ FROM            dbo.Opit INNER JOIN     dbo.Dostyp ON dbo.Opit.IDOpit = dbo.Dostyp.IDOpit INNER JOIN    dbo.Gruppa ON dbo.Dostyp.IDGruppa = dbo.Gruppa.IDGruppa WHERE        (dbo.Dostyp.IDGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(NameGruppa = N'" + comboBox4.Text + "')", sqlConnection)).Rows[0][0].ToString() + ")", sqlConnection));
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            Console.WriteLine(dataGridView4[2, dataGridView4.CurrentRow.Index].Value.ToString());
            Console.WriteLine(Kastl(dataGridView4[2, dataGridView4.CurrentRow.Index].Value.ToString()).ToString());
            SqlCommand command = new SqlCommand("UPDATE[dbo].[Dostyp] SET[Activ] = " + Kastl(dataGridView4[2, dataGridView4.CurrentRow.Index].Value.ToString()).ToString() + " WHERE(IDGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(NameGruppa = N'" + comboBox4.Text + "')", sqlConnection)).Rows[0][0].ToString() + ") AND (IDOpit = " + dataGridView4[1, dataGridView4.CurrentRow.Index].Value.ToString() + ")", sqlConnection);
            command.ExecuteNonQuery();
            UpdataDostup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TestTextBox(textBox1) || TestTextBox(textBox2)) { MessageBox.Show("Заполните поля ввода", "Сообщение ошибки", MessageBoxButtons.OK); goto end; }
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Gruppa]([NameGruppa],[TimePostypleniay]) VALUES(N'" + textBox1.Text + "'," + textBox2.Text + ")", sqlConnection);

            command.ExecuteNonQuery();
            for (int i = 0; i < 8; i++)
            {

                command = new SqlCommand("INSERT INTO [dbo].[Dostyp] ([IDGruppa],[IDOpit],[Activ]) VALUES(N'" + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(TimePostypleniay = " + textBox2.Text + ") AND(NameGruppa = N'" + textBox1.Text + "')", sqlConnection)).Rows[0][0].ToString() + "'," + (i + 1) + ",0)", sqlConnection);


                command.ExecuteNonQuery();


            }
            UpdataGruppa();
            UpdataStudent();
        end:;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DataTable dataTable = Tabel(new SqlDataAdapter("SELECT COUNT(*) AS Expr FROM dbo.Student WHERE(IdGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(TimePostypleniay = " + dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString() + ") AND(NameGruppa = N'" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString() + ") ", sqlConnection));
            if (Convert.ToInt32(dataTable.Rows[0][0].ToString()) >= 1)
            {
                DialogResult result = MessageBox.Show("Для удаление группы необходимо удалить учеников группы, которых " + dataTable.Rows[0][0].ToString(), "Сообщение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Student] WHERE IDGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(TimePostypleniay = " + dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString() + ") AND(NameGruppa = N'" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString() + " ", sqlConnection);
                    command.ExecuteNonQuery();

                }
                if (result == DialogResult.No)
                {
                    goto end;
                }
            }
            DialogResult res = MessageBox.Show("Вы действительно хотите удалить группу? " + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString(), "Сообщение", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Dostyp] WHERE IDGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(TimePostypleniay = " + dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString() + ") AND(NameGruppa = N'" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString() + " ", sqlConnection);
                command.ExecuteNonQuery();
                command = new SqlCommand("DELETE FROM [dbo].[Gruppa] WHERE IDGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(TimePostypleniay = " + dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString() + ") AND(NameGruppa = N'" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString() + " ", sqlConnection);
                command.ExecuteNonQuery();

            }
            if (res == DialogResult.No)
            {
                goto end;
            }
            UpdataGruppa();
            UpdataStudent();
        end:;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (TestTextBox(textBox1) || TestTextBox(textBox2)) { MessageBox.Show("Заполните поля ввода", "Сообщение ошибки", MessageBoxButtons.OK); goto end; }
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Gruppa] SET [NameGruppa] =N'" + textBox1.Text + "'  ,[TimePostypleniay] = " + textBox2.Text + " WHERE IDGruppa = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(TimePostypleniay = " + dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString() + ") AND(NameGruppa = N'" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString() + " ", sqlConnection);
            command.ExecuteNonQuery();
            UpdataGruppa();
            UpdataStudent();
        end:;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            DataTable table = Tabel(new SqlDataAdapter("SELECT        NameGruppa FROM            dbo.Gruppa", sqlConnection));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i][0].ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Student] SET [IdGruppa] = " + Tabel(new SqlDataAdapter("SELECT IDGruppa FROM dbo.Gruppa WHERE(NameGruppa = N'" + comboBox1.Text + "')", sqlConnection)).Rows[0][0].ToString() + " ,[Name] =N'" + textBox3.Text + "' ,[Famil] = N'" + textBox4.Text + "' ,[Otchestvo] = N'" + textBox4.Text + "' ,[Password] = N'" + textBox5.Text + "' WHERE IdStudent = " + Tabel(new SqlDataAdapter("SELECT        IdStudent FROM            dbo.Student WHERE        (Name = N'" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + "') AND (Famil = N'" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() + "') AND (Otchestvo = N'" + dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString() + "') AND (Password = N'" + dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString(), sqlConnection);
            command.ExecuteNonQuery();
            UpdataStudent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Save] WHERE IdStudent = " + Tabel(new SqlDataAdapter("SELECT        IdStudent FROM            dbo.Student WHERE        (Name = N'" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + "') AND (Famil = N'" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() + "') AND (Otchestvo = N'" + dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString() + "') AND (Password = N'" + dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString() + " ", sqlConnection);
            command.ExecuteNonQuery();
            command = new SqlCommand("DELETE FROM dbo.Student WHERE IdStudent = " + Tabel(new SqlDataAdapter("SELECT        IdStudent FROM            dbo.Student WHERE        (Name = N'" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + "') AND (Famil = N'" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() + "') AND (Otchestvo = N'" + dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString() + "') AND (Password = N'" + dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString() + "')", sqlConnection)).Rows[0][0].ToString() + " ", sqlConnection);
            command.ExecuteNonQuery();
            UpdataStudent();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            DataTable table = Tabel(new SqlDataAdapter("SELECT        NameGruppa FROM            dbo.Gruppa", sqlConnection));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox4.Items.Add(table.Rows[i][0].ToString());
            }
            UpdataDostup();
            UpdataSave();
        }

       
        int Kastl(string s)
        {
            if (s == "True")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Save] WHERE IdStudent = " + Tabel(new SqlDataAdapter("SELECT        IdStudent FROM            dbo.Student WHERE        (Name = N'" + dataGridView3[2, dataGridView3.CurrentRow.Index].Value.ToString() + "') AND (Famil = N'" + dataGridView3[1, dataGridView3.CurrentRow.Index].Value.ToString() + "') AND (Otchestvo = N'" + dataGridView3[3, dataGridView3.CurrentRow.Index].Value.ToString() + "') ", sqlConnection)).Rows[0][0].ToString() + " ", sqlConnection);
            command.ExecuteNonQuery();
            UpdataSave();
        }
    }
}
