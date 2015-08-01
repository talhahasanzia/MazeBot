using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    NavMeshAgent NavAgent;

    public Transform Player;
    public Transform RaycastObject;
    public GameObject Bullet;
    public Transform BulletOrigin;

   public static bool isAlive = false;
    Transform Target;

    Rigidbody bulletPhysics;

    public float DetectDistance=50.0f;
    
	// Use this for initialization
	void Start () {

        NavAgent = this.GetComponent<NavMeshAgent>();

        

        
	}
	
	// Update is called once per frame
	void Update () {
        Target = transform;

        
        

        RaycastObject.Rotate(0, 100 * Time.deltaTime,0 );

        bool Status = isSeen();

        if (Status)
        {
            NavAgent.enabled = true;
            Target.LookAt(Player);

        }
        else
        {

            NavAgent.enabled = false;
        
        }


       
        if (CalculateDistance()<5.0f)
        {

            if (!isAlive)
            {
                
                GameObject Clone = Instantiate(Bullet);
                isAlive = true;
                Clone.transform.position = BulletOrigin.position;

                bulletPhysics = Clone.GetComponent<Rigidbody>();



                bulletPhysics.useGravity = true;

                bulletPhysics.AddForce(transform.forward * 700);
            }
        
        }

       

	}



    bool isSeen()
    {
        RaycastHit hitObj;
        bool status = false;
        if (Physics.Raycast(RaycastObject.position, RaycastObject.forward, out hitObj,50.0f))
        {

            Debug.DrawLine(RaycastObject.position, hitObj.point);
            if(hitObj.collider.tag=="Wall")
            {


                
               status=false;
            }
            if (hitObj.collider.tag == "Player")
            {


               
                status= true;
            }
        
        }

        if (CalculateDistance() < DetectDistance)
            status = true;

        return status;

        
    }


    float CalculateDistance()
    {


        float distance;

        distance = (Player.position - transform.position).magnitude;


        Debug.Log(distance);
        return distance;
    }
}
