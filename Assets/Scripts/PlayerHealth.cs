using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHP = 100;

    public void PlayerTakesDamage(int damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            GetComponent<GameOver>().HandleDeath();
        }
    }
}
