using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    GameObject[] PanelRezult = new GameObject[1];
    [SerializeField]
    GameObject EndBatton;
    [SerializeField]
    GameObject NextBatton;
    [SerializeField]
    GameObject ConditionBatton;
    [SerializeField]
    GameObject ResultBatton;
    [SerializeField]
    Text Condition;
    [SerializeField]
    Text Result;
    [SerializeField]
    GameObject Viseble;


    public void ClikHelp()
    {
        if (!Global.ActivRezult)
            if (Global.ActivHelp)
            {
                PanelHelp[Global.TempHelpPanel].SetActive(false);
                Global.ActivHelp = false;
                PanelElement[Global.TempHelpPanel].SetActive(true);
                Condition.text = "Условие задания";
                Viseble.SetActive(true);
            }
            else
            {
                PanelHelp[Global.TempHelpPanel].SetActive(true);
                Global.ActivHelp = true;
                PanelElement[Global.TempHelpPanel].SetActive(false);
                Condition.text = "Закрыть условие задания";
                Viseble.SetActive(false);
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
                Result.text = "Результаты опыта";
                Viseble.SetActive(true);
            }
            else
            {
                PanelRezult[Global.TempHelpPanel].SetActive(true);
                Global.ActivRezult = true;
                PanelElement[Global.TempHelpPanel].SetActive(false);
                Result.text = "Закрыть результаты опыта";
                Viseble.SetActive(false);
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
        ElementGroop[Global.TempHelpPanel].SetActive(false);
        Global.TempHelpPanel++;
        if (Global.TempHelpPanel == PanelHelp.Length)
               {
                    ConditionBatton.SetActive(false);
                    ResultBatton.SetActive(false);
            }
            ElementGroop[Global.TempHelpPanel].SetActive(true);
        if (Global.TempHelpPanel == ElementGroop.Length - 1)
        {
            EndBatton.SetActive(true);
            Global.TempHelpPanel = 0;
        }
        if (OFF) { NextBatton.SetActive(false); }

        
    }
   
}
