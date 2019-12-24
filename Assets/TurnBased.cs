using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnBased : MonoBehaviour
{
    public bool playerTurn;
    public Monster enemy;
    public Monster mon;
    public Player player;
    public Player rival;
    public void StartBattle(Player playerChar, Player enemyChar){
        //Debug.Log("Entered Function");
        rival = enemyChar;
        enemy = rival.NextMonster();
        //Debug.Log("Got Rival Monster");
        player = playerChar;
        mon = player.NextMonster();
        //Debug.Log("Got Player Monster");
        SetTurnOrder(mon, enemy);
        //Debug.Log("Got Turn Order");
        while(TakeTurn()){
            //yield return new WaitForSeconds(2f);
        }
        if(player.NextAlive() == -1){
            Debug.Log(player.nickname + " Loses");
        }
        else if(enemyChar.NextAlive() == -1){
            Debug.Log(enemyChar.nickname + " Loses");
        }
        //Debug.Log("Battle Finished");
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

        if(mon.hp <= 0){
            if(player.NextAlive() == -1){
                return false;
            }
            Debug.Log(player.nickname + "s Pokemon " + mon.nickname + " has been KO'd");
            mon = player.NextMonster();
            Debug.Log(player.nickname + "s Pokemon " + mon.nickname + " has joined the battle");
            Debug.Log(mon.Stats());
        }

        if(enemy.hp <= 0){
            if(rival.NextAlive() == -1){
                return false;
            }
            Debug.Log(rival.nickname + "s Pokemon " + enemy.nickname + " has been KO'd");
            enemy = rival.NextMonster();
            Debug.Log(rival.nickname + "s Pokemon " + enemy.nickname + " has joined the battle");
            Debug.Log(enemy.Stats());
        }
        playerTurn = !playerTurn;
        return true;
    }
}