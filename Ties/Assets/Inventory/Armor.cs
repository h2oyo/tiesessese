using UnityEngine;
using System.Collections;

public class Armor : Item {
    public Armor ItemType { get; set; }

    public override string ToolTip()
    {
        return Name + "\n" +
             "Value:" + Value + "\n" +
             "Durability:" + CurDurablilty + "/" + MaxDurablilty + "\n" + Defence;
    }
}
