using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_translation : MonoBehaviour
{
    [Header("Character Movement Variables")]
    [SerializeField]
    private float defaultSpeed = 5.0f;
    [SerializeField]
    private float walkSpeed = 1.5f; 
    [SerializeField]
    private float jumpSpeed = 7.0f;
    [SerializeField]
    private float gravity = 18.0f;

    [Header("Character Body Attributes")]
    [SerializeField]
    private float characterHeight = 2f;
    [SerializeField]
    private float characterCrouchingHeight = 1f;

    CharacterController characterController; 
    private Vector3 moveDirection = Vector3.zero;
    private float speed;
    private bool isWalking = false;
    private bool isCrouching = false; 
    private float horizontalMovement;
    private float verticalMovement;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = defaultSpeed;
        characterController.height = characterHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetInput()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
    }

    private void CheckCrouch()
    {
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            characterController.height = characterHeight;
            isCrouching = false; 
        }
    }
    
    private void GroundMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.height = characterCrouchingHeight;
            isCrouching = true; 
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if(isCrouching || isWalking)
        {
            speed = walkSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }

        moveDirection = transform.right * horizontalMovement +transform.forward * verticalMovement;
        if (moveDirection.magnitude > 1)
        {
            moveDirection = moveDirection.normalized;
        }
        moveDirection *= speed;
        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        
    }
}
