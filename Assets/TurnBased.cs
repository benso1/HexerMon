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
    IEnumerable StartBattle(Player playerChar, Player enemyChar){
        rival = enemyChar;
        enemy = rival.NextMonster();
        player = playerChar;
        mon = player.NextMonster();
        SetTurnOrder(mon, enemy);
        while(TakeTurn()){
            yield return new WaitForSeconds(2f);
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
            Move monMove = mon.GetRandomMove();
            monMove.UseMove(mon, enemy);
            Debug.Log(player.nickname + "s Pokemon" + mon.nickname + " used " + monMove.name);
        }
        else{
            Move eneMove = enemy.GetRandomMove();
            eneMove.UseMove(enemy, mon);
            Debug.Log(rival.nickname + "s Pokemon" + enemy.nickname + " used " + eneMove.name);
        }

        if(mon.hp < 0){
            if(player.NextAlive() == -1){
                return false;
            }
            mon = player.NextMonster();
        }

        if(enemy.hp < 0){
            if(rival.NextAlive() == -1){
                return false;
            }
            enemy = rival.NextMonster();
        }
        Debug.Log("");
        Debug.Log(player.nickname + "s Pokemon" + mon.nickname);
        Debug.Log(mon.Stats());
        Debug.Log(rival.nickname + "s Pokemon" + mon.nickname);
        Debug.Log(enemy.Stats());
        playerTurn = !playerTurn;
        return true;
    }
}