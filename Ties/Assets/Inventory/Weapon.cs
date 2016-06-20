using UnityEngine;
using System.Collections;

public class Weapon : BuffItem
{

    private float _maxRange;
    private DamageType _dmgType;

    public Weapon()
    {
       
        _maxRange = 0;
        _dmgType = DamageType.Bludgeon;
    }

    public Weapon(float nRange, DamageType dt)
    {

        _maxRange = nRange;
        _dmgType = dt;
    }

 
    public float MaxRange
    {
        get { return _maxRange; }
        set { _maxRange = value; }
    }
    public DamageType TypeOfDamage
    {
        get { return _dmgType; }
        set { _dmgType = value; }
    }


    public new string ToolTip()
    {
        return Name + "\n" +
             "Value:" + Value + "\n" +
             "Durability:" + CurDurablilty + "/" + MaxDurablilty + "\n" + MaxDamage * DamageVariance + "-" + MaxDamage;
    }

    public enum DamageType
    {
        Bludgeon,
        Pierce,
        Slash,
        Fire,
        Ice,
        Lighning,
        Acid
    }

}

