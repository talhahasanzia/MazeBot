using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public static bool isJammed=false;
    
    public Transform Player;
    public Transform RaycastObject;
    public GameObject Bullet;
    public Transform BulletOrigin;

    public Transform Target;

    public Transform StartPosition;


    public Vector3 MoveDirection;


    Rigidbody EnemyRG;

   public static bool isBulletAlive = false;

   bool recentlyFoundPlayer;


   Transform ResetPosition;
    Rigidbody bulletPhysics;

    public float DetectDistance=50.0f;
    
	// Use this for initialization
	void Start () {

        ResetPosition = StartPosition;

        MoveDirection = transform.forward;
        EnemyRG = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (!isJammed)
        {
            EnemyRG.velocity = Vector3.zero;
            EnemyRG.angularVelocity = Vector3.zero;

            // transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
           




            RaycastObject.Rotate(0, 100 * Time.deltaTime, 0);

            bool Status = isSeen();


            if (recentlyFoundPlayer)
            {

                if (CalculateDistance() > DetectDistance)
                {
                    //this.transform.position = StartPosition.position;

                    //transform.position = Vector3.Lerp(transform.position, StartPosition.position, 2 * Time.deltaTime);
                    //this.transform.rotation = StartPosition.rotation;
                    //recentlyFoundPlayer = false;

                }







            }



            if (CalculateDistance() < 10.0f)
            {

                if (!isBulletAlive)
                {

                    recentlyFoundPlayer = true;

                    Transform shotTarget = this.transform; ;
                    shotTarget.LookAt(Player.transform);



                    GameObject Clone = Instantiate(Bullet);
                    isBulletAlive = true;
                    Clone.transform.position = BulletOrigin.position;

                    bulletPhysics = Clone.GetComponent<Rigidbody>();



                    bulletPhysics.useGravity = true;
                    bulletPhysics.isKinematic = false;

                    bulletPhysics.AddForce(shotTarget.forward * 700);
                   
                }
             
                transform.Translate(transform.forward * 2 * Time.deltaTime);

            }
            else
            {


                transform.Translate(MoveDirection * 2 * Time.deltaTime);
            
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

      

        return status;

        
    }


    float CalculateDistance()
    {


        float distance;

        distance = (Player.position - transform.position).magnitude;


       
        return distance;
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {

            MoveDirection = -(MoveDirection);
        
        }


    }

    public void OnTriggerEnter(Collider other)
    {

        isJammed = true;


    }

    public void OnTriggerExit(Collider other)
    {
        isJammed = false;
    }




    
}
