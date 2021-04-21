using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Controler : MonoBehaviour
{
    bool MouseDown = false;
    protected Collider2D collis;
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
    public virtual void TrueRezultOpit()
    {
        //GameObject Rezult = (GameObject)Instantiate(AnimationTrue);
        //Rezult.transform.position = transform.position;
    }
    public virtual void FalseRezultOpit()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collis = collision;
        //if (MouseDown)
        //{
        //    Debug.Log("актив");
        //    Debug.Log(this.transform.position.x);
        //    Debug.Log(this.transform.position.y);
        //    Debug.Log("Кализия");
        //    Debug.Log(collision.gameObject.transform.position.x);
        //    Debug.Log(collision.gameObject.transform.position.y);
        //}
        //else
        //{
        //    Debug.Log("не актив");
        //    Debug.Log(this.transform.position.x);
        //    Debug.Log(this.transform.position.y);
        //    Debug.Log("Кализия");
        //    Debug.Log(collision.gameObject.transform.position.x);
        //    Debug.Log(collision.gameObject.transform.position.y);
        //}

        if (this.transform.position.x > -1.5 && this.transform.position.x < 1.5 && this.transform.position.y > -4 && this.transform.position.y < -1 && collision.gameObject.transform.position.x > -1.5 && collision.gameObject.transform.position.x < 1.5 && collision.gameObject.transform.position.y > -4 && collision.gameObject.transform.position.y < -1)
            if (MouseDown)
                if (collision.gameObject.CompareTag("truee") && index == 1)
                {

                    TrueRezultOpit();
                    MouseDown = false;
                    StartPost();
                }
                else
                {
                    FalseRezultOpit();
                    GameObject Boom = (GameObject)Instantiate(AnimationFalse);
                    Boom.transform.position = transform.position;
                    MouseDown = false;
                    StartPost();
                }
            else
            {
                if (!collision.gameObject.CompareTag("truee") || index != 1)
                {
                    if (index != 1)
                        Destroy(this.gameObject, 1);
                }

                StartPost();
            }
    }

    private async void StartPost()
    {
        await Task.Delay(100);
        this.transform.position = StartPosition;
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
