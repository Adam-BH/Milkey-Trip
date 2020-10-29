using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class MilkeyManager : MonoBehaviour
{

    public SceneTransition trans;

    [Header("Styeling")]
    public SpriteRenderer PlayerMouth;
    public Sprite[] Mouthes;
    public Light2D glow;
    public SpriteRenderer Player;
    public Gradient PlayerColor;


    [Header("HUD")]
    public BAR milkBar;
    public BAR TimeBar;

    [Header("Don't touch")]
    public float milk;
    public float timer;
    public float maxTimer;
    public float maxMilk;
    public float timerBarVal;

    private PlayerMovement movments;


    private void Start()
    {
        milk = milkBar.GetComponent<Slider>().value;
        maxMilk = milkBar.GetComponent<Slider>().maxValue;
        maxTimer = TimeBar.GetComponent<Slider>().maxValue;
        timer = maxTimer;
        timerBarVal = timer - maxTimer;

        movments = gameObject.GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        // HUD
        milkBar.setBar(milk);
        TimeBar.setBar(timerBarVal);
        timer += Time.deltaTime;
        timerBarVal = timer - maxTimer;

        // Styleing

        if (timerBarVal <= (maxTimer / 3))
        {
            PlayerMouth.sprite = Mouthes[0];
        }else if (timerBarVal <= ((maxTimer / 3) * 2))
        {
            PlayerMouth.sprite = Mouthes[1];
        }
        else if (timerBarVal >= ((maxTimer / 3) * 2))
        {
            PlayerMouth.sprite = Mouthes[2];
        }
        
        glow.intensity = (milk / 100)/2 + .3f;
        Player.color = PlayerColor.Evaluate(timerBarVal / maxTimer);

        // MECHANINCS
        
        movments.speed = (7.5f - (((timerBarVal / maxTimer) * 2.5f) + 2.5f));
        movments.jumpTime = (.5f - ((timerBarVal / maxTimer) / 2));
        
        // DED

        if (timerBarVal >= maxTimer)
        {
            StartCoroutine(trans.loadScene("DateDED"));
        }

    }

}
