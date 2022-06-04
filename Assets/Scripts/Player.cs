using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player player;
    public static Player Instance
    {
        get
        {
            if (player == null)
                player = FindObjectOfType<Player>();
            return player;
        }
    }

    public int health = 100;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger...");
    }
}
