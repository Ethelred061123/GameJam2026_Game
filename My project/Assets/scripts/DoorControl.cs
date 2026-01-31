using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public int doorId;
    public float rotateSpeed;
    private Animator animator;
    private bool isOpen = false;
    private bool kai = false;
    public float coolTime = 0.5f;
    private float lastTriggerTime = -0.5f;

    public int OpenDoorControlID;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (animator.GetBool("Isplay") || Time.time - lastTriggerTime < coolTime)
        {
            return;
        }

        if (!kai)
        {
            if (isOpen == false)
            {
                OpenUp();
                isOpen = true;
                Debug.Log("open");
                kai = true;
            }
            else if (isOpen == true)
            {
                OpposeOp();
                isOpen = false;
                Debug.Log("close");
                kai = true;

            }
        }
        else
        {
            if (isOpen == true )
            {
                OpenDown();
                isOpen = true;
                Debug.Log("Oppopen");
                kai = false;

            }
            else if (isOpen == false)
            {
                OpposeClose();
                isOpen = false;
                kai = false;
            }
        }
        lastTriggerTime = Time.time;
        OnAnimFinish();
    }


    public void OpenUp()
    {
        animator.SetTrigger("Open");
        animator.SetBool("Isplay", true);
    }
    public void OpenDown()
    {
        animator.SetTrigger("Close");
        animator.SetBool("Isplay", true);
    }
    public void OpposeOp()
    {
        animator.SetTrigger("OpposeOpen");
        animator.SetBool("Isplay", true);
    }
    public void OpposeClose()
    {
        animator.SetTrigger("OpposeClose");
        animator.SetBool("Isplay", true);
    }
    public void OnAnimFinish()
    {
        animator.SetBool("Isplay", false);
        Debug.Log("动画结束，可再次触发");
    }

}
