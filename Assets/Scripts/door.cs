using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    Animator anim;
    int openID;
    void Start()
    {
        anim = GetComponent<Animator>();
        openID = Animator.StringToHash("Open");
        GameManager.instance.registerdoor(this);
    }

    // Update is called once per frame
   public void open()
    {
        anim.SetTrigger(openID);
        Audiomanager.Startdoor();
    }
}
