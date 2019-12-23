using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
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
        return new Monster(2, 3, 3, 1, "Square", squarePic, (int)Shape.Square, level);
    }
    public Monster CreateCircle(int level){
        return new Monster(3, 1, 1, 3, "Circle", circlePic, (int)Shape.Circle, level);
    }
    public Monster CreateTriangle(int level){
        return new Monster(2, 2, 2, 2, "Triangle", trianglePic, (int)Shape.Triangle, level);
    }
    public Monster CreateLine(int level){
        return new Monster(1, 5, 3, 1, "Line", linePic, (int)Shape.Line, level);
    }
    public Monster CreateHexagon(int level){
        return new Monster(2, 2, 2, 5, "Hexagon", hexagonPic, (int)Shape.Hexagon, level);
    }
    public Monster CreateOctagon(int level){
        return new Monster(5, 2, 2, 1, "Octagon", octagonPic, (int)Shape.Octagon, level);
    }
}