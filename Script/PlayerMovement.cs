using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpHight = 3f;

    [SerializeField] private float gravity = -9.81f;
    Vector3 velocity;

    [SerializeField] Transform checkGround;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private bool isGround;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move*speed*Time.deltaTime);

        //PlayerGravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity*Time.deltaTime);

        //GroundCheck
        isGround = Physics.CheckSphere(checkGround.position, 0.25f, groundMask);

        //jump
        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -0.65f * gravity);
        }

        //Player fall from Height
        if(isGround && velocity.y < 0)
        {
            velocity.y = -3f;
        }

    }
}
