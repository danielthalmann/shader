using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitive = 1.0f; //how fast the object should rotate

    public float speed = 1.0f; //how fast the object should rotate

    public float jumpForce = 10.0f; //how fast the object should rotate

    public Vector2 turn = new Vector2();
    public Vector2 move = new Vector2();

    public Camera playerCamera = null;

    public Rigidbody player = null;
    
    // Start is called before the first frame update
    void Start()
    {
        if(playerCamera == null)
            playerCamera = Camera.main;
        if (player == null)
            player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse Y") * mouseSensitive;
        turn.y += Input.GetAxis("Mouse X") * mouseSensitive;
        turn.x = Mathf.Clamp(turn.x, -50f, 30f);
        playerCamera.transform.rotation = Quaternion.Euler(-turn.x, turn.y, 0);

        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        Vector3 movement = playerCamera.transform.forward.normalized * move.y + playerCamera.transform.right.normalized * move.x;
        movement.y = 0;
        //  Vector3 movement = new Vector3(move.x, 0f, move.y);
        // movement = movement * speed;
        //transform.position += movement;

        if (Input.GetButtonDown("Jump")) 
        {
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        player.AddForce(movement * speed, ForceMode.Force);


    }
}
