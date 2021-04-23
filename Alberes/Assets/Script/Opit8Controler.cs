using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Opit8Controler : Controler
{
    public GameObject ElementON;
    public int TimePerecluch;
    public GameObject ActivetObject;
    public void MenuON()
    {
        ElementON.SetActive(true);
    }
    public override void TrueRezultOpit()
    {
        ActivetObject.SetActive(true);
        GameObject Rezult = (GameObject)Instantiate(AnimationTrue);
        Rezult.transform.position = transform.TransformVector(0, -8, 0);
        Invoke(nameof(MenuON), TimePerecluch);
    }
    public override void FalseRezultOpit()
    {
        Global.ErrorCounter++;
        if (index != 1)
            Destroy(this.gameObject, 1);
    }
}

