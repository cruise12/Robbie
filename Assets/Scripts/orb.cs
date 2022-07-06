using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour
{
    int player;
    public GameObject explosion;
    void Start()
    {
        player = LayerMask.NameToLayer("player");
        GameManager.instance.registerorb(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == player)
        {  
            Audiomanager.playOrbAudio();
            Instantiate(explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
            GameManager.instance.orbgrapp(this);
        }
    }
}
