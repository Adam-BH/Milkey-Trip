using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkBottle : MonoBehaviour
{

    public float milkGoal;
    public float timerGoal;
    
    public SceneTransition transition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            float milk = collision.gameObject.GetComponent<MilkeyManager>().milk;
            float timer = ((collision.gameObject.GetComponent<MilkeyManager>().timerBarVal) / (collision.gameObject.GetComponent<MilkeyManager>().maxTimer)) * 100;

            // Deafeat
            if(milk <= milkGoal)
            {
                StartCoroutine(transition.loadScene("BottleOrange"));
            }
            else if(timer >= timerGoal)
            {
                StartCoroutine(transition.loadScene("BottlePoison"));
            }
            //Victory
            else
            {
                StartCoroutine(transition.loadScene("Victory"));
            }
        }
    }

}
