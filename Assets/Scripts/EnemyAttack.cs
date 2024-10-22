using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int attackDamage = 25;

    PlayerHealth targetStrike;
    void Start()
    {
        targetStrike = FindObjectOfType<PlayerHealth>();
    }

    void AttackHitReturn()
    {
        if (targetStrike == null)
        {
            return;
        }
        else
        {
            targetStrike.PlayerTakesDamage(attackDamage);
            //targetStrike.GetComponent<DamagedIndicator>().ShowDamageUI(); //Grabs variable as reference to the gameobject its attached to (the player),
                                                                          // and grabs the DamagedIndicator component to access the canvas.
        }
    }
}
