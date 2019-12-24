using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    void Start()
    {
        
    }
    enum Shape{
        Circle = 0,
        Square = 1,
        Triangle = 2,
        Line = 3,
        Hexagon = 4,
        Octagon = 5
    }
    public Sprite squarePic;
    public Sprite trianglePic;
    public Sprite circlePic;
    public Sprite linePic;
    public Sprite hexagonPic;
    public Sprite octagonPic;
    public Monster CreateSquare(int level){
        Move[] moveSet = new Move[4];
        AddMove(new Move((int)Move.MoveType.ShieldBash), moveSet);
        AddMove(new Move((int)Move.MoveType.Kick), moveSet);
        AddMove(new Move((int)Move.MoveType.Punch), moveSet);
        return new Monster(2, 3, 3, 1, "Square", squarePic, (int)Shape.Square, level, moveSet);
    }
    public Monster CreateCircle(int level){
        Move[] moveSet = new Move[4];
        AddMove(new Move((int)Move.MoveType.SelfDestruct), moveSet);
        return new Monster(3, 1, 1, 3, "Circle", circlePic, (int)Shape.Circle, level, moveSet);
    }
    public Monster CreateTriangle(int level){
        Move[] moveSet = new Move[4];
        AddMove(new Move((int)Move.MoveType.Splash), moveSet);
        AddMove(new Move((int)Move.MoveType.Kick), moveSet);
        AddMove(new Move((int)Move.MoveType.Punch), moveSet);
        return new Monster(2, 2, 2, 2, "Triangle", trianglePic, (int)Shape.Triangle, level, moveSet);
    }
    public Monster CreateLine(int level){
        Move[] moveSet = new Move[4];
        AddMove(new Move((int)Move.MoveType.ShieldBash), moveSet);
        AddMove(new Move((int)Move.MoveType.Stall), moveSet);
        AddMove(new Move((int)Move.MoveType.Splash), moveSet);
        return new Monster(1, 5, 3, 1, "Line", linePic, (int)Shape.Line, level, moveSet);
    }
    public Monster CreateHexagon(int level){
        Move[] moveSet = new Move[4];
        AddMove(new Move((int)Move.MoveType.SelfDestruct), moveSet);
        AddMove(new Move((int)Move.MoveType.Kick), moveSet);
        AddMove(new Move((int)Move.MoveType.Punch), moveSet);
        AddMove(new Move((int)Move.MoveType.Stall), moveSet);
        return new Monster(2, 2, 2, 5, "Hexagon", hexagonPic, (int)Shape.Hexagon, level, moveSet);
    }
    public Monster CreateOctagon(int level){
        Move[] moveSet = new Move[4];
        AddMove(new Move((int)Move.MoveType.UltimateAnnihilation), moveSet);
        AddMove(new Move((int)Move.MoveType.Kick), moveSet);
        AddMove(new Move((int)Move.MoveType.Punch), moveSet);
        return new Monster(5, 3, 3, 1, "Octagon", octagonPic, (int)Shape.Octagon, level, moveSet);
    }
    public void AddMove(Move move, Move[] moves){
        for(int i = 0; i < moves.Length; i++){
            if(moves[i] == null){
                moves[i] = move;
                break;
            }
        }
    }
}