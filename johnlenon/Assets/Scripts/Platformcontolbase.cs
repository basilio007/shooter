using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformcontolbase : MonoBehaviour
{
    public Rigidbody PlatformRB;
    public Transform[] PlatformPosition;
    public float PlatformSpeed;

    // Update is called once per frame
    void Update()
    {
        MovePlatfom();  
    }
   void MovePlatfom()
    {
        PlatformRB.MovePosition(Vector3.MoveTowards(PlatformRB.position, PlatformPosition[1].position, PlatformSpeed * Time.deltaTime));

    }
}
