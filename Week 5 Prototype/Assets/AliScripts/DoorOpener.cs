using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void Start()
    {
       // _animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Package"))
        {
            _animator.SetBool(name: "opened", value: true);
        }
    }
}
