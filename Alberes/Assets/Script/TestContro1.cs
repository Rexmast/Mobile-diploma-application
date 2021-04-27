using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestContro1 : MonoBehaviour
{
    public Toggle[] ArreaToggleTrue;
    public double BalPlus;
    public Toggle[] ArreaToggleFalse;
    public double BalMinus;
    public GameObject[] OOFElement;
    public GameObject[] ONElement;
    double BalTest;
    public GameObject Panel;
    public GameObject Baton;

    public void TryNext(bool tn)
    {
        if (tn)
        {
            Panel.SetActive(true);
            Baton.SetActive(false);
        }
        else
        {
            Panel.SetActive(false);
            Baton.SetActive(true);
        }

    }
    public void Proverka()
    {
        for (int i = 0; i < ArreaToggleTrue.Length; i++)
        {
            if (ArreaToggleTrue[i].isOn)
                BalTest += BalPlus;
        }
        for (int i = 0; i < ArreaToggleFalse.Length; i++)
        {
            if (ArreaToggleFalse[i].isOn)
                BalTest -= BalMinus;
        }
        if (BalTest > 0)
        {
            Global.Bal += BalTest;
        }
        Debug.Log(BalTest);
        Debug.Log(Global.Bal); 
    }
    public void NextTest()
    {
        for(int i = 0; i < OOFElement.Length; i++)
        {
            OOFElement[i].SetActive(false);
        }
        for (int i = 0; i < ONElement.Length; i++)
        {
            ONElement[i].SetActive(true);
        }
    }

   

}
