using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Monster[] monsters;
    public Sprite playerSprite;
    Player(Sprite playerPic){
        playerSprite = playerPic;
        monsters = new Monster[6];
    }
}
