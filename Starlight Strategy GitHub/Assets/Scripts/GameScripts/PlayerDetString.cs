using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Playerdata", menuName = "Playerdata")]
public class PlayerDetstring : PlayerDetails
{
   

    public override string PlayersInfoText()
    {
        StringBuilder bd = new StringBuilder();
        bd.Append("P1 Souls: ").Append(player1LordCards).AppendLine();
        bd.Append("P1 Mana: ").Append(player1Mana).AppendLine();
        bd.Append("P1 Rank Counter: ").Append(p1Rankcount).AppendLine();
        bd.Append(" ").AppendLine();
        bd.Append("P2 Souls: ").Append(player2LordCards).AppendLine();
        bd.Append("P2 Mana: ").Append(player2Mana).AppendLine();
        bd.Append("P2 Rank Counter: ").Append(p2Rankcount).AppendLine();
        return bd.ToString();
    }

}