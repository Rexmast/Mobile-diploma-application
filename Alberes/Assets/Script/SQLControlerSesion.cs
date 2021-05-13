using System.Data;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class SQLControlerSesion : MonoBehaviour
{
    [SerializeField]
     GameObject PanelQuestionDevase;
    [SerializeField]
   GameObject MenuSing;
    [SerializeField]
     Dropdown DropdownISPanelQuestionDevase;
    [SerializeField]
     Dropdown DropdownStudent;
    [SerializeField]
    GameObject Menu;
    [SerializeField]
    GameObject ErrorPanel;

    [SerializeField]
    Text TextDropdown;
    [SerializeField]
    Text TextFieldLastName;
    [SerializeField]
    Text TextFieldFazerName;
    [SerializeField]
    Text TextFieldSurName;
    [SerializeField]
    Text TextFieldPassword;
    [SerializeField]
    Text TextFieldPasswordSing;
    [SerializeField]
    Text TextDropdownStudent;
    [SerializeField]
    Text ErrorText;
    



    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DiplimMDA.mssql.somee.com;Persist Security Info=True;User ID=Rexmast_SQLLogin_1;Password=9oven62qtd");
    private void Start()
    {
        sqlConnection.Open();
        Chec();


    }
  
    public void LoadingGroups()
    {
        DataTable table = Tabel(new SqlDataAdapter("SELECT NameGruppa FROM dbo.Gruppa", sqlConnection));
        for (int i = 0; i < table.Rows.Count; i++)
            DropdownISPanelQuestionDevase.options.Add(new Dropdown.OptionData(table.Rows[i][0].ToString()));
    }
    DataTable Tabel(SqlDataAdapter adapter)
    {
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;
    }
    private void Chec()
    {
        if (PlayerPrefs.HasKey("UsingModel"))
        {
            LoadingSing();
        }
        else
        {
            PanelQuestionDevase.SetActive(true);
        }
    }
    public void ViborusingModel(bool yesno)
    {
        if (yesno)
        {
            PlayerPrefs.SetInt("UsingModel", 1);

        }
        else
        {
            PlayerPrefs.SetInt("UsingModel", 0);

        }
        LoadingSing();
        PanelQuestionDevase.SetActive(false);
    }
    void LoadingSing()
    {
        if (PlayerPrefs.GetInt("UsingModel") == 0)
        {
            if (PlayerPrefs.HasKey("UserProfel") && PlayerPrefs.GetString("UserPasword") != null)
            {
                Global.UserPasword = PlayerPrefs.GetString("UserPasword");
                Global.IDUser = PlayerPrefs.GetInt("UserProfel");
                MenuSing.SetActive(false);
                Menu.SetActive(true);
            }
            else
            {
                MenuSing.SetActive(true);
                LoadingGroups();
            }
        }
        else
        {
            MenuSing.SetActive(true);
            LoadingGroups();
        }

    }
    public void LoadingStudent()
    {

        //проверка на аутизм значения DropdownISPanelQuestionDevase.captionText.ToString()

        if (TextDropdown.text == "") { ErrorMeseg("Пожалуйста выберите свою группу."); goto end; }

        DataTable table = Tabel(new SqlDataAdapter("SELECT dbo.Student.Name, dbo.Student.Famil, dbo.Student.Otchestvo FROM            dbo.Student INNER JOIN dbo.Gruppa ON dbo.Student.IdGruppa = dbo.Gruppa.IDGruppa WHERE(dbo.Gruppa.NameGruppa = N'" + TextDropdown.text + "')", sqlConnection)); //DF
        for (int i = 0; i < table.Rows.Count; i++)

            DropdownStudent.options.Add(new Dropdown.OptionData(table.Rows[i][0].ToString().Replace(" ","") + " " + table.Rows[i][1].ToString().Replace(" ", "") + " " + table.Rows[i][2].ToString().Replace(" ", ""))) ;
        end:;
    }
   public void Register()
    {
        //проверка на аутизм значений

        if(TextFieldSurName.text=="" || TextFieldLastName.text=="" || TextFieldFazerName.text=="" || TextFieldPassword.text == ""){ }

        if (TextFieldSurName.text == "") { ErrorMeseg("Поле для имени является пустым, пожалуйста заполните его."); goto end; }
        if (TextFieldLastName.text == "") { ErrorMeseg("Поле для фамилии является пустым, пожалуйста заполните его."); goto end; }
        if (TextFieldFazerName.text == "") { ErrorMeseg("Поле для отчества является пустым, пожалуйста заполните его."); goto end; }
        if (TextFieldPassword.text == "") { ErrorMeseg("Поле для пароля является пустым, пожалуйста заполните его."); goto end; }



        DataTable table = Tabel(new SqlDataAdapter(" SELECT        IDGruppa FROM            dbo.Gruppa WHERE(NameGruppa = N'" + TextDropdown.text + "')", sqlConnection));
        SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Student] ([IdGruppa] ,[Name] ,[Famil] ,[Otchestvo] ,[Password]) VALUES('" + table.Rows[0][0].ToString() + "',N'" + TextFieldSurName.text + "',N'"+ TextFieldLastName.text + "',N'"+ TextFieldFazerName.text + "',N'"+ TextFieldPassword.text + "')", sqlConnection);
        command.ExecuteNonQuery();
        table = Tabel(new SqlDataAdapter(" SELECT IdGruppa, Password FROM dbo.Student WHERE(Name = N'" + TextFieldSurName.text + "') AND(Famil = N'" + TextFieldLastName.text + "') AND(Otchestvo = N'" + TextFieldFazerName.text + "') AND(Password = N'" + TextFieldPassword.text + "')", sqlConnection));
        if (PlayerPrefs.GetInt("UsingModel") == 0)
        {
            PlayerPrefs.SetInt("UserProfel", int.Parse(table.Rows[0][0].ToString()));
            PlayerPrefs.SetString("UserPasword", table.Rows[0][1].ToString());
            

        }
        Global.UserPasword = table.Rows[0][1].ToString();
        Global.IDUser = int.Parse(table.Rows[0][0].ToString());
        MenuSing.SetActive(false);
        Menu.SetActive(true);
        end:;
    }
     public void Sing()
    {
        string NoStr, NotExt;
        NoStr = "Пароль не содержит символов, пожалуйста введите корректный пароль.";
        NotExt = "Пароль не совпал пажалуйста ведите другой пароль.";
        //проверка на аутизм значений +
        string[] TextDropdown1 = TextDropdownStudent.text.Split(' ');
       if (TextDropdownStudent.text == "") { goto NoPas; }
        DataTable table = Tabel(new SqlDataAdapter(" SELECT IdStudent, Password FROM dbo.Student WHERE(Name = N'" + TextDropdown1[0] + "') AND(Famil = N'" + TextDropdown1[1] + "') AND(Otchestvo = N'" + TextDropdown1[2] + "') AND(Password = N'" + TextFieldPasswordSing.text + "')", sqlConnection));
        if (table.Rows.Count != 0)
        {

            Global.UserPasword = table.Rows[0][1].ToString();
            Global.IDUser = int.Parse(table.Rows[0][0].ToString());
            MenuSing.SetActive(false);
            Menu.SetActive(true); 
            goto end;
        }
        else { goto NotExist; }
       
            NoPas:;
            ErrorMeseg(NoStr);
            goto end;

            NotExist:;
            ErrorMeseg(NotExt);
            goto end;

        //error

        end:;
    }
    void ErrorMeseg(string Show)
    {
        ErrorPanel.SetActive(true);
        ErrorText.text = Show;
    }
}
