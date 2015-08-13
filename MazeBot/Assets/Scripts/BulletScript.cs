using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


   // public Transform Origin;
    Rigidbody bullet;
    
    // Use this for initialization
	void Start () {
        bullet = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        
	
	}

    public void OnCollisionEnter(Collision collision)
    {
        EnemyBehaviour.isBulletAlive = false;
        Destroy(this.gameObject);
       

    }



}
