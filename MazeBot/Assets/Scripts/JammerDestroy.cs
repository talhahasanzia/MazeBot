using UnityEngine;
using System.Collections;

public class JammerDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

    

    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Terrain")
        {


            Destroy(this.gameObject, 5);

        }

    }

    public void OnDestroy()
    {
        EnemyBehaviour.isJammed = false;
    }

    
    


}
