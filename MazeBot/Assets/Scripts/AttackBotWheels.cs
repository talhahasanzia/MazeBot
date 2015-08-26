using UnityEngine;
using System.Collections;

public class AttackBotWheels : MonoBehaviour {


    public GameObject Wheel1;
    public GameObject Wheel2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Wheel1.transform.Rotate(new Vector3(0, 30 * Time.deltaTime,0 ));
        Wheel2.transform.Rotate(new Vector3(0, -30 * Time.deltaTime,0));
	}
}
