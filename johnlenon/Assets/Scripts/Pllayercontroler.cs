using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pllayercontroler : MonoBehaviour
{
    public float horizontalMove;
    public float verticallMove;

    private Vector3 playerInput;

    public CharacterController player;
    public float playerspeed;
    private Vector3 moveplayer;
    public float gravity = 9.8f;
    public float fallvelocity;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticallMove = Input.GetAxis("Vertical");


        playerInput = new Vector3(horizontalMove, 0, verticallMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDiretion();
        //moveplayer = playerInput.x * camRight * playerInput.z * camForward;

        moveplayer = moveplayer * playerspeed;

        player.transform.LookAt(player.transform.position + moveplayer);

        //SetGravity();

        player.Move(playerInput * playerspeed * Time.deltaTime);
        Debug.Log(player.velocity.magnitude);
    }
    void camDiretion()  
    {
       
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    void SetGravity()
    {
       
        

        if (player.isGrounded)
        {
           fallvelocity = -gravity * Time.deltaTime;
            moveplayer.y = fallvelocity;
        }
        else
        {
            fallvelocity -= gravity * Time.deltaTime;
            moveplayer.y = fallvelocity;
        }
    }

}
