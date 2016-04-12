using UnityEngine;
using System.Collections;

public class BulletControler : MonoBehaviour {
    public int damage;

    void Lerp(Vector3 mov)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + mov.x, gameObject.transform.position.y + mov.y, gameObject.transform.position.z + mov.z);
    }

    // Update is called once per frame
    void Update () {
	    if(gameObject.transform.position.x >= 14)
        {
            Destroy(gameObject);
        }

        else
        {
            Lerp(new Vector3(.5f, 0, 0));
        }
	}
}
