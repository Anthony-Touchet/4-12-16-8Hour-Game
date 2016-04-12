using UnityEngine;
using System.Collections;
using System;

public class EnemyRunnerScript : Actor
{
    public GameObject target;
    GameObject TM;
    Vector3 offest;
    Vector3 movement;
    public int expWorth;

    void Lerp(Vector3 vec)    //Function for player movement
    {
        gameObject.transform.position = new Vector3(transform.position.x + vec.x, transform.position.y + vec.y, transform.position.z + vec.z);
    }

    // Use this for initialization
    void Start()
    {
        offest = new Vector3(0, 0, 0);
        TM = GameObject.Find("TargetManager");
        target = FindNearestTarget(gameObject);
        health = 10;   //Player's Health: how much x before destroyed.
        speed = 2;      //Speed of the player. the higher it is the slower he will move
        bullDam = 10;   //How much damage the enemy will Deal.
        fireRate = 1f;  //How fast the player will be able to fire.
        expWorth = 10;
    }

    // Update is called once per frame
    new public void Update()
    {
        if(base.Update())  //Check to see if health is zero.
        {
            Destroy(gameObject);
        }

        //gameObject.transform.LookAt(target.transform);
        if (gameObject.transform.position.x < target.gameObject.transform.position.x - .1 || gameObject.transform.position.x > target.gameObject.transform.position.x + .1)
        {
            offest.x = gameObject.transform.position.x - target.gameObject.transform.position.x;
        }

        else
        {
            offest.x = 0;
        }

        if (gameObject.transform.position.z < target.gameObject.transform.position.z - .1 || gameObject.transform.position.z > target.gameObject.transform.position.z + .1)
        {
            offest.z = gameObject.transform.position.z - target.gameObject.transform.position.z;
        }

        else
        {
            offest.z = 0;
        }

        if (offest.x != 0)
            movement.x = offest.x / Math.Abs(offest.x);
        if (offest.z != 0)
            movement.z = offest.z / Math.Abs(offest.z);

        movement = -(movement) * speed * Time.deltaTime;

        Lerp(movement);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")  //If it's an bullet
        {
            health -= other.gameObject.GetComponent<BulletControler>().damage;   //Take damage
            Destroy(other.gameObject);
        }
    }

    public GameObject FindNearestTarget(GameObject en)
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject t in TM.GetComponent<TargetManager>().targetList)
        {
            float distance = Vector3.Distance(t.transform.position, en.transform.position);
            if (distance < minDistance)
            {
                closest = t;
                minDistance = distance;
            }
        }
        return closest;
    }

    public int ReturnBulletDam()
    {
        return bullDam;
    }
}
