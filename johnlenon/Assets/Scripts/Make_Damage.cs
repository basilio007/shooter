using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_Damage : MonoBehaviour
{
    public int cantidad = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            other.GetComponent<Healt_and_Demage>().RestarVida(cantidad);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {
            other.GetComponent<Healt_and_Demage>().RestarVida(cantidad);
        }
    }
}
