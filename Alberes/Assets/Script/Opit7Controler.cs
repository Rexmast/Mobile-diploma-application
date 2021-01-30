using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Opit7Controler : Controler
{
    public GameObject ElementMenuOFF;
    public GameObject ElementMenuON;
    public int TimePerecluch;
    
    public void MenuON()
    {
        ElementMenuON.SetActive(true);
    }
    public override void TrueRezultOpit()
    {
        Debug.Log("true");
        if (gameObject.CompareTag("Delite"))
        {
            Global.k--;
            Debug.Log(Global.k);
        }
        else
        {
            ElementMenuOFF.SetActive(false);
        }
        
        
        GameObject Rezult = (GameObject)Instantiate(AnimationTrue);
        Rezult.transform.position = transform.position;
        Invoke(nameof(MenuON), TimePerecluch);

    }
}
