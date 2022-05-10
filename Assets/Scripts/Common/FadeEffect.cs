using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeEffect : MonoBehaviour
{
    public Animator transition;
    public float fadeTime = 1f;

    public void Fade()
    {
        StartCoroutine(StartFade(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator StartFade(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(levelIndex);
    }
}
