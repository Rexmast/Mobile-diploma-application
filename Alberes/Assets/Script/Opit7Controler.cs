using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Opit7Controler : Controler
{
    public GameObject ElementMenuOFF;
    public GameObject ElementMenuON;
    public int TimePerecluch;
    public bool MoreElement = false;
    public GameObject ActivetObject;
    public Opit7Controler Opit7Controlerr;
    public void MenuON()
    {
        ElementMenuON.SetActive(true);
    }
    public override void TrueRezultOpit()
    {
        if (MoreElement)
        {
            ActivetObject.SetActive(true);
            Global.k--;
            GameObject Rezult = (GameObject)Instantiate(AnimationTrue);
            Rezult.transform.position = transform.TransformVector(0, -8, 0);
            this.gameObject.SetActive(false);
            if (Global.k == 0)
            {
                Invoke(nameof(MenuON), TimePerecluch);
            }
        }
        else
        {
            ActivetObject.SetActive(true);
            GameObject Rezult = (GameObject)Instantiate(AnimationTrue);
           Rezult.transform.position = transform.TransformVector(0, -8, 0);
            Invoke(nameof(MenuON), TimePerecluch);
        }
    }
    public override void FalseRezultOpit() 
    {
        if (MoreElement)
        {
            if (base.collis.gameObject.CompareTag("obl"))
            {
                Opit7Controlerr = base.collis.gameObject.GetComponent<Opit7Controler>();
                Opit7Controlerr.TrueRezultOpit();
            }else
            {
                Global.ErrorCounter++;
                if (index != 1)
                    Destroy(this.gameObject, 1);
            }
            

        }
        else
        {
            Global.ErrorCounter++;
            if (index != 1)
                Destroy(this.gameObject, 1);
        }
    }
    

    }
