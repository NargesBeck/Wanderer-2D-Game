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

    public bool canMove
    {
        get
        {
            return canBeDamaged;
        }
    }

    private enum Damage
    {
        BadStuff = 30, Walls = 100
    }

    private bool canBeDamaged = true;

    public Action OnBeingDamaged;
    public Action OnLevelWon;
    public Action OnLevelLost;

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
        else if (collision.tag == "FinishLine")
            if (OnLevelWon != null)
                OnLevelWon();
    }

    private void CauseDamage(Damage damage)
    {
        if (!canBeDamaged)
            return;

        canBeDamaged = false;
        health -= (int)damage;

        if (OnBeingDamaged != null)
            OnBeingDamaged();

        if (DidPlayerLose() && OnLevelLost != null)
            OnLevelLost();

        StartCoroutine(PostDamageImmortality());
    }

    private IEnumerator PostDamageImmortality()
    {
        yield return new WaitForSeconds(0.5f);
        canBeDamaged = true;
    }

    private bool DidPlayerLose()
    {
        return health <= 0;
    }
}