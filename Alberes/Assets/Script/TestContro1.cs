using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestContro1 : MonoBehaviour
{
    public Toggle[] ArreaToggleTrue;
    public double BalPlus;
    public void Proverka()
    {
        for (int i = 0; i < ArreaToggleTrue.Length; i++)
        {
            if (ArreaToggleTrue[i].isOn)
                Global.Bal += BalPlus;
        }
        Debug.Log(Global.Bal);
    }

}
