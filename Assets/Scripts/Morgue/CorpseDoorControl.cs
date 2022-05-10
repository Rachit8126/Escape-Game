using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseDoorControl : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void open()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Play();
            animator.Play("Open_Corpse_Door");
        }
    }

    public void close()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Play();
            animator.Play("Close_Corpse_Door");
        }
    }
}
