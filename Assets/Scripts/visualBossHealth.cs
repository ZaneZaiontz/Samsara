using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class visualBossHealth : MonoBehaviour
{
    public Slider slider;
    public Canvas canvas;

    public void setMaxBossHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Start is called before the first frame update
    public void setBossHealth(float health)
    {
        slider.value = health;

        if (slider.value <= 0)
        {
            Destroy(canvas);
        }
    }
}
