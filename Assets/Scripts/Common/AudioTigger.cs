using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTigger : MonoBehaviour
{
    private AudioSource thunderAudio;

    private void Start()
    {
        thunderAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            thunderAudio.Play();
    }
}
