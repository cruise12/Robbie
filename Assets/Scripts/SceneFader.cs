using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
   Animator ani;
    int faderID;
    private void Start()
    {
        ani = GetComponent<Animator>();
        faderID = Animator.StringToHash("Fade");
        GameManager.RegisterSceneFader(this);
    }
     public void  FadeOut()
    {
        ani.SetTrigger(faderID);
    }
}
