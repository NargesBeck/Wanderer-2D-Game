using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger...");
    }
}
