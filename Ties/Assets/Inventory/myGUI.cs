using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class myGUI : MonoBehaviour
{

    // WarriorClass Warrior;

    public float lootWindowHeight = 90;

    public float buttonWidth = 40;
    public float buttonHeight = 40;
    public float closeButtonWidth = 20;
    public float closeButtonHeight = 20;

    private float _offset = 10;


    private bool _displayLootWindow = false;
    private const int LOOT_WINDOW_ID = 0;
    private Rect _lootWindowRect = new Rect(0, 0, 0, 0);
    private Vector2 _lootWindowSlider = Vector2.zero;
    public static ChestOpens chest;


    private bool _displayInventoryWindow = false;
    private const int INVENTORY_WINDOW_ID = 1;
    private Rect _InventoryWindowRect = new Rect(10, 10, 170, 265);
    private int _inventoryRows = 6;
    private int _inventoryCols = 4;

    private float _doubleClickTimer = 0;
    private const float DOUBLE_CLICK_TIMER_THRESHHOLD = .5f;
    private Item _selectedItem;




    private bool _displayCharacterWindow = false;
    private const int CHARACTER_WINDOW_ID = 2;
    private Rect _characterWindowRect = new Rect(20, 20, 250, 365);
    private int _characterPanel = 0;
    private string[] _characterPanelNames = new string[] { "Equipment", "Attributes", "Skills" };

    public GUISkin mySkin;

    private string _toolTip = "";


    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        Messenger.AddListener("DisplayLoot", DisplayLoot);
        Messenger.AddListener("ToggleInventory", ToggleInventoryWindow);
        Messenger.AddListener("ToggleCharacterWindow", ToggleCharacterWindow);
        Messenger.AddListener("CloseChest", ClearWindow);

    }

    private void OnDisable()
    {
        Messenger.RemoveListener("DisplayLoot", DisplayLoot);
        Messenger.RemoveListener("ToggleInventory", ToggleInventoryWindow);
        Messenger.RemoveListener("ToggleCharacterWindow", ToggleCharacterWindow);
        Messenger.RemoveListener("CloseChest", ClearWindow);

    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        if (_displayCharacterWindow)
            _characterWindowRect = GUI.Window(CHARACTER_WINDOW_ID, _characterWindowRect, CharacterWindow, "Character");

        if (_displayInventoryWindow)
            _InventoryWindowRect = GUI.Window(INVENTORY_WINDOW_ID, _InventoryWindowRect, InventoryWindow, "Inventory");
        if (_displayLootWindow)
            _lootWindowRect = GUI.Window(LOOT_WINDOW_ID, new Rect(_offset, Screen.height - (_offset + lootWindowHeight), Screen.width - (_offset * 2), lootWindowHeight), LootWindow, "Loot Window", "box");
        DisplayToolTip();
    }
    private void LootWindow(int id)
    {
        GUI.skin = mySkin;


        if (GUI.Button(new Rect(_lootWindowRect.width - _offset * 2, 0, closeButtonWidth, closeButtonHeight), "x", "Close Window Button"))
        {
            ClearWindow();
            if (chest == null)
                return;

            if (chest.loot.Count == 0)
            {
                ClearWindow();
                return;
            }
        }
        _lootWindowSlider = GUI.BeginScrollView(new Rect(_offset * .5f, 15, _lootWindowRect.width - 10, 70), _lootWindowSlider, new Rect(0, 0, (chest.loot.Count * buttonWidth) + _offset, buttonHeight + _offset));


        for (int cnt = 0; cnt < chest.loot.Count; cnt++)
        {
            if (GUI.Button(new Rect(_offset * .5f + (buttonWidth * cnt), _offset, buttonWidth, buttonHeight), new GUIContent(chest.loot[cnt].Icon, chest.loot[cnt].ToolTip())))
            {
                Debug.Log(chest.loot[cnt].ToolTip());
                WarriorClass.Inventory.Add(chest.loot[cnt]);
                chest.loot.RemoveAt(cnt);
            }
        }
        GUI.EndScrollView();

        SetToolTip();
    }

    private void DisplayLoot()
    {
        _displayLootWindow = true;
    }
    //private void PopulateChest(int x)

    //{

    //    for (int cnt = 0; cnt < x; cnt++)
    //        _lootItems.Add(new Item());
    //    _displayLootWindow = true;
    //}

    private void ClearWindow()
    {
        _displayLootWindow = false;


        chest.GetComponent<ChestOpens>().OnMouseUp();
        chest = null;


    }


    public void InventoryWindow(int id)
    {
        int cnt = 0;
        for (int y = 0; y < _inventoryRows; y++)
        {
            for (int x = 0; x < _inventoryCols; x++)
            {
                if (cnt < WarriorClass.Inventory.Count)
                {
                    if (GUI.Button(new Rect(5 + (x * buttonWidth), 20 + (y * buttonHeight), buttonWidth, buttonHeight), new GUIContent(WarriorClass.Inventory[cnt].Icon, WarriorClass.Inventory[cnt].ToolTip())))
                    {
                        _selectedItem = WarriorClass.Inventory[4 * y + x];

                        // 0 is at 0,0 // 4 * 0 + 0 = 0
                        // 1 is at 1,0 // 4 * 0 + 1 = 1
                        // 3 is at 3,0
                        // 7 is at 3,1 // 4 * 1 + 3 = 7
                        // 11 is at 3,2 // 4 * 2 + 3 = 11

                        if (_doubleClickTimer != 0 && _selectedItem != null && _selectedItem.Itemtypes == ItemType.Armors)
                        {

                            if (Time.time - _doubleClickTimer < DOUBLE_CLICK_TIMER_THRESHHOLD)
                            {

                                if (WarriorClass.EquipedChest == null)
                                {
                                    WarriorClass.EquipedChest = WarriorClass.Inventory[cnt];
                                    WarriorClass.Inventory.RemoveAt(cnt);
                                }
                                else
                                {

                                    if (WarriorClass.EquipedChest.itemtype == ItemType.Armors)
                                    {
                                        Item temp = WarriorClass.EquipedChest;
                                        WarriorClass.EquipedChest = WarriorClass.Inventory[cnt];

                                        WarriorClass.Inventory[cnt] = temp;
                                    }
                                }

                            }
                            else
                            {
                                _doubleClickTimer = Time.time;
                               // _selectedItem = WarriorClass.Inventory[cnt];

                            }
                        }
                        if (_doubleClickTimer != 0 && _selectedItem != null && _selectedItem.Itemtypes == ItemType.Weapon)
                        {

                            if (Time.time - _doubleClickTimer < DOUBLE_CLICK_TIMER_THRESHHOLD)
                            {

                                if (WarriorClass.EquipedWeapon == null)
                                {
                                    WarriorClass.EquipedWeapon = WarriorClass.Inventory[cnt];
                                    WarriorClass.Inventory.RemoveAt(cnt);
                                }
                                else
                                {

                                    if (WarriorClass.EquipedWeapon.itemtype == ItemType.Weapon)
                                    {
                                        Item temp = WarriorClass.EquipedWeapon;
                                        WarriorClass.EquipedWeapon = WarriorClass.Inventory[cnt];

                                        WarriorClass.Inventory[cnt] = temp;
                                    }
                                }

                            }
                            else
                            {
                                Debug.Log("Reset the double click timer");
                                _doubleClickTimer = Time.time;

                            }

                        }
                        else
                        {
                            _doubleClickTimer = Time.time;
                            //_selectedItem = WarriorClass.Inventory[cnt];

                        }
                    }
                }
                else
                {
                    GUI.Button(new Rect(5 + (x * buttonWidth), 20 + (y * buttonHeight), buttonWidth, buttonHeight), (x + y * _inventoryCols).ToString(), "box");
                }
                cnt++;
            }
            SetToolTip();
            GUI.DragWindow();
        }
    }


    public void ToggleInventoryWindow()
    {
        _displayInventoryWindow = !_displayInventoryWindow;
    }

    public void ToggleCharacterWindow()
    {
        _displayCharacterWindow = !_displayCharacterWindow;
    }
    public void CharacterWindow(int id)
    {
        _characterPanel = GUI.Toolbar(new Rect(5, 25, _characterWindowRect.width + 10, 35), _characterPanel, _characterPanelNames);
        switch (_characterPanel)
        {
            case 0:
                DisplayWeapon();
                DisplayChest();
                break;
            case 1:
                DisplayAttribues();
                break;
            case 2:
                DisplaySkills();
                break;

        }

        GUI.DragWindow();
    }

    private void DisplayWeapon()
    {
        // Debug.Log("Displaying Equipment");
        if (WarriorClass.EquipedWeapon == null)
        {
            GUI.Label(new Rect(5, 100, 40, 40), "", "box");
        }
        else
        {
            if (GUI.Button(new Rect(5, 100, 40, 50), new GUIContent(WarriorClass.EquipedWeapon.Icon, WarriorClass.EquipedWeapon.ToolTip())))
            {
                WarriorClass.Inventory.Add(WarriorClass.EquipedWeapon);
                WarriorClass.EquipedWeapon = null;
            }
        }
        SetToolTip();
    }
    private void DisplayChest()
    {


        if (WarriorClass.EquipedChest == null)
        {
            GUI.Label(new Rect(5, 150, 40, 40), "", "box");
        }
        else
        { 
                if (GUI.Button(new Rect(5, 150, 40, 50), new GUIContent(WarriorClass.EquipedChest.Icon, WarriorClass.EquipedChest.ToolTip())))
                {

                    WarriorClass.Inventory.Add(WarriorClass.EquipedChest);
                    WarriorClass.EquipedChest = null;
                }
        }
        SetToolTip();

    }
    private void DisplayAttribues()
    {
        // Debug.Log("Displaying Attributes");
        //if (GUI.Button(new Rect(450, 200, 200, 50), "Stregth:" + Warrior.str))
        //{
        //    if (Warrior.statpoints > 0)
        //    {
        //        Warrior.statpoints = Warrior.statpoints - 1;
        //        Warrior.str = Warrior.str + 1;
        //    }

        //}
        ////Exit to Menu button
        //if (GUI.Button(new Rect(450, 260, 200, 50), "Dex:" + Warrior.dex))
        //{
        //    if (Warrior.statpoints > 0)
        //    {
        //        Warrior.statpoints = Warrior.statpoints - 1;
        //        Warrior.dex = Warrior.dex + 1;
        //    }
        //}
        ////Quit button
        //if (GUI.Button(new Rect(450, 320, 200, 50), "Vit:" + Warrior.vit))
        //{
        //    if (Warrior.statpoints > 0)
        //    {
        //        Warrior.statpoints = Warrior.statpoints - 1;
        //        Warrior.vit = Warrior.vit + 1;
        //    }
        //}
        //if (GUI.Button(new Rect(450, 380, 200, 50), "Mag:" + Warrior.mag))
        //{
        //    if (Warrior.statpoints > 0)
        //    {
        //        Warrior.statpoints = Warrior.statpoints - 1;
        //        Warrior.mag = Warrior.mag + 1;
        //    }
        //}
    }
    private void DisplaySkills()
    {
        //  Debug.Log("Displaying Skills");
    }
    private void SetToolTip()
    {
        if (Event.current.type == EventType.Repaint && GUI.tooltip != _toolTip)
        {
            if (_toolTip != "")
                _toolTip = "";

            if (GUI.tooltip != "")
                _toolTip = GUI.tooltip;
        }

    }

    private void DisplayToolTip()
    {
        if (_toolTip != "")
            GUI.Box(new Rect(Screen.width / 2 - 100, 10, 200, 100), _toolTip);
    }
}
