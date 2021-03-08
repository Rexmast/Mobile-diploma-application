using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableControler : MonoBehaviour
{
    public Dropdown[] ViborVariant = new Dropdown[6];
    public double balplus=0.16;
    public double tempbal = 0.04;
    public void Rezult()
    {
       if(ViborVariant[0].captionText.text.ToString() == "Оранжевый")
        {
            tempbal += balplus;
        }
        if (ViborVariant[1].captionText.text.ToString() == "Красный")
        {
            tempbal += balplus;
        }
        if (ViborVariant[2].captionText.text.ToString() == "Оранжевый")
        {
            tempbal += balplus;
        }
        if (ViborVariant[3].captionText.text.ToString() == "Розовый")
        {
            tempbal += balplus;
        }
        if (ViborVariant[4].captionText.text.ToString() == "Бесцветный")
        {
            tempbal += balplus;
        }
        if (ViborVariant[5].captionText.text.ToString() == "Бесцветный")
        {
            tempbal += balplus;
        }
        Global.Bal += tempbal;
        Debug.Log(tempbal);
    }

}
