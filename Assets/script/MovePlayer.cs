using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController cc;

    private float speed = 4;
    private float turnSpeed = 2;
    
    private Vector3 velocity; 
    private float gravity = -9.8f;
    private float jump = 3f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0) * turnSpeed, Space.World);
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (cc.isGrounded == true)
        {
            velocity.x = forward.x * speed * Input.GetAxis("Vertical");
            velocity.z = forward.z * speed * Input.GetAxis("Vertical");
        }

        //But jumping is relitivly simple
        if (Input.GetKeyDown("space") && cc.isGrounded == true)
        {
            velocity.y = jump;
            //Debug.Log(velocity.y);
            //Debug.Log("jump " + cc.isGrounded);
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        if (cc.isGrounded == true && velocity.y <= -.51f)
        {
            velocity.y = -1.1f;  //isGrounded requires a gravity/force  to be calculated as true
        }
        if (Input.GetKeyDown("space"))
        {
            //Debug.Log("Pressed");
        }
        //Debug.Log(cc.isGrounded + " :" + Input.GetKeyDown("space"));
        //Debug.Log(velocity);
        cc.Move(velocity * Time.deltaTime);
    }
}
