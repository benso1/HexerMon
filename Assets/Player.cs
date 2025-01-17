﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Monster[] monsters;
    public SpriteRenderer playerSprite;
    public string nickname;
    public Player(SpriteRenderer playerPic, string nick){
        playerSprite = playerPic;
        monsters = new Monster[6];
        nickname = nick;
    }
    public void AddStats(SpriteRenderer playerPic, string nick){
        playerSprite = playerPic;
        monsters = new Monster[6];
        nickname = nick;
    }
    public bool AcquireMonster(Monster monstrous, int slot){
        if(slot < 6 && slot >= 0){
            monsters[slot] = monstrous;
            return true;
        }
        return false;
    }
    public void GetMon(Monster monstrous){
        for(int i = 0; i < 6; i++){
            if(monsters[i] == null){
                monsters[i] = monstrous;
                break;
            }
        }
    }
    public int NextAlive(){
        for(int i = 0; i < 6; i++){
            if(monsters[i] == null){
                break;
            }
            if(monsters[i].hp > 0){
                return i;
            }
        }
        return -1;
    }
    public Monster NextMonster(){
        int monNum = NextAlive();
        if(monNum >= 0){
            return monsters[monNum];
        }
        return null;
    }
}