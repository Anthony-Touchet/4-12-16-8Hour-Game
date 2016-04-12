using UnityEngine;
using UnityEngine.UI;

public class TargetController : Actor {
    public Slider healthSlider;
    float hurtRate;
    float nextHurt;

    public bool alive;
	void Start () {
        health = 100;
        hurtRate = 1f;
        healthSlider.maxValue = health;
    }
	
	new void Update () {
        if(base.Update())
        {
            alive = false;
        }

        healthSlider.value = health;
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
