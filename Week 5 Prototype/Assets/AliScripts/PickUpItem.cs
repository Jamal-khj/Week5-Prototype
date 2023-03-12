using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Transform PickUpPoint;
    private Transform player;

    public float pickUpDistance;
    public float forceMulti;

    public bool readyToThrow;
    public bool itemIsPicked;

    private Rigidbody rb;

    [SerializeField] AudioSource pickUp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        PickUpPoint = GameObject.Find("PickUpPoint").transform;

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && itemIsPicked == true && readyToThrow)
        {
            forceMulti += 300 * Time.deltaTime;

        }

        pickUpDistance = Vector3.Distance(player.position, transform.position);

        if (pickUpDistance <= 4)
        {
            if (Input.GetKeyDown(KeyCode.E) && itemIsPicked == false && PickUpPoint.childCount < 1)
            {
                //enabled iskinematic when picked
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                this.transform.position = PickUpPoint.position;
               // pickUp.Play();
                this.transform.parent = GameObject.Find("PickUpPoint").transform;

                itemIsPicked = true;
                forceMulti = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.E) && itemIsPicked == true)
        {
            readyToThrow = true;


            if (forceMulti > 10)
            {
                //disabled iskinematic when dropped
                rb.AddForce(player.transform.forward * forceMulti);
                this.transform.parent = null;
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                itemIsPicked = false;

                forceMulti = 0;
                readyToThrow = false;
            }

            forceMulti = 0;
        }
    }
}
