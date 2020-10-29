using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkPower : MonoBehaviour
{
    public ParticleSystem effect;
    public float heals;
    public float timeSaver;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<MilkeyManager>().milk < collision.gameObject.GetComponent<MilkeyManager>().maxMilk)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                collision.gameObject.GetComponent<MilkeyManager>().milk  += heals;
                if (collision.gameObject.GetComponent<MilkeyManager>().timerBarVal > 0) 
                {
                    collision.gameObject.GetComponent<MilkeyManager>().timer -= timeSaver;
                }
                Destroy(gameObject);
            }
        }
    }
}
