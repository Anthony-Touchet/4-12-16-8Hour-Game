using UnityEngine;
using System.Collections.Generic;
using System;

public class TargetManager : MonoBehaviour {

    public List<GameObject> targetList = new List<GameObject>();

	void Awake () {
        
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Target");
        foreach(GameObject g in temp)
        {
            targetList.Add(g);
        }
	}
	
	void Update () {
	
	}
}
