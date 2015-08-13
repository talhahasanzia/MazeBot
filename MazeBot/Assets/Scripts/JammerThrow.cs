using UnityEngine;
using System.Collections;

public class JammerThrow : MonoBehaviour {

    public Transform JammerOrigin;
    public GameObject JammerGameObject;
    Rigidbody jammerPhysics;
    uint TotalJammers = 3;
    uint jammersThrown=0;

	// Use this for initialization
	void Start () {
        jammerPhysics = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!(jammersThrown == TotalJammers))
            {
                jammersThrown++;

                GameObject Clone = Instantiate(JammerGameObject);

                Clone.transform.position = JammerOrigin.position;

                jammerPhysics = Clone.GetComponent<Rigidbody>();



                jammerPhysics.useGravity = true;
                jammerPhysics.isKinematic = false;

                jammerPhysics.AddForce(transform.forward * 100);
            }
        }
    }
}
