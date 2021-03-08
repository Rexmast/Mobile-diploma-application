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
    GameObject[] PanelZoomObjectIN = new GameObject[1];
    [SerializeField]
    GameObject[] PanelZoomObjectOUT = new GameObject[1];
    [SerializeField]
    GameObject[] ElementGroop = new GameObject[1];
    [SerializeField]
    GameObject[] ObjectON = new GameObject[1];
    [SerializeField]
    GameObject[] ObjectOFF = new GameObject[1];
    [SerializeField]
    GameObject[] PanelRezult = new GameObject[1];
    [SerializeField]
    GameObject EndBatton;
    [SerializeField]
    GameObject NextBatton;


    public void ClikHelp()
    {
        if (!Global.ActivRezult)
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
        if (!Global.ActivHelp)
            if (Global.ActivRezult)
            {
                PanelRezult[Global.TempHelpPanel].SetActive(false);
                Global.ActivRezult = false;
                PanelElement[Global.TempHelpPanel].SetActive(true);
            }
            else
            {
                PanelRezult[Global.TempHelpPanel].SetActive(true);
                Global.ActivRezult = true;
                PanelElement[Global.TempHelpPanel].SetActive(false);
            }
    }
    public void Clikzoom(int ZoomObject)
    {
        if (Global.ActivZoom)
        {
            PanelZoomObjectIN[ZoomObject].SetActive(false);
            Global.ActivZoom = false;
            PanelZoomObjectOUT[ZoomObject].SetActive(true);
        }
        else
        {
            PanelZoomObjectIN[ZoomObject].SetActive(true);
            Global.ActivZoom = true;
            PanelZoomObjectOUT[ZoomObject].SetActive(false);
        }
    }
    public void Next(bool OFF)
    {
        for (int i = 0; i < ObjectOFF.Length; i++)
        {
            ObjectOFF[i].SetActive(false);
        }
        ElementGroop[Global.TempHelpPanel].SetActive(false);
        Global.TempHelpPanel++;
        ElementGroop[Global.TempHelpPanel].SetActive(true);
        if (Global.TempHelpPanel == ElementGroop.Length - 1)
        {
            EndBatton.SetActive(true);
            Global.TempHelpPanel = 0;
        }
        for (int i = 0; i < ObjectON.Length; i++)
        {
            ObjectON[i].SetActive(true);
        }
        if (OFF) { NextBatton.SetActive(false); }
    }
}
