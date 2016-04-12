using UnityEngine;
using System.Collections;

public class TargetController : Actor {
    float hurtRate;
    float nextHurt;

    public bool alive;
	void Start () {
        health = 100;
        hurtRate = 1f;
	}
	

	new void Update () {
        if(base.Update())
        {
            alive = false;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && Time.time >= nextHurt)
        {
            health -= other.gameObject.GetComponent<EnemyRunnerScript>().ReturnBulletDam();
            nextHurt = Time.time + hurtRate;
        }
    }
}
