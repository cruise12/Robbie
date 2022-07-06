using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winzone : MonoBehaviour
{
    public int player;
    void Start()
    {
        player = LayerMask.NameToLayer("player");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == player)
        {
            GameManager.Playwin();
        }
    }

}
