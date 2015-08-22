using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    LineRenderer line;
    RaycastHit rayHit;
    bool EnemyHit = false;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {


        

        Debug.Log("Enemy hit: " + EnemyHit);
        if (Input.GetButtonDown("Fire1"))
        {

            StopCoroutine(Laser());
            StartCoroutine(Laser());
        
        }
        if (EnemyHit)
        {
            InitializeJammer();


        }
        else
        {

            DisableJammer();
        
        }

	
	}

    void InitializeJammer()
    {


        GameObject hitObject = rayHit.collider.gameObject;

        hitObject.GetComponent<EnemyBehaviour>().enabled = false;


        StartCoroutine(DisableJammer());
    
    
    
    }


    IEnumerator DisableJammer()
    {
        yield return new WaitForSeconds(3);



        GameObject hitObject = rayHit.collider.gameObject;

            hitObject.GetComponent<EnemyBehaviour>().enabled = true;
        
    
    }


    IEnumerator Laser()
    {



        line.enabled = true;

        while (Input.GetButton("Fire1"))
        {



            Ray rayObj = new Ray(transform.position, transform.forward);


            line.SetPosition(0, rayObj.origin);


            if (Physics.Raycast(rayObj, out rayHit))
            {

                line.SetPosition(1, rayHit.point);
                // Debug.Log(rayHit.collider.tag);


                if (rayHit.collider.tag == "Enemy")
                    EnemyHit = true;

            }

            line.SetPosition(1, rayObj.GetPoint(100));


            yield return null;

        }

        line.enabled = false;
    
    }
    
}
