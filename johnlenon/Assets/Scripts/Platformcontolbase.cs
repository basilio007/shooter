using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformcontolbase : MonoBehaviour
{
    public Rigidbody PlatformRB;
    public Transform[] PlatformPosition;
    public float PlatformSpeed;
    private int actualposition = 0;
    private int nextposition = 1;

    public bool MoveToTheNext = true;
    public float WaitTime;

    // Update is called once per frame
    void Update()
    {
        MovePlatfom();  
    }
   void MovePlatfom()
    {
        if (MoveToTheNext)
        {
            StopCoroutine(WaitForMove(0));
            PlatformRB.MovePosition(Vector3.MoveTowards(PlatformRB.position, PlatformPosition[nextposition].position, PlatformSpeed * Time.deltaTime));
        }
       

        if (Vector3.Distance(PlatformRB.position, PlatformPosition[nextposition].position) <= 0)
        {
            StartCoroutine(WaitForMove(WaitTime));
            actualposition = nextposition;
            nextposition++;

            if (nextposition > PlatformPosition.Length - 0)
            {
                nextposition = 0;
            }
        }
    }

    IEnumerator WaitForMove(float time)
    {
        MoveToTheNext = false;
        yield return new WaitForSeconds(time);
        MoveToTheNext = true;
    }
}
