using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAR : MonoBehaviour
{

    public Slider slider;

    public void setBar(float val)
    {
        slider.value = val;
    }
}
