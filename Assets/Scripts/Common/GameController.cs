using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Interact it;
    private PlayerMove pm;
    private MouseLook ml;
    public GameObject gameOverWon, gameOverLose;
    private FadeEffect fade;

    // Start is called before the first frame update
    void Start()
    {
        it = GetComponent<Interact>();
        pm = GetComponent<PlayerMove>();
        ml = GetComponent<MouseLook>();
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string curScene = currentScene.name;
        if (it.hasCorpseKey && transform.position.z < -7.6f && curScene == "morgue")
        {
            gameOverWon.SetActive(true);
            it.enabled = false;
            pm.enabled = false;
            ml.enabled = false;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                fade = GameObject.Find("fadeEffect").GetComponent<FadeEffect>();
                fade.Fade();
            }
        }
        else if(curScene == "Maze" && transform.position.x >= 40)
        {
            gameOverWon.SetActive(true);
            Timer.time = 0;
            it.enabled = false;
            pm.enabled = false;
            ml.enabled = false;
        }
        else if (curScene == "Maze" && Timer.time <= 0)
        {
            gameOverLose.SetActive(true);
            Timer.time = 0;
            it.enabled = false;
            pm.enabled = false;
            ml.enabled = false;
        }
    }

}
