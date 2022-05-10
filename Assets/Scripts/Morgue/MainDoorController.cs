using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    public bool isOpen = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void leftopen()
    {
        animator.Play("LeftMainOpenDoor");
        audioSource.Play();
        isOpen = true;
    }

    public void rightopen()
    {
        animator.Play("RightMainOpenDoor");
        audioSource.Play();
        isOpen = true;
    }

    //public void leftclose()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        animator.Play("Close_Corpse_Door");
    //    }
    //}

    //public void rightclose()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        animator.Play("Close_Corpse_Door");
    //    }
    //}
}
