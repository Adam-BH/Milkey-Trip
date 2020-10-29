using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public SceneTransition trans;
    public ParticleSystem blood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(blood, collision.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(collision.gameObject);
            StartCoroutine(trans.loadScene("SpikeDED"));
        }
    }
}
