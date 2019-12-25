using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TurnBased : MonoBehaviour
{
    public bool playerTurn;
    public Monster enemy;
    public Monster mon;
    public Player player;
    public Player rival;
    public float playerX = -1.75f;
    public float playerY = -0.75f;
    public float rivalX = 1.75f;
    public float rivalY = 0.75f;
    public float playerMonX = -1f;
    public float playerMonY = -0.5f;
    public float enemyMonX = 1f;
    public float enemyMonY = 0.5f;
    public float offScreenX = -3f;
    public float offScreenY = 2f;
    public float turnTime = 1.5f;
    public Text playerName;
    public Text rivalName;
    public SpriteRenderer pHPBack;
    public SpriteRenderer pHPFront;
    public SpriteRenderer rHPBack;
    public SpriteRenderer rHPFront;
    public float playerHPX;
    public float playerHPY;
    public float rivalHPX;
    public float rivalHPY;
    public IEnumerator StartBattle(Player playerChar, Player enemyChar, float turnTimer, 
        Text playerText, Text rivalText, SpriteRenderer hpBack, SpriteRenderer hpFront,
        float playerHX, float playerHY, float rivalHX, float rivalHY){
        playerName = playerText;
        rivalName = rivalText;
        turnTime = turnTimer;
        pHPBack = Instantiate(hpBack);
        pHPFront = Instantiate(hpFront);
        rHPBack = Instantiate(hpBack);
        rHPFront = Instantiate(hpFront);
        rival = enemyChar;
        player = playerChar;
        playerHPX = playerHX;
        playerHPY = playerHY;
        rivalHPX = rivalHX;
        rivalHPY = rivalHY;

        SetupRival();
        SetupPlayer();
        SetTurnOrder(mon, enemy);

        while(TakeTurn()){
            yield return new WaitForSeconds(turnTimer);
        }

        if(player.NextAlive() == -1){
            Debug.Log(player.nickname + " Loses");
        }
        else if(enemyChar.NextAlive() == -1){
            Debug.Log(enemyChar.nickname + " Loses");
        }
    }
    public void SetupRival(){
        enemy = rival.NextMonster();
        SetPosition(rival, rivalX, rivalY);
        SetPosition(enemy, enemyMonX, enemyMonY);
        rivalName.text = enemy.nickname;
        SetPosition(rHPBack, rivalHPX, rivalHPY);
        SetPosition(rHPFront, rivalHPX, rivalHPY);
    }
    public void SetupPlayer(){
        mon = player.NextMonster();
        SetPosition(player, playerX, playerY);
        SetPosition(mon, playerMonX, playerMonY);
        playerName.text = mon.nickname;
        SetPosition(pHPBack, playerHPX, playerHPY);
        SetPosition(pHPFront, playerHPX, playerHPY);
    }
    public void SetTurnOrder(Monster playerMon, Monster enemyMon){
        if(mon.speed >= enemy.speed){
            playerTurn = true;
        }
        else{
            playerTurn = false;
        }
    }
    public bool TakeTurn(){
        Debug.Log("");
        Debug.Log(player.nickname + "s Pokemon " + mon.nickname);
        Debug.Log(mon.Stats());
        Debug.Log(rival.nickname + "s Pokemon " + enemy.nickname);
        Debug.Log(enemy.Stats());
        if(playerTurn){
            Move monMove = mon.GetRandomMove();
            monMove.UseMove(mon, enemy);
            Debug.Log(player.nickname + "s Pokemon " + mon.nickname + " used " + Enum.GetName(typeof(Move.MoveType), monMove.type));
        }
        else{
            Move eneMove = enemy.GetRandomMove();
            eneMove.UseMove(enemy, mon);
            Debug.Log(rival.nickname + "s Pokemon " + enemy.nickname + " used " + Enum.GetName(typeof(Move.MoveType), eneMove.type));
        }

        bool deceased = false;
        if(mon.hp <= 0){
            if(player.NextAlive() == -1){
                return false;
            }
            Debug.Log(player.nickname + "s Pokemon " + mon.nickname + " has been KO'd");
            SetPosition(mon, offScreenX, offScreenY);
            mon = player.NextMonster();
            SetPosition(mon, playerMonX, playerMonY);
            playerName.text = mon.nickname;
            Debug.Log(player.nickname + "s Pokemon " + mon.nickname + " has joined the battle");
            Debug.Log(mon.Stats());
            deceased = true;
        }

        if(enemy.hp <= 0){
            if(rival.NextAlive() == -1){
                return false;
            }
            Debug.Log(rival.nickname + "s Pokemon " + enemy.nickname + " has been KO'd");
            SetPosition(enemy, offScreenX, offScreenY);
            enemy = rival.NextMonster();
            SetPosition(enemy, enemyMonX, enemyMonY);
            rivalName.text = enemy.nickname;
            Debug.Log(rival.nickname + "s Pokemon " + enemy.nickname + " has joined the battle");
            Debug.Log(enemy.Stats());
            deceased = true;
        }

        if(deceased){
            SetTurnOrder(mon, enemy);
        }
        else{
            playerTurn = !playerTurn;
        }
        return true;
    }
    public void SetPosition(Player player, float x, float y){
        SetPosition(player.playerSprite, x, y);
    }
    public void SetPosition(Monster mon, float x, float y){
        SetPosition(mon.pic, x, y);
    }
    public void SetPosition(SpriteRenderer renderer, float x, float y){
        renderer.transform.SetPositionAndRotation(new Vector3(x, y, 0), Quaternion.identity);
    }
}