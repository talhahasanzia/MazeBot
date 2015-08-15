using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {


    public Transform Player;


    float LDoorOffset;
    float RDoorOffset;



    public float Speed;

    public GameObject LDoor;
    public GameObject RDoor;




    bool isOpen;
    bool OpenTransition;


    bool isClose;
    bool CloseTransition;


    Vector3 LDoorOpen= new Vector3();
    Vector3 LDoorClosed=new Vector3();

    Vector3 RDoorOpen=new Vector3();
    Vector3 RDoorClosed=new Vector3();
    
    // Use this for initialization
	void Start () {

        Speed = 3.0f;


        isOpen = false;
        OpenTransition = true;

        isClose = true;
        CloseTransition = false;

        LDoorOffset = -0.6f;
        RDoorOffset = 0.6f;

        LDoorClosed = new Vector3(0,0,0);
        RDoorClosed = new Vector3(0,0,0);

        LDoorOpen = new Vector3(LDoorOffset, 0, 0);
        RDoorOpen= new Vector3(RDoorOffset, 0, 0);


	}
	
    
	// Update is called once per frame
	void FixedUpdate () {
        
        
        CheckStatus();



        if (!IsNearDoor())
        {


            // Code For Closing The Door
            RDoor.transform.localPosition = Vector3.Lerp(RDoor.transform.localPosition, RDoorClosed, Speed * Time.deltaTime);
            LDoor.transform.localPosition = Vector3.Lerp(LDoor.transform.localPosition, LDoorClosed, Speed * Time.deltaTime);


        }
        if (IsNearDoor())
        {


            // Code For Opening The Door
            RDoor.transform.localPosition = Vector3.Lerp(RDoor.transform.localPosition, RDoorOpen, Speed * Time.deltaTime);
            LDoor.transform.localPosition = Vector3.Lerp(LDoor.transform.localPosition, LDoorOpen, Speed * Time.deltaTime);


        }
        
        
        
    


	}

    bool IsNearDoor()
    {


        float Distance = (Player.position - transform.position).magnitude;


        if (Distance < 3)
            return true;
        else
            return false;
    
    
    
    
    }
    void OpenDoor()
    {

        // Code For Closing The Door
        RDoor.transform.localPosition = Vector3.Lerp(RDoor.transform.localPosition, RDoorClosed, Speed * Time.deltaTime);
        LDoor.transform.localPosition = Vector3.Lerp(LDoor.transform.localPosition, LDoorClosed, Speed * Time.deltaTime);
            
    
    
    
    }

    void CloseDoor()
    {

        // Code For Closing The Door
        RDoor.transform.localPosition = Vector3.Lerp(RDoor.transform.localPosition, RDoorClosed, Speed * Time.deltaTime);
        LDoor.transform.localPosition = Vector3.Lerp(LDoor.transform.localPosition, LDoorClosed, Speed * Time.deltaTime);
            


    }
    void CheckStatus()
    {



        if (LDoor.transform.localPosition == LDoorClosed && RDoor.transform.localPosition == RDoorClosed)
        {

            isOpen = false;
            isClose = true;
            OpenTransition = true;
            CloseTransition = false;
        
        }
        if (LDoor.transform.localPosition == LDoorOpen && RDoor.transform.localPosition == RDoorOpen)
        {

            isOpen = true;
            isClose = false;
            OpenTransition = false;
            CloseTransition = true;

        }
    
    }
}
