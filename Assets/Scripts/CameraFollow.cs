using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    GameObject player;
    Vector3 offset;

	void Start () {
        player = GameObject.Find("Player");
        offset = player.transform.position - gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = player.transform.position - offset;
	}
}
