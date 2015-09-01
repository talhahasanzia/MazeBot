using UnityEngine;
using System.Collections;

public class NavMeshScript : MonoBehaviour {


    public Transform Target;
   public Transform StartPos;
    public Transform Finish;
    NavMeshAgent NavAgent;

	// Use this for initialization
	void Start () {
        NavAgent = this.GetComponent<NavMeshAgent>();
        NavAgent.SetDestination(Finish.position);
        
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if ((transform.position - Finish.position).magnitude<5)
            NavAgent.SetDestination(StartPos.position);


        if ((transform.position - StartPos.position).magnitude<5)
            NavAgent.SetDestination(Finish.position);

        
        //if(NavAgent.isActiveAndEnabled==true)
        //NavAgent.destination = Target.position;
	}
}
