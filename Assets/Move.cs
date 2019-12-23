using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public enum MoveType{
        Punch = 0,
        SelfDestruct = 1,
		ShieldBash = 2,
		Net = 3,
		Splash = 4,
		Stall = 5,
    }
    public int dmg;
    public int selfDmg;
    public int type;
    Move(int typeOf){
        dmg = 0;
        selfDmg = 0;
        type = typeOf;
    }
    public void UpdateMove(){
        switch(type){
            case ((int)MoveType.Punch):
                dmg = 1;
                selfDmg = 0;
                break;
            case ((int)MoveType.SelfDestruct):
                break;
            case ((int)MoveType.ShieldBash):
                break;
            case ((int)MoveType.Net):
                break;
            case ((int)MoveType.Splash):
                dmg = 0;
                selfDmg = 0;
                break;
            case ((int)MoveType.Stall):
                break;
        }
    }
}