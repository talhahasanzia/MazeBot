using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {

       


    }

    void StageClear()
    {

        if(CharacterControls.HasPassKey)
        Debug.Log("Stage Clear");
    
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
            StageClear();


    }




    

 





}
