using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsSetings;
    public GameObject buttonsVibor;
    
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
}
