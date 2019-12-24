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
    public Monster(int attackGrow, int defenseGrow, int hpGrow, int speedGrow, string nick, Sprite picture, int typeOf, int lvl, Move[] moveSet){
        SetGrowth(attackGrow, defenseGrow, hpGrow, speedGrow);
        nickname = nick;
        pic = picture;
        type = typeOf;
        level = lvl;
        exp = 0;
        moves = moveSet;
    }
    public int RandomNumber(int min, int max){  
        Random random = new Random();  
        return Random.Range(min, max);
    }
    public void SetGrowth(int attackGrow, int defenseGrow, int hpGrow, int speedGrow){
        int rand = RandomNumber(0, 100);
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

        rand = RandomNumber(0, 100);
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

        rand = RandomNumber(0, 100);
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

        rand = RandomNumber(0, 100);
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
    public Move GetRandomMove(){
        int i = 4;
        int moveNum = RandomNumber(0, i);
        while(moves[moveNum] == null && i > 0){
            moveNum = RandomNumber(0, i);
            i--;
        }
        if(i < 0){
            return null;
        }
        return moves[moveNum];
    }
    public void TakeDamage(int dmg){
        int block = defense / 2;
        int taken = dmg - block;
        if(taken > 0){
            hp = hp - taken;
        }
    }
    public void TakeSelfDamage(float selfDamage){
        hp = (int)(hp - (hpGrowth * level * selfDamage));
    }
    public string Stats(){
        string text = "Attack: " + attack +" Defense: " + defense + " Hp: " + hp + " Speed: " + speed;
        return text;
    }
}