using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBased : MonoBehaviour
{
    public bool playerTurn;
    public Monster enemy;
    public Monster mon;
    public Player player;
    public void StartBattle(Player playerChar, Monster enemyMon){
        enemy = enemyMon;
        player = playerChar;
        mon = player.monsters[0];
        while(enemyMon.hp > 0 && TakeTurn()){
            playerTurn = !playerTurn;
        }
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
        if(playerTurn){
            //Get Move
        }
        else{
            UseMove(enemy.GetRandomMove(), enemy, mon);
        }

        if(player.NextAlive() == -1){
            return false;
        }
        return true;
    }
    public void UseMove(Move move, Monster good, Monster bad){
        //Activate the effects of the moves
    }
}