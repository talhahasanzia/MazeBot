using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {


   public Transform startPosition;


     uint Health=100;
	// Use this for initialization
	void Start () {

       
    }
	
	// Update is called once per frame
	void FixedUpdate () {

       
        if (Health == 0)
            Respawn();

	}
    void Respawn()
    {
        Health = 100;
        this.transform.position = startPosition.transform.position;
    
    
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {

            Health -= 5;
        
        }

    }

}
