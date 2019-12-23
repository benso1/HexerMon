using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBased : MonoBehaviour
{
    enum Type
    {
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
    public Monster CreateSquare(){
        return new Monster(2, 3, 3, 1, "Square", squarePic, (int)Type.Square);
    }
    public Monster CreateCircle(){
        return new Monster(3, 1, 1, 3, "Circle", circlePic, (int)Type.Circle);
    }
    public Monster CreateTriangle(){
        return new Monster(2, 2, 2, 2, "Triangle", trianglePic, (int)Type.Triangle);
    }
    public Monster CreateLine(){
        return new Monster(1, 5, 3, 1, "Line", linePic, (int)Type.Line);
    }
    public Monster CreateHexagon(){
        return new Monster(2, 2, 2, 5, "Hexagon", hexagonPic, (int)Type.Hexagon);
    }
    public Monster CreateOctagon(){
        return new Monster(5, 2, 2, 1, "Octagon", octagonPic, (int)Type.Octagon);
    }
}
