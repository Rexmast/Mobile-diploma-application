using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Opit8Controler : Controler
{
    public GameObject ElementON;
    public int TimePerecluch;
    public GameObject ActivetObject;
    public bool MoreElement = false;
    Opit8Controler Opit8Controlerr;
    public int XOpzition = 0;
    public void MenuON()
    {
        ElementON.SetActive(true);
    }
    public override void TrueRezultOpit()
    {
        if (MoreElement)
        {
            ActivetObject.SetActive(true);
            Global.k--;
            GameObject Rezult = (GameObject)Instantiate(AnimationTrue);
            Rezult.transform.position = transform.TransformVector(XOpzition, -8, 0);
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
            Rezult.transform.position = transform.TransformVector(XOpzition, -8, 0);
            Invoke(nameof(MenuON), TimePerecluch);
        }
    }
    public override void FalseRezultOpit()
    {
        if (MoreElement)
        {
            if (base.collis.gameObject.CompareTag("obl"))
            {
                Opit8Controlerr = base.collis.gameObject.GetComponent<Opit8Controler>();
                Opit8Controlerr.TrueRezultOpit();
            }
            else
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

