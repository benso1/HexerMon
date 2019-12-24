using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public enum MoveType{
        Punch = 0,
        SelfDestruct = 1,
		ShieldBash = 2,
		Kick = 3,
		Splash = 4,
		Stall = 5,
    }
    public int dmg;
    public float selfDmg;
    public int type;
    Move(int typeOf){
        dmg = 0;
        selfDmg = 0;
        type = typeOf;
    }
    public void UseMove(Monster good, Monster bad){
        switch(type){
            case ((int)MoveType.Punch):
                dmg = good.attack;
                selfDmg = 0;
                break;
            case ((int)MoveType.SelfDestruct):
                dmg = 5 * good.attack;
                selfDmg = 1.00f;
                break;
            case ((int)MoveType.ShieldBash):
                dmg = good.hp + good.defense;
                selfDmg = 0;
                break;
            case ((int)MoveType.Kick):
                dmg = 2 * good.attack;
                selfDmg = .15f;
                break;
            case ((int)MoveType.Splash):
                dmg = 1;
                selfDmg = .01f;
                break;
            case ((int)MoveType.Stall):
                dmg = 0;
                selfDmg = 0;
                MoveStats(.5f, 2, good);
                break;
        }
        bad.TakeDamage(dmg);
        good.TakeSelfDamage(selfDmg);
    }
    public void MoveStats(float percent, int index, Monster mon){
        int buff = 0;
        float dropPercent = 1 - percent;
        if(index != 0){
            buff += (int)(mon.attack * percent);
        }
        if(index != 1){
            buff += (int)(mon.defense * percent);
        }
        if(index != 2){
            buff += (int)(mon.hp * percent);
        }
        if(index != 3){
            buff += (int)(mon.speed * percent);
        }

        if(index != 0){
            mon.attack = (int)(mon.attack * dropPercent);
        }
        if(index != 1){
            mon.defense = (int)(mon.defense * dropPercent);
        }
        if(index != 2){
            mon.hp = (int)(mon.hp * dropPercent);
        }
        if(index != 3){
            mon.speed = (int)(mon.speed * dropPercent);
        }

        if(index == 0){
            mon.attack += buff;
        }
        if(index == 1){
            mon.defense += buff;
        }
        if(index == 2){
            mon.hp += buff;
        }
        if(index == 3){
            mon.speed += buff;
        }
    }
}