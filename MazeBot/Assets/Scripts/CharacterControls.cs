using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {

    public static bool HasPassKey = false;
    
    
    int speed = 15;

    int gravity = 20;

    private Vector3 moveDirection = Vector3.zero;

    CharacterController controller;

   
    
    void Start()
    {
    
        controller= this.GetComponent<CharacterController>();
        
    
    }
	
    
   

void FixedUpdate()
{

   
	if(controller.isGrounded)
	{
		moveDirection =new Vector3(0,0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
	}
	
	
	var rotateY = (Input.GetAxis("Mouse X") * 200) * Time.deltaTime;
	
	controller.transform.Rotate(0,rotateY, 0);
	
	moveDirection.y -= gravity * Time.deltaTime;
	
	controller.SimpleMove (moveDirection * Time.deltaTime*speed);
}

public void OnControllerColliderHit(ControllerColliderHit hit)
{


    if (hit.gameObject.tag == "Passkey")
    {

        HasPassKey = true;
     }

}


    
 
 


}
