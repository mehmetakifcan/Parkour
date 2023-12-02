using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController controller;
    public float speed = 1f;
    //Camera Controller
    private float xRotation = 0f;
    public float mouseSensitivity = 100f;


    //jump and gravity
    private Vector3 veloncity;
    private float gravity = -9.81f;
    private bool İsGround;
    public float jumpHeight = 0.1f;
    public float gravityDivide = 100f;
    public float JumpSpeed=100;



    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask obstacleLayer;



    private float aTimer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        //Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    
    private void Update()
    {
        //chech character is grounded
        İsGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);


        //movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical")* transform.forward;
        Vector3 movelocity = moveInputs * Time.deltaTime * speed;
        


        controller.Move(movelocity);

        //CameraController
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        


        //jump and gravity
        if (!İsGround)
        { 
            veloncity.y += gravity*Time.deltaTime/gravityDivide;
            aTimer += Time.deltaTime/3;
            speed = Mathf.Lerp(10,JumpSpeed,aTimer);
        }
        else
        {
            veloncity.y = -0.05f;
            speed = 10;
            aTimer=0;
        }

        if(Input.GetKeyDown(KeyCode.Space) && İsGround)
        {
            veloncity.y = Mathf.Sqrt(jumpHeight * -2f * gravity/ gravityDivide * Time.deltaTime);
        }

        controller.Move(veloncity);


    }

}
