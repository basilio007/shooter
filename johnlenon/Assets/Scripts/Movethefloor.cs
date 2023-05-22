using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movethefloor : MonoBehaviour
{
    CharacterController player;

    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;
    string lastGroundName;


    Quaternion actualRot;
    Quaternion lastRot;

    public float facttorOfvision = 4.2f;

    void Start()
    {
        player = this.GetComponent<CharacterController>();
    }


    void Update()
    {
        if (player.isGrounded)
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, player.radius / facttorOfvision, -transform.up, out hit))
            {
                GameObject groundIn = hit.collider.gameObject;
                groundName = groundIn.name;
                groundPosition = groundIn.transform.position;

                actualRot = groundIn.transform.rotation;

                if (groundPosition != lastGroundPosition && groundName == lastGroundName) 
                {
                 this.transform.position += groundPosition - lastGroundPosition;
                }

                if (actualRot != lastRot && groundName == lastGroundName)
                {
                var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
                    this.transform.RotateAround(groundIn.transform.position, Vector3.up, newRot.y);
                }

                lastGroundName = groundName;
                lastGroundPosition = groundPosition;
                lastRot = actualRot;
               

            }

        }

        else if (!player.isGrounded)
        {
            lastGroundName = null;
            lastGroundPosition = Vector3.zero;
            lastRot = Quaternion.Euler(0, 0, 0);
        }
    }
    private void OnDrawGizmos()
    {
        player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, player.radius / facttorOfvision);
    }
}
