using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timer;
    public static float time = 60f;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = "Time: " + ((int)time).ToString();
    }
}
