using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


    public Transform Origin;
    Rigidbody bullet;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        bullet = this.GetComponent<Rigidbody>();
	
	}

    public void OnCollisionEnter(Collision collision)
    {

        Destroy(this.gameObject);
        EnemyBehaviour.isAlive = false;

    }



}
