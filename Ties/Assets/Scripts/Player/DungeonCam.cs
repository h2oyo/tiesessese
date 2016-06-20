using UnityEngine;
using System.Collections;

public class DungeonCam : MonoBehaviour {

    public GameObject target;
    Vector3 offset;


	// Use this for initialization
	void Start ()
    {
        offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        transform.position = desiredPosition;
	}
}
