﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    public Door[] doors;
    public SignalListener enemyUpdate;

    // Start is called before the first frame update
   

    public void CheckEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i].gameObject.activeInHierarchy)
            {
                return;
            }
        }
        OpenDoors();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate all enemies and pots 
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], true);
            }
        }
        CloseDoors();
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Deactivate all enemies and pots 
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], false);
            }
        }
    }

    public void CloseDoors()
    {
        for(int i = 0; i< doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
    }
}
