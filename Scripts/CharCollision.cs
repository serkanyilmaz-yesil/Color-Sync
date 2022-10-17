using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollision : MonoBehaviour
{
    public static CharCollision collision;
    public Transform left, middle, right;

    public Vector3 nullPos;

    private void Start()
    {
        nullPos = transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerControl.ctrl.selectedObject.tag == "ActivePlayer")
        {
            if (other.CompareTag("Left"))
            {
                nullPos = left.transform.position;
            }
            if (other.CompareTag("Middle"))
            {
                nullPos = middle.transform.position;
            }
            if (other.CompareTag("Right"))
            {
                nullPos = right.transform.position;
            }

        }


    }

}
