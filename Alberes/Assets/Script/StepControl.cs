using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepControl : MonoBehaviour
{
    [SerializeField]
    GameObject[] PanelHelp = new GameObject[1];
    [SerializeField]
    GameObject[] PanelElement = new GameObject[1];
    [SerializeField]    
    GameObject[] PanelZoomObject = new GameObject[1];
    [SerializeField]
    GameObject[] ElementGroop = new GameObject[1];
    [SerializeField]
    GameObject[] ObjectON = new GameObject[1];
    [SerializeField]
    GameObject[] ObjectOFF = new GameObject[1];
    [SerializeField]
    GameObject PanelRezult;
    [SerializeField]
    GameObject EndBatton;


    public void ClikHelp()
    {
        if (Global.ActivHelp)
        {
            PanelHelp[Global.TempHelpPanel].SetActive(false);
            Global.ActivHelp = false;
            PanelElement[Global.TempHelpPanel].SetActive(true);
        }
        else
        {
            PanelHelp[Global.TempHelpPanel].SetActive(true);
            Global.ActivHelp = true;
            PanelElement[Global.TempHelpPanel].SetActive(false);
        }
    }
    public void ClikRezult()
    {
        if (Global.ActivRezult)
        {
            PanelRezult.SetActive(false);
            Global.ActivRezult = false;
            PanelElement[Global.TempHelpPanel].SetActive(true);
        }
        else
        {
            PanelRezult.SetActive(true);
            Global.ActivRezult = true;
            PanelElement[Global.TempHelpPanel].SetActive(false);
        }
    }
    public void Clikzoom(int ZoomObject)
    {
        if (Global.ActivZoom)
        {
            PanelZoomObject[ZoomObject].SetActive(false);
            Global.ActivZoom = false;
            PanelElement[Global.TempHelpPanel].SetActive(true);
        }
        else
        {
            PanelZoomObject[ZoomObject].SetActive(true);
            Global.ActivZoom = true;
            PanelElement[Global.TempHelpPanel].SetActive(false);
        }
    }
    public void Next()
    {
         for (int i = 0; i < ObjectOFF.Length; i++)
         {
                ObjectOFF[i].SetActive(false);
        }
        ElementGroop[Global.TempHelpPanel].SetActive(false);
        Global.TempHelpPanel++;
        if (Global.TempHelpPanel > PanelElement.Length) {
            EndBatton.SetActive(true);
        }
        ElementGroop[Global.TempHelpPanel].SetActive(true);
        for (int i = 0; i < ObjectON.Length; i++)
        {
            ObjectON[i].SetActive(true);
        }

    }
}
