using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;

public class Manager : MonoBehaviour
{
    public List<GameObject> trfl_up;
    public List<GameObject> trfl_down;
    public List<GameObject> trfl_left;
    public List<GameObject> trfl_right;
    public bool cross_up_down;
    public bool cross_left_right;
    public float s;
    public float s_lower;
    public float stop_speed;
    public ArrayList coins_collided_togueder = new ArrayList();

    void Start()
    {
        StartCoroutine(lights_changing());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void trfl_up_down_green() 
    {
        trfl_up[0].SetActive(false); 
        trfl_up[1].SetActive(true); 
        trfl_up[2].SetActive(true); 

        trfl_down[0].SetActive(true); 
        trfl_down[1].SetActive(true); 
        trfl_down[2].SetActive(false); 

        trfl_left[0].SetActive(false); 
        trfl_left[1].SetActive(true); 
        trfl_left[2].SetActive(true); 

        trfl_right[0].SetActive(false);
        trfl_right[1].SetActive(true); 
        trfl_right[2].SetActive(true); 

        cross_up_down = true;
        cross_left_right = false;
        can_cross_again();
    }

    void trfl_up_down_yellow() 
    {
        trfl_up[0].SetActive(true);
        trfl_up[1].SetActive(false); 
        trfl_up[2].SetActive(true); 

        trfl_down[0].SetActive(true); 
        trfl_down[1].SetActive(false); 
        trfl_down[2].SetActive(true); 

        trfl_left[0].SetActive(false); 
        trfl_left[1].SetActive(true); 
        trfl_left[2].SetActive(true); 

        trfl_right[0].SetActive(false);
        trfl_right[1].SetActive(true); 
        trfl_right[2].SetActive(true); 

        cross_up_down = true;
        cross_left_right = false;

    }

    void trfl_left_right_green() 
    {
        trfl_up[0].SetActive(true);
        trfl_up[1].SetActive(true); 
        trfl_up[2].SetActive(false); 

        trfl_down[0].SetActive(false);
        trfl_down[1].SetActive(true); 
        trfl_down[2].SetActive(true); 

        trfl_left[0].SetActive(true); 
        trfl_left[1].SetActive(true); 
        trfl_left[2].SetActive(false);

        trfl_right[0].SetActive(true);
        trfl_right[1].SetActive(true);
        trfl_right[2].SetActive(false);

        cross_up_down = false;
        cross_left_right = true;
        can_cross_again();

    }

    void trfl_left_right_yellow() 
    {
        trfl_up[0].SetActive(true); 
        trfl_up[1].SetActive(true); 
        trfl_up[2].SetActive(false); 

        trfl_down[0].SetActive(false);
        trfl_down[1].SetActive(true); 
        trfl_down[2].SetActive(true); 

        trfl_left[0].SetActive(true); 
        trfl_left[1].SetActive(false);
        trfl_left[2].SetActive(true); 

        trfl_right[0].SetActive(true);
        trfl_right[1].SetActive(false);
        trfl_right[2].SetActive(true);

        cross_up_down = false;
        cross_left_right = true;

    }

    IEnumerator lights_changing()
    {
        normal_fast_slow();
        while (true)
        {
            s = (10 / GameObject.Find("Canvas").GetComponent<SpeedControls>().speed_rate);
            stop_speed = (GameObject.Find("Canvas").GetComponent<SpeedControls>().speed_rate);
            trfl_up_down_green();
            yield return new WaitForSeconds(s);

            trfl_up_down_yellow();
            yield return new WaitForSeconds(s_lower);

            trfl_left_right_green();
            yield return new WaitForSeconds(s);


            trfl_left_right_yellow();
            yield return new WaitForSeconds(s_lower);
            
            if (GameObject.Find("Canvas").GetComponent<SpeedControls>().Stop)
            {
                trfl_up_down_green();
                yield return new WaitForSeconds(1*stop_speed);

                trfl_up_down_yellow();
                yield return new WaitForSeconds(1*stop_speed);

                trfl_left_right_green();
                yield return new WaitForSeconds(1*stop_speed);


                trfl_left_right_yellow();
                yield return new WaitForSeconds(1*stop_speed);
            }
        }
        
    }

    IEnumerator move_coins_again()
    {
        while (coins_collided_togueder.Count > 0)
        {
            GameObject coins = coins_collided_togueder[0] as GameObject;
            coins.GetComponent<Coin>().move = true;
            coins.GetComponent<Coin>().wall = null;
            coins_collided_togueder.Remove(coins);
        }
        yield return new WaitForSeconds(0);
    }

    async void can_cross_again()
    {
        GameObject triggerStreet = GameObject.Find("Sensor-Center");
        while (triggerStreet.GetComponent<SensorCenter>().coin_counter > 0)
        {
            await Task.Yield();
        }
        StartCoroutine(move_coins_again());
    }

    void normal_fast_slow()
    {
         s = (10 / GameObject.Find("Canvas").GetComponent<SpeedControls>().speed_rate);
         s_lower = (7 / GameObject.Find("Canvas").GetComponent<SpeedControls>().speed_rate);
         stop_speed = (GameObject.Find("Canvas").GetComponent<SpeedControls>().speed_rate);
    }
}
