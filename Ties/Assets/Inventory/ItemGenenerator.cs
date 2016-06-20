using UnityEngine;


public static class ItemGenenerator  {
    public const int BASE_MELEE_RANGE = 1;

    private const string MELEE_WEAPON_PATH = "Item Icons/Weapon/";
    private const string MELEE_ARMOR_PATH = "Item Icons/Armor/";
    public static Item CreateItem()
    {

       Item item = CreateMeleeWeapon();
    
        item.Value = Random.Range(1, 101);
        item.Rarity = Item.RarityTypes.Common;
        item.MaxDurablilty = Random.Range(50, 61);
        item.CurDurablilty = item.MaxDurablilty;
        return item;
    }

    public static Item CreateArmor()
    {

        Item item = CreateChest();
 
        item.Value = Random.Range(1, 101);
        item.Rarity = Item.RarityTypes.Common;
        item.MaxDurablilty = Random.Range(50, 61);
        item.CurDurablilty = item.MaxDurablilty;
        return item;
    }
    private static Weapon CreateWeapon()
    {
        Weapon weapon = CreateMeleeWeapon();




        return weapon;
    }

    public static Weapon CreateMeleeWeapon()
    {
        Weapon Meleeweapon = new Weapon();
        string[] weaponNames = new string[3];

        weaponNames[0] = "Staff";
        weaponNames[1] = "Axe";
        weaponNames[2] = "Sword";

        Meleeweapon.Name = weaponNames[Random.Range(0, weaponNames.Length)];



		if (Meleeweapon.Name == weaponNames [0]) {
			Meleeweapon.DamageVariance = Random.Range(1, 10);
		}
		if (Meleeweapon.Name == weaponNames [1]) {
			Meleeweapon.MaxDamage = Random.Range(5, 10);
		}
		if (Meleeweapon.Name == weaponNames [2]) {
			Meleeweapon.MaxDamage = Random.Range(5, 10);
		}

       
       
        Meleeweapon.MaxRange = BASE_MELEE_RANGE;
        Meleeweapon.TypeOfDamage = Weapon.DamageType.Slash;
        Meleeweapon.itemtype = ItemType.Weapon;
        Meleeweapon.Icon = Resources.Load(MELEE_WEAPON_PATH + Meleeweapon.Name) as Texture2D;

        return Meleeweapon;
    }
    private static Armor CreatesChest()
    {
        Armor Chest = CreateChest();




        return Chest;
    }
    public static Armor CreateChest()
    {
        Armor Armor = new Armor();
        string[] ArmorNames = new string[3];

        ArmorNames[0] = "Cloth";
        ArmorNames[1] = "Chain";
        ArmorNames[2] = "Metal";

        Armor.Name = ArmorNames[Random.Range(0, ArmorNames.Length)];
        if(Armor.Name == ArmorNames[0])
        {
            Armor.Defence = Random.Range(1, 3);
        }
        if (Armor.Name == ArmorNames[1])
        {
            Armor.Defence = Random.Range(3, 6);
        }
        if (Armor.Name == ArmorNames[2])
        {
            Armor.Defence = Random.Range(6, 9);
        }

        Armor.Icon = Resources.Load(MELEE_ARMOR_PATH + Armor.Name) as Texture2D;
        

        return Armor;
    }

}

