using UnityEngine;
using System.Collections;

public class AttackBotWheels : MonoBehaviour {


    public GameObject Wheel1;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Wheel1.transform.Rotate(new Vector3(80 * Time.deltaTime, 0, 0));
        
	}
}
