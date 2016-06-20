using UnityEngine;
using System.Collections;

public class LevelSystem : MonoBehaviour
{

    //We need 100 exp to level

    public int level;
    public int exp;
    public int statpoints;
    public PlayerClass player;
    int expToLvL;

    public bool lvlupCalled;

    void Start()
    {
        level = 1;
        statpoints = 0;
        lvlupCalled = false;
        expToLvL = 100;
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();

    }

    void LevelUp()
    {
        if (exp >= expToLvL)
        {
            level = level + 1;
            player.statpoints = player.statpoints + 5;
            player.skillpoints = player.skillpoints + 1;
            expToLvL = expToLvL * 2;
            exp = 0;
            lvlupCalled = true;
        }
        else lvlupCalled = false;
        
    }
}
