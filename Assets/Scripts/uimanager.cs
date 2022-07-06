using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class uimanager : MonoBehaviour
{
    public static uimanager Uimanager;
    public TextMeshProUGUI Deathtext, gameover, orbText, TimeText;
    public void Awake()
    {
        if (Uimanager != null)
        {
            Destroy(gameObject);
            return;
        }
        Uimanager = this;
        DontDestroyOnLoad(gameObject);
    }
    public static void UpdateOrbUi(int orbcount)
    {
        Uimanager.orbText.text = orbcount.ToString();
    }
   public static void gameoverT()
    {
        Uimanager.gameover.enabled = true;
    }
}
