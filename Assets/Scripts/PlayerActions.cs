using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : Actor {
    public int ammo;
    public GameObject bullet;
    GameObject bullSpawn;
    float nextAmmoRespawn;
    float nextFire;
    Text ammoText;

    public float ammoRespawnRate;
	
	void Start () {
        ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        bullSpawn = GameObject.Find("BulletSpawn");
        health = 100;
        speed = 10;
        bullDam = 10;
        fireRate = 1f;
        ammo = 9;
	}

    void Lerp(Vector3 mov)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + mov.x, gameObject.transform.position.y + mov.y, gameObject.transform.position.z + mov.z);
    }
	
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        Lerp((new Vector3(0, 0, move) / speed));
    }

	new void Update () {
        float fire = Input.GetAxis("Fire1");

        if(fire > 0 && Time.time >= nextFire)
        {
            GameObject temp;
            temp = Instantiate(bullet, bullSpawn.transform.position, new Quaternion()) as GameObject;
            temp.GetComponent<BulletControler>().damage = bullDam;
            nextFire = Time.time + fireRate;
            ammo -= 1;
        }

        if(Time.time >= nextAmmoRespawn)
        {
            ammo++;
            nextAmmoRespawn = Time.time + ammoRespawnRate;
        }

        ammoText.text = "Ammo: " + ammo.ToString();
	}
}
