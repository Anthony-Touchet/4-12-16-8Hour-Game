using UnityEngine;
using System.Collections.Generic;

public class SpawnPointControl : MonoBehaviour {

    public GameObject spawn;
    public GameObject altSpawn;
    public float spawnRate;
    float nextSpawn;
    public int spawnLimit;
    List<GameObject> spawnedObjects = new List<GameObject>();

    int ran;
	
	void Update () {

	    if(Time.time >= nextSpawn && spawnedObjects.Count < spawnLimit)
        {
            if(ran == 1)
            {
                spawn = altSpawn;
            }
            GameObject temp = Instantiate(spawn, gameObject.transform.position, new Quaternion()) as GameObject;
            nextSpawn = Time.time + spawnRate;
            spawnedObjects.Add(temp);
        }

        ran--;

        foreach(GameObject e in spawnedObjects)
        {
            if(e == null)
            {
                spawnedObjects.Remove(e);
            }
        }
	}
}
