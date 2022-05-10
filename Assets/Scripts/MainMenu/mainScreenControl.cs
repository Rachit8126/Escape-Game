using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScreenControl : MonoBehaviour
{
    private FadeEffect fade;
    // Update is called once per frame
    public void changeScene()
    {
            fade = GameObject.Find("fadeEffect").GetComponent<FadeEffect>();
            fade.Fade();
    }
}
