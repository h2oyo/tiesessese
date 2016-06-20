using UnityEngine;
using System.Collections;

public class BuffItem : Item  {

    private Hashtable buffs;

    public BuffItem()
    {
        buffs = new Hashtable();
    }

    public BuffItem(Hashtable ht)
    {
        buffs = ht;
    }

}
