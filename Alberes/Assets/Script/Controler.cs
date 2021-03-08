using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    bool MouseDown = false;
    
    public int index;
    protected Vector3 StartPosition;
    [SerializeField]
    protected Object AnimationFalse;
    [SerializeField]
    protected Object AnimationTrue;
    void Start()
    {
        StartPosition = GetComponent<Transform>().position;
    }
    void OnMouseDown()
    {
        MouseDown = true;
    }
    void OnMouseUp()
    {
        MouseDown = false;
    }
    public virtual void  TrueRezultOpit()
    {
        GameObject Rezult = (GameObject)Instantiate(AnimationTrue);
        Rezult.transform.position = transform.position;
    }
    public virtual void FalseRezultOpit()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MouseDown)
            if (collision.gameObject.CompareTag("truee") && index == 1)
            {
                TrueRezultOpit();
                
            }
            else
            {
                FalseRezultOpit();
                GameObject Boom = (GameObject)Instantiate(AnimationFalse);
                Boom.transform.position = transform.position;
                MouseDown = false;
                this.transform.position = StartPosition;
                
            }
        else
        {
            if (!collision.gameObject.CompareTag("truee") || index != 1)
            {
                this.transform.position = StartPosition;
            }
        }
        
    }
    void Update()
    {
        Vector2 cursor = Input.mousePosition;
        cursor = Camera.main.ScreenToWorldPoint(cursor);
        if (MouseDown)
        {
            this.transform.position = cursor;
        }
    }
}
