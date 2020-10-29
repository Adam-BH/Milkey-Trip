using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public SceneTransition Transition;
    public GameObject[] pannels;
    int index = 0;

    private void Start()
    {
        foreach(GameObject pannel in pannels)
        {
            pannel.SetActive(false);
        }
        pannels[index].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(index < (pannels.Length - 1))
            {
                pannels[index].SetActive(false);
                index++;
                pannels[index].SetActive(true);
            }
            else
            {
                StartCoroutine(Transition.loadScene("Gameplay"));
            }
        }
    }

}
