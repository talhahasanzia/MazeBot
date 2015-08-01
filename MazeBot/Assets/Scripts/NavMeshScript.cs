using UnityEngine;
using System.Collections;

public class NavMeshScript : MonoBehaviour {


    public Transform Target;
    NavMeshAgent NavAgent;

	// Use this for initialization
	void Start () {
        NavAgent = this.GetComponent<NavMeshAgent>();

       
	}
	
	// Update is called once per frame
	void Update () {
       


        if(NavAgent.isActiveAndEnabled==true)
        NavAgent.destination = Target.position;
	}
}
