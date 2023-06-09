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
    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity;
    public float alpoeForceDown;

    //Animaciones
    public Animator PlayerAnimationControler;



    public float gravity = 9.8f;
    public float fallvelocity;
    public float jumforce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    void Start()
    {
        player = GetComponent<CharacterController>();
        PlayerAnimationControler = GetComponent<Animator>();

    }

    
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticallMove = Input.GetAxis("Vertical");


        playerInput = new Vector3(horizontalMove, 0, verticallMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        PlayerAnimationControler.SetFloat("PlayerWalkVelocity", playerInput.magnitude * playerspeed);

        camDiretion();
        moveplayer = playerInput.x * camRight + playerInput.z * camForward;

        moveplayer = moveplayer * playerspeed;

        player.transform.LookAt(player.transform.position + moveplayer);

        SetGravity();

        playerSkill();

        player.Move(moveplayer * Time.deltaTime);

        Debug.Log(player.isGrounded);
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
    //funcion para las habilidades del jugador
    void playerSkill()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallvelocity = jumforce;
            moveplayer.y = fallvelocity;
            PlayerAnimationControler.SetTrigger("PlayerJump");
        }
    }


    //funcion para la gravedad
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
            PlayerAnimationControler.SetFloat("PlayerVerticalNivelVelocity", player.velocity.y);

        }

        PlayerAnimationControler.SetBool("IsGrounded", player.isGrounded);
        SlideDown();

    }

    public void SlideDown()
    {
        isOnSlope =Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit;

        if (isOnSlope)
        {
            moveplayer.x += hitNormal.x * slideVelocity;
            moveplayer.z += hitNormal.z * slideVelocity;

            moveplayer.y += alpoeForceDown;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }
    private void OnAnimationMove()
    {

    }
   

}
