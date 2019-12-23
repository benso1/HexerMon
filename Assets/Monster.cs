using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int attack;
    public int defense;
    public int hp;
    public int speed;
    public int attackGrowth;
    public int defenseGrowth;
    public int hpGrowth;
    public int speedGrowth;
    public Sprite pic;
    public int type;
    public string nickname;
    public int level;
    public int exp;
    public Move[] moves;
    public Monster(int attackGrow, int defenseGrow, int hpGrow, int speedGrow, string nick, Sprite picture, int typeOf, int lvl){
        SetGrowth(attackGrow, defenseGrow, hpGrow, speedGrow);
        nickname = nick;
        pic = picture;
        type = typeOf;
        level = lvl;
        exp = 0;
        moves = new Move[4];
    }
    public int RandomNumber(){  
        Random random = new Random();  
        return Random.Range(0, 100);
    }
    public void SetGrowth(int attackGrow, int defenseGrow, int hpGrow, int speedGrow){
        int rand = RandomNumber();
        if(rand < 70){
            attackGrowth = attackGrow;
        }
        else if(rand < 85){
            attackGrowth = attackGrow - 1;
        }
        else{
            attackGrowth = attackGrow + 1;
        }

        if(attackGrowth < 1){
            attackGrowth = 1;
        }
        else if(attackGrowth > 5){
            attackGrowth = 5;
        }

        rand = RandomNumber();
        if(rand < 70){
            defenseGrowth = defenseGrow;
        }
        else if(rand < 85){
            defenseGrowth = defenseGrow - 1;
        }
        else{
            defenseGrowth = defenseGrow + 1;
        }

        if(defenseGrowth < 1){
            defenseGrowth = 1;
        }
        else if(defenseGrowth > 5){
            defenseGrowth = 5;
        }

        rand = RandomNumber();
        if(rand < 70){
            hpGrowth = hpGrow;
        }
        else if(rand < 85){
            hpGrowth = hpGrow - 1;
        }
        else{
            hpGrowth = hpGrow + 1;
        }

        if(hpGrowth < 1){
            hpGrowth = 1;
        }
        else if(hpGrowth > 5){
            hpGrowth = 5;
        }

        rand = RandomNumber();
        if(rand < 70){
            speedGrowth = speedGrow;
        }
        else if(rand < 85){
            speedGrowth = speedGrow - 1;
        }
        else{
            speedGrowth = speedGrow + 1;
        }

        if(speedGrowth < 1){
            speedGrowth = 1;
        }
        else if(speedGrowth > 5){
            speedGrowth = 5;
        }
    }
    public void SetStats(){
        attack = attackGrowth * level;
        defense = defenseGrowth * level;
        hp = hpGrowth * level;
        speed = speedGrowth * level;
    }
    public void LevelUp(){
        while(exp > (level * 2)){
            exp -= (level * 2);
            level += 1;
        }
        SetStats();
    }
}