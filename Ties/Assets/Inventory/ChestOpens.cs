using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestOpens : MonoBehaviour {
    public enum State
    {
        open,
        close,
        inbetween
    }
    public State state;
    public Material material;
    public GameObject[] parts;
    private Color[] _defaultColors;

    private Transform t;
    private Transform player;

    public int maxDistance = 2;

    private GameObject _player;
    private Transform _myTransform;
    public bool inUse = false;
    private bool _used = false; 
    public List<Item> loot = new List<Item>();

    // Use this for initialization
    void Start () {
        state = ChestOpens.State.close;
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {

        if(_player == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, _player.transform.position) > maxDistance)
            Messenger.Broadcast("CloseChest");
	
	}

    public void OnMouseEnter()
    {
        Debug.Log("Enter");

    }
    public void OnMouseExit()
    {
        Debug.Log("Exit");
    }
    public void OnMouseUp()
    {
        if (player == null)
            return;
        if (Vector3.Distance(player.position, t.transform.position) > maxDistance && !inUse)
            return;
        Debug.Log("UP");
        switch (state)
        {
            case State.open:
                state = ChestOpens.State.inbetween;
                StartCoroutine("Close");
                break;
            case State.close:
                state = ChestOpens.State.inbetween;
                StartCoroutine("Open");
                break;
        }
    }

    private void Open() { 
        {
            myGUI.chest = this;
            _player = GameObject.FindGameObjectWithTag("Player");
            inUse = true;
            GetComponent<Animation>().Play("Open");
          

            //yeild return new WaitForSeconds(ainmation["open"].length);
            if(!_used)
            PopulateChest(1);
            state = ChestOpens.State.open;
            //Messenger<int, GameObject>.Broadcast("PopulateChest", 5, gameObject, MessengerMode.DONT_REQUIRE_LISTENER);

            Messenger.Broadcast("DisplayLoot");
        }
    }

    private void PopulateChest(int x) { 
        for (int cnt = 0; cnt < x; cnt++) {
            int roll = Random.Range(0, 10);
            if(roll > 5)
            {
                loot.Add(ItemGenenerator.CreateItem());
                roll = Random.Range(0, 10);
            }
            if (roll < 5)
            {
                loot.Add(ItemGenenerator.CreateArmor());
                roll = Random.Range(0, 10);
            }

    }
        _used = true;

    }
    private void Close()
    {
        _player = null;
        inUse = false;
        //yeild return new WaitForSeconds(ainmation["close"].length);
        state = ChestOpens.State.close;

        if (loot.Count == 0)
            Destroy(gameObject);

    }








}
