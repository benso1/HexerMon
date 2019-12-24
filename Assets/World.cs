using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    void Start(){
        //Debug.Log("Can Write");
        Player player = gameObject.AddComponent(typeof(Player)) as Player;
        player.AddStats(playerPic, "Red");
        player.GetMon(CreateMon((int)Shape.Triangle, 5));
        player.GetMon(CreateMon((int)Shape.Hexagon, 5));
        player.GetMon(CreateMon((int)Shape.Octagon, 5));
        //Debug.Log("Created Player");
        Player rival = gameObject.AddComponent(typeof(Player)) as Player;
        rival.AddStats(rivalPic, "Jerk");
        rival.GetMon(CreateMon((int)Shape.Triangle, 5));
        rival.GetMon(CreateMon((int)Shape.Triangle, 5));
        rival.GetMon(CreateMon((int)Shape.Square, 5));
        rival.GetMon(CreateMon((int)Shape.Line, 5));
        rival.GetMon(CreateMon((int)Shape.Circle, 5));
        //Debug.Log("Created Rival");
        TurnBased turnBase = gameObject.AddComponent(typeof(TurnBased)) as TurnBased;
        //Debug.Log("Created TurnBased");
        turnBase.StartBattle(player, rival);
    }
    enum Shape{
        Circle = 0,
        Square = 1,
        Triangle = 2,
        Line = 3,
        Hexagon = 4,
        Octagon = 5
    }
    public SpriteRenderer playerPic;
    public SpriteRenderer rivalPic;
    public Sprite circlePic;
    public Sprite squarePic;
    public Sprite trianglePic;
    public Sprite linePic;
    public Sprite hexagonPic;
    public Sprite octagonPic;
    public Monster CreateMon(int type, int level){
        switch(type){
            case (int)Shape.Circle:
                return CreateCircle(level);
            case (int)Shape.Square:
                return CreateSquare(level);
            case (int)Shape.Triangle:
                return CreateTriangle(level);
            case (int)Shape.Line:
                return CreateLine(level);
            case (int)Shape.Hexagon:
                return CreateHexagon(level);
            case (int)Shape.Octagon:
                return CreateOctagon(level);
        }
        return null;
    }
    public Monster CreateCircle(int level){
        Move[] moveSet = new Move[4];
        AddMove(CreateMove((int)Move.MoveType.SelfDestruct), moveSet);
        return CreateMon(3, 1, 1, 3, "Circle", circlePic, (int)Shape.Circle, level, moveSet);
    }
    public Monster CreateSquare(int level){
        Move[] moveSet = new Move[4];
        AddMove(CreateMove((int)Move.MoveType.ShieldBash), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Kick), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Punch), moveSet);
        return CreateMon(2, 3, 3, 1, "Square", squarePic, (int)Shape.Square, level, moveSet);
    }
    public Monster CreateTriangle(int level){
        Move[] moveSet = new Move[4];
        AddMove(CreateMove((int)Move.MoveType.Splash), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Kick), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Punch), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Stall), moveSet);
        return CreateMon(2, 2, 2, 2, "Triangle", trianglePic, (int)Shape.Triangle, level, moveSet);
    }
    public Monster CreateLine(int level){
        Move[] moveSet = new Move[4];
        AddMove(CreateMove((int)Move.MoveType.ShieldBash), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Stall), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Splash), moveSet);
        return CreateMon(1, 5, 3, 1, "Line", linePic, (int)Shape.Line, level, moveSet);
    }
    public Monster CreateHexagon(int level){
        Move[] moveSet = new Move[4];
        AddMove(CreateMove((int)Move.MoveType.Kick), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Punch), moveSet);
        return CreateMon(2, 2, 2, 5, "Hexagon", hexagonPic, (int)Shape.Hexagon, level, moveSet);
    }
    public Monster CreateOctagon(int level){
        Move[] moveSet = new Move[4];
        AddMove(CreateMove((int)Move.MoveType.UltimateAnnihilation), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Kick), moveSet);
        AddMove(CreateMove((int)Move.MoveType.Punch), moveSet);
        return CreateMon(5, 3, 3, 1, "Octagon", octagonPic, (int)Shape.Octagon, level, moveSet);
    }
    public void AddMove(Move move, Move[] moves){
        for(int i = 0; i < moves.Length; i++){
            if(moves[i] == null){
                moves[i] = move;
                break;
            }
        }
    }
    public Move CreateMove(int type){
        Move temp = gameObject.AddComponent(typeof(Move)) as Move;
        temp.AddStats(type);
        return temp;
    }
    public Monster CreateMon(int attackGrow, int defenseGrow, int hpGrow, int speedGrow, string nick, Sprite picture, int typeOf, int lvl, Move[] moveSet){
        Monster temp = gameObject.AddComponent(typeof(Monster)) as Monster;
        temp.AddStats(attackGrow, defenseGrow, hpGrow, speedGrow, nick, picture, typeOf, lvl, moveSet);
        return temp;
    }
}