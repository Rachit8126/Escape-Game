using UnityEngine;

public class AutoDoorClose : MonoBehaviour
{
    public Transform player;
    private Animator animator;
    private MainDoorController controller;
    private AudioSource audioSource;
    private bool played = false;
    private void Awake()
    {
        controller = GetComponent<MainDoorController>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z > -1 && played == false)
        {
            played = true;
            if(gameObject.tag == "Right door")
            {
                controller.isOpen = false;
                audioSource.Play();
                animator.Play("RightMainCloseDoor");
            }
            if (gameObject.tag == "Left door")
            {
                controller.isOpen = false;
                audioSource.Play();
                animator.Play("LeftMainCloseDoor");
            }
        }
    }
}
