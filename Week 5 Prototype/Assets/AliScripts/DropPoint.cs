using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropPoint : MonoBehaviour
{
    public Animation DoorOpen;

    void Start()
    {
        DoorOpen = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Package"))
        {
            DoorOpen.Play();
            SceneManager.LoadScene("Win Scene");
            Destroy(other.gameObject);

        }
    }       
}
