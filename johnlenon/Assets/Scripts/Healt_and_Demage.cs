using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt_and_Demage : MonoBehaviour
{

    public int vida = 100;

  public void RestarVida(int cantidad)
    {
        vida -= cantidad;

    }
}
