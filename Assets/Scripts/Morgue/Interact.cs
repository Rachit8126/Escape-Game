using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    Scene currentScene;
    private string curScene;
    public float distance = 2f;
    private CorpseDoorControl corpseDoor;
    private MainDoorController mainDoorController;
    private bool isCorpseOpen = false;
    public Camera mainCamera;
    public bool hasMainKey = false;
    public bool hasCorpseKey = false;

    [SerializeField] private Text pickUp, look;
    private KeyController mainKey, corpseKey;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        curScene = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance) && curScene == "morgue")
        {
            if(hit.collider.tag == "Corpse Door")
            {
                look.text = "Corpse Door";
                if (isCorpseOpen == false && hasCorpseKey == true)
                {
                    corpseDoor = hit.collider.GetComponent<CorpseDoorControl>();
                    corpseDoor.open();
                    isCorpseOpen = true;
                }
                else if (isCorpseOpen == true)
                {
                    corpseDoor = hit.collider.GetComponent<CorpseDoorControl>();
                    corpseDoor.close();
                    isCorpseOpen = false;
                }
            }
            else if(hit.collider.tag == "Right door" || hit.collider.tag == "Left door")
            {
                look.text = "Main Door";
                if (hit.collider.tag == "Right door" && Input.GetKeyDown(KeyCode.E))
                {
                    mainDoorController = hit.collider.GetComponent<MainDoorController>();
                    if ((mainDoorController.isOpen == false && hasMainKey == true) || transform.position.z <= -3.7)
                    {
                        mainDoorController.rightopen();
                    }
                }
                if (hit.collider.tag == "Left door" && Input.GetKeyDown(KeyCode.E))
                {
                    mainDoorController = hit.collider.GetComponent<MainDoorController>();
                    if ((mainDoorController.isOpen == false && hasMainKey == true) || transform.position.z <= -3.7)
                    {
                        mainDoorController.leftopen();
                    }
                }
            }
            else if(hit.collider.tag == "Corpse_Door_Key")
            {
                corpseKey = hit.collider.GetComponent<KeyController>();
                look.text = "Corpse Door Key";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    corpseKey.PickedUp();
                    Destroy(hit.collider.gameObject);
                    hasCorpseKey = true;
                    pickUp.text = "Picked up Corpse door key";
                    StartCoroutine(clearText());
                }
            }
            else if (hit.collider.tag == "Main_Door_Key")
            {
                mainKey = hit.collider.GetComponent<KeyController>();
                look.text = "Main Door Key";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    mainKey.PickedUp();
                    Destroy(hit.collider.gameObject);
                    hasMainKey = true;
                    pickUp.text = "Picked up Main Door key";
                    StartCoroutine(clearText());
                }
            }
            else
            {
                look.text = "";
            }
        }
    }

    IEnumerator clearText()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            pickUp.text = "";
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 3;
        Gizmos.DrawRay(transform.position, direction);
    }
}
