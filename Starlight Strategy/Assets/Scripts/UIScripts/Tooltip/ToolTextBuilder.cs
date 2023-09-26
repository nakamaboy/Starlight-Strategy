using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "New Carddata", menuName = "Unit Card")]
public class CardTextBuilder : Card
{

    public override string CardTooltipInfoText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(CardName).Append("(").Append(NickName).Append(")").AppendLine();
        builder.Append("Rank ").Append(Rank).AppendLine();
        builder.Append((Type1 == string.Empty) ? string.Empty : Type1).Append((Type2 == string.Empty) ? string.Empty : ", " + Type2).Append((Type3 == string.Empty) ? string.Empty : ", " + Type3).Append((Type4 == string.Empty) ? string.Empty : ", " + Type4).Append((Type5 == string.Empty) ? string.Empty : ", " + Type5).Append((Type6 == string.Empty) ? string.Empty : ", " + Type6).Append((Type7 == string.Empty) ? string.Empty : ", " + Type7).Append((Type8 == string.Empty) ? string.Empty : ", " + Type8).AppendLine();
        builder.Append(HealthText + " ").Append((HealthText == string.Empty) ? string.Empty : Health + " | ").Append((AtkText == string.Empty) ? string.Empty : AtkText + " ").Append((AtkText == string.Empty) ? null : Atk + " | ").Append((SupText == string.Empty) ? null : SupText + " ").Append((SupText == string.Empty) ? null : Sup + " | ").Append((MindText == string.Empty) ? string.Empty : MindText + " ").Append((MindText == string.Empty) ? string.Empty : Mind + " | ").AppendLine();
        builder.Append(DefText).Append((DefText == string.Empty) ? string.Empty : Def + " | ").Append(MdefText).Append((MdefText == string.Empty) ? string.Empty : Mdef + " | ").Append(AgiText).Append((AgiText == string.Empty) ? string.Empty : Agility + " | ").AppendLine();        
        builder.Append(Stance0Text).AppendLine();       
        builder.Append("Stance 1 - ").Append(Stance1Stattext1 + " ").Append((Stance1Stattext1 == string.Empty) ? string.Empty : Stance1Stat1 + " | ").Append(Stance1Stattext2 + " ").Append((Stance1Stattext2 == string.Empty) ? string.Empty : Stance1Stat2 + " | ").Append(Stance1Stattext3 + " ").Append((Stance1Stattext3 == string.Empty) ? string.Empty : Stance1Stat3 + " | ").Append(Stance1Stattext4 + " ").Append((Stance1Stattext4 == string.Empty) ? string.Empty : Stance1Stat4).AppendLine();
        builder.Append(Stance1Text).AppendLine();
        builder.Append("  ").AppendLine();
        builder.Append("Stance 2 - ").Append(Stance2Stattext1 + " ").Append((Stance2Stattext1 == string.Empty) ? string.Empty : Stance2Stat1 + " | ").Append(Stance2Stattext2 + " ").Append((Stance2Stattext2 == string.Empty) ? string.Empty : Stance1Stat2 + " | ").Append(Stance2Stattext3 + " ").Append((Stance2Stattext3 == string.Empty) ? string.Empty : Stance2Stat3 + " |  ").Append(Stance2Stattext4 + " ").Append((Stance2Stattext4 == string.Empty) ? string.Empty : Stance2Stat4).AppendLine();
        builder.Append(Stance2Text).AppendLine();
        return builder.ToString();
    }
}
