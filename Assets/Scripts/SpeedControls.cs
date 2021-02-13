using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class SpeedControls : MonoBehaviour
{

    public Button S;
    public Button N;
    public Button F;
    public Button Stop;
    public float speed_rate = 1;
    void Start()
    {
        S.GetComponent<Image>().color = Color.green;
        N.GetComponent<Image>().color = Color.yellow;
        F.GetComponent<Image>().color = Color.red;
        //Stop.GetComponent<Image>.color = Color.cyan;
        S.onClick.AddListener(setSlowSpeed);
        N.onClick.AddListener(setNormalSpeed);
        F.onClick.AddListener(setFastSpeed);
        Stop.onClick.AddListener(setStopSpeed);
    }

    void setSlowSpeed()
    {
        speed_rate = 0.5f;
        
    }

    void setNormalSpeed()
    {
        speed_rate = 1;
       
    }

    void setFastSpeed()
    {
        speed_rate = 2;
       
    }
    void setStopSpeed()
    {
        speed_rate = 0;
    }
    void Update()
    {

    }
}
