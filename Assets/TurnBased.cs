using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBased : MonoBehaviour
{
    public bool playerTurn;
    public Monster enemy;
    public Monster mon;
    public Player player;
    public Player rival;
    public void StartBattle(Player playerChar, Player enemyChar){
        rival = enemyChar;
        enemy = rival.NextMonster();
        player = playerChar;
        mon = player.NextMonster();
        SetTurnOrder(mon, enemy);
        while(TakeTurn()){
            //Display Battle
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

        bool deceased = false;
        if(mon.hp < 0){
            if(player.NextAlive() == -1){
                return false;
            }
            mon = player.NextMonster();
            deceased = true;
        }

        if(enemy.hp < 0){
            if(rival.NextAlive() == -1){
                return false;
            }
            enemy = rival.NextMonster();
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
    public void UseMove(Move move, Monster good, Monster bad){
        //Activate the effects of the moves
    }
}