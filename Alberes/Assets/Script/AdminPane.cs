using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminPane : MonoBehaviour
{
  public void SaveClear()
    {
        PlayerPrefs.DeleteAll();
    }
}
