using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picupobject : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    public GameObject PickObject;
    public Transform interactioZone;

    void Update()
    {
        if(ObjectToPickUp != null && ObjectToPickUp.GetComponent<Pickableobject>().isPickable == true && PickObject == null )
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickObject = ObjectToPickUp;
                PickObject.GetComponent<Pickableobject>().isPickable = false;
                PickObject.transform.SetParent( interactioZone);
                PickObject.transform.position = interactioZone.position;
                PickObject.GetComponent<Rigidbody>().useGravity = false;
                PickObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else if (PickObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {             
                PickObject.GetComponent<Pickableobject>().isPickable = true;
                PickObject.transform.SetParent(null);     
                PickObject.GetComponent<Rigidbody>().useGravity = true;
                PickObject.GetComponent<Rigidbody>().isKinematic = false;
                PickObject = null;
            }
        }
    }
}
