using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{   
    public GameObject DeathVFXPrefab;
    int trapsLayer;
   public bool death=false;
    void Start()
    {
        trapsLayer = LayerMask.NameToLayer("Trap");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == trapsLayer&&!death)
        {
            death = true;
            Audiomanager.PlayDeathAudio();
            Instantiate(DeathVFXPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);           
            GameManager.instance.playerdied();
            GameManager.instance.orbs.Clear();
          
        }
    }
    
}
