using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    int maxHealth;
    int currentHealth;
    int minimumHealth;
	void Start () {
        currentHealth = maxHealth;
        maxHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
	

        if(currentHealth < minimumHealth)
        {
            
        }
	}
}
