using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_manager : MonoBehaviour
{

    private float horizontalSense = 2f;
    private float verticalSense = 2f; 

    private Transform playerCamera; 

    private float yaw = 0.0f;
    private float pitch = 0.0f; 

    void Awake()
    {
        if(transform.Find("PlayerCamera") != null)
        {
            playerCamera = transform.Find("PlayerCamera");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   

        GetMouseInput();
        MoveCamera();
        
    }

    void GetMouseInput()
    {
        yaw += horizontalSense * Input.GetAxis("Mouse X");
        pitch += verticalSense * Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch,-90f,90f);

    }

    void MoveCamera()
    {
        playerCamera.transform.eulerAngles = new Vector3(pitch,playerCamera.transform.eulerAngles.y,0.0f);
        //playerCamera.transform.eulerAngles = new Vector3(playerCamera.transform.eulerAngles.x,pitch,0.0f);

        transform.eulerAngles = new Vector3(0.0f,yaw,0.0f);
    }
}
