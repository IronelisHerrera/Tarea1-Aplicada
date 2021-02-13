using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class VelocidadScript : MonoBehaviour
{

    public Button S;
    public Button N;
    public Button F;
    public float speed_rate = 1;
    // Start is called before the first frame update
    void Start()
    {
        S.GetComponent<Image>().color = Color.yellow;
        N.GetComponent<Image>().color = Color.green;
        F.GetComponent<Image>().color = Color.red;
        S.onClick.AddListener(setSlowSpeed);
        N.onClick.AddListener(setNormalSpeed);
        F.onClick.AddListener(setFastSpeed);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
