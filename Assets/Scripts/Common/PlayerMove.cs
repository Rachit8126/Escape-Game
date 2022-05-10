using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private CharacterController ch;

    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        pos *= speed * Time.deltaTime;
        pos = transform.TransformDirection(pos);
        ch.Move(pos);
    }
}
