using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public float timer;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        slider.value = timer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VelocidadDeSlider(float velocidad)
    {
        timer = velocidad;
    }
}
