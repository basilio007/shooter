using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pllayercontroler : MonoBehaviour
{
    public float horizontalMove;
    public float verticallMove;
    public CharacterController player;
    public float playerspeed;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        horizontalMove = Input.GetAxis("horizontal");
        verticallMove = Input.GetAxis("vertical");


    }
    void FixedUpdate()
    {
        player.Move(new Vector3(horizontalMove, 0, verticallMove) * playerspeed);
    }
}
