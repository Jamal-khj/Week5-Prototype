using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animation DoorOpen;
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTiggerEnter(Collider other)
    {
        if (other.CompareTag("Package"))
        {
            //(!openTrigger) ! means is false
            if (openTrigger)
            {
                myDoor.Play("DoorOpen", 0, 0.0f);
            }

            else if (closeTrigger)
            {
                myDoor.Play("DoorClose", 0, 0.0f);
            }
        }
    }
}
