using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public string turn = "Player";
    public PlayerSpells playerSpells;

    public void Update()
    {
        if (turn == "Player")
        {
            // je peux appeller les spells du joueur
            playerSpells.Normal_Attack();

            turn = "Enemy";
        }
        else
        {
            
        }
    }
}
