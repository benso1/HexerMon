using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Monster[] monsters;
    public Sprite playerSprite;
    public string nickname;
    Player(Sprite playerPic, string nick){
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
    public int NextAlive(){
        for(int i = 0; i < 6; i++){
            if(monsters[i].hp > 0){
                return i;
            }
        }
        return -1;
    }
    public Monster NextMonster(){
        int monNum = NextAlive();
        if(monNum > 0){
            return monsters[monNum];
        }
        return null;
    }
}