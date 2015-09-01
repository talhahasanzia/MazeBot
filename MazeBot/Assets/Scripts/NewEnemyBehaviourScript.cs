using UnityEngine;
using System.Collections;

public class NewEnemyBehaviourScript : MonoBehaviour {


    public static bool isJammed = false;

    public Transform Player;
    public Transform RaycastObject;
    

  //  public Transform Target;

   // public Transform StartPosition;


    public Vector3 MoveDirection;


    public Rigidbody EnemyRG;

    public static bool isBulletAlive = false;

    bool recentlyFoundPlayer;


    Transform ResetPosition;
  

    public float DetectDistance = 50.0f;
    


	// Use this for initialization
	void Start () {
     //   ResetPosition.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);

        MoveDirection = transform.forward;
        //EnemyRG = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isJammed)
        {
            EnemyRG.velocity = Vector3.zero;
            EnemyRG.angularVelocity = Vector3.zero;

            // transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);





            RaycastObject.Rotate(0, 300 * Time.deltaTime, 0);

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



            //if (CalculateDistance() < 10.0f)
            //{

               

            //    transform.Translate(MoveDirection * 2 * Time.deltaTime);

            //}
            //else
            //{


            //    transform.Translate(MoveDirection * 2 * Time.deltaTime);

            //}

            //transform.Translate(MoveDirection * 2 * Time.deltaTime);
        }
        
	}
    bool isSeen()
    {
        RaycastHit hitObj;
        bool status = false;
        if (Physics.Raycast(RaycastObject.position, RaycastObject.forward, out hitObj, 50.0f))
        {

            Debug.DrawLine(RaycastObject.position, hitObj.point, Color.red);
            if (hitObj.collider.tag == "Wall")
            {



                status = false;
            }
            if (hitObj.collider.tag == "Player")
            {



                status = true;
            }

        }



        return status;


    }


    float CalculateDistance()
    {


        float distance=0;

        //distance = (Player.position - transform.position).magnitude;



        return distance;
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
          
            //transform.rotation =Quaternion.Euler(transform.rotation.x, transform.rotation.y +180, transform.rotation.y);

           // transform.Rotate(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
            
            
            
           // MoveDirection = -(MoveDirection);
        }


    }

    public void OnTriggerEnter(Collider other)
    {

       // isJammed = true;


    }

    public void OnTriggerExit(Collider other)
    {
        //isJammed = false;
    }



}
