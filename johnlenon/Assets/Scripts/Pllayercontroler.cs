using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pllayercontroler : MonoBehaviour
{
    public float horizontalMove;
    public float verticallMove;
    public CharacterController player;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        
    }
    void FixedUpdate()
    {

    }
}
