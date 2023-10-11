using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDetails : ScriptableObject
{
    public int player1Mana;
    public int player2Mana;
    public int player1LordCards;
    public int player2LordCards;
    public int player1TurnNum;
    public int player2TurnNum;
    public int p1Rankcount;
    public int p2Rankcount;


    public abstract string PlayersInfoText();

}
