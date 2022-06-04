using System;
using System.Collections;
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

    public int health { get; private set; }

    private enum Damage
    {
        BadStuff = 30, Walls = 5
    }

    private bool canBeDamaged = true;

    public Action OnBeingDamaged;

    private void Awake()
    {
        health = 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BadStuff")
            CauseDamage(Damage.BadStuff);
        else if (collision.tag == "Walls")
            CauseDamage(Damage.Walls);
    }

    private void CauseDamage(Damage damage)
    {
        if (!canBeDamaged)
            return;

        canBeDamaged = false;
        health -= (int)damage;

        if (OnBeingDamaged != null)
            OnBeingDamaged();
        StartCoroutine(PostDamageImmortality());
    }

    private IEnumerator PostDamageImmortality()
    {
        yield return new WaitForSeconds(0.5f);
        canBeDamaged = true;
    }
}