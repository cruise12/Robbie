using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
  public  List<orb> orbs;
   public int orbnums;
    door lockedDoor;
  public  bool isGAME;
    
    public SceneFader fader;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        orbs = new List<orb>();
    }
  
    public void registerdoor(door door)
    {
        instance.lockedDoor = door;
    }
    public void registerorb(orb orb)
    {
        
        if (!instance.orbs.Contains(orb))
        {
            instance.orbs.Add(orb);
        }
        uimanager.UpdateOrbUi(orbs.Count);
    }
    public void orbgrapp(orb orb)
    {
        instance.orbs.Remove(orb);
        if (instance.orbs.Count == 0)
        {
            instance.lockedDoor.open();
        }
        uimanager.UpdateOrbUi(orbs.Count);
    }
    public static void RegisterSceneFader(SceneFader obj)
    {
        instance.fader = obj;
    
    }
    public static void Playwin()
    {
        instance.isGAME = true;
        uimanager.gameoverT();
    }
    public static bool boolGame()
    {
        return instance.isGAME;
    }
    public  void playerdied()
    {
        instance.fader.FadeOut();
        instance.Invoke("RestartScene",1.5f);
        
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }
}
