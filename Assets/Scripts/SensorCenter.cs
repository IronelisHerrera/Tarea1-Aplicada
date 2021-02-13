using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCenter : MonoBehaviour
{
    public int coin_counter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        coin_counter++;
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        coin_counter--;
    }
}
