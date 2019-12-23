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
    public Monster(int attackGrow, int defenseGrow, int hpGrow, int speedGrow, string nick, Sprite picture, int typeOf){
        SetGrowth(attackGrow, defenseGrow, hpGrow, speedGrow);
        nickname = nick;
        pic = picture;
        type = typeOf;
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
    }
}
