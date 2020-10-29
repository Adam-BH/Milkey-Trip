using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    Animator fadePannel;

    private void Start()
    {
        fadePannel = GetComponent<Animator>();
    }

    public IEnumerator loadScene(string scenename)
    {
        fadePannel.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scenename);
    }

    public void Restart()
    {
        StartCoroutine(loadScene("Gameplay"));
    }
    public void Intro()
    {
        StartCoroutine(loadScene("Intro"));
    }
}

