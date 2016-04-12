using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    public int health;
    protected float speed;
    protected int bullDam;
    protected float fireRate;
	
	// Update is called once per frame
	public virtual bool Update () {
	    if(this.health <= 0)
            return true;
        
        return false;
	}
}
