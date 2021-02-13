using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool move;
    public string pos;
    public GameObject wall = null;
    private Vector3 take_move_value;
    public GameObject manager;

    void Start()
    {
        manager = GameObject.Find("TrafficLightsManager");
    }

    private void Update()
    {
        move_cars();
    }

    void move_cars()
    {
        if (move)
            {

            if (pos.Equals("left"))
            {
                take_move_value = new Vector3(-2 * Time.deltaTime * GameObject.Find("Canvas").GetComponent<SpeedControls>().speed_rate, 0, 0);
                
            }
            if (pos.Equals("down"))
            {
                take_move_value = new Vector3(0, -2 * Time.deltaTime * GameObject.Find("Canvas").GetComponent<SpeedControls>().speed_rate, 0);

            }
            if (pos.Equals("up"))
            {
                take_move_value = new Vector3(0, 2 * Time.deltaTime * GameObject.Find("Canvas").GetComponent<SpeedControls>().speed_rate, 0);
            }
            if (pos.Equals("right"))
            {
                take_move_value = new Vector3(2 * Time.deltaTime * GameObject.Find("Canvas").GetComponent<SpeedControls>().speed_rate, 0, 0);
            }

            gameObject.transform.position += take_move_value;
        }


    }

     
        

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.name.Equals("Stop-Coin-Down"))
        {
            move = manager.GetComponent<Manager>().cross_up_down;
            if (!move)
            {
                wall = collider.gameObject;
                get_collided_coin();
            }
        }

        if (collider.name.Equals("Stop-Coin-Up"))
        {
            move = manager.GetComponent<Manager>().cross_up_down;
            if (!move)
            {
                wall = collider.gameObject;
                get_collided_coin();
            }
        }

        if (collider.name.Equals("Stop-Coin-Left"))
        {
            move = manager.GetComponent<Manager>().cross_left_right;
            if (!move)
            {
                wall = collider.gameObject;
                get_collided_coin();
            }
        }


        if (collider.tag.Equals("StopLeftRight"))
        {
            move = manager.GetComponent<Manager>().cross_left_right;
            if (!move)
            {
                wall =  collider.gameObject;
                get_collided_coin();
            }
        }
        if (collider.tag.Equals("coin"))
        {
           
            move = collider.gameObject.GetComponent<Coin>().move;
            if (!move)
            {
                wall = collider.gameObject.GetComponent<Coin>().wall;
                get_collided_coin();
            }
        }
        if (collider.tag.Equals("Destroyer"))
        {
            Destroy(this.gameObject);
        }


    }

    void get_collided_coin()
    {
        manager.GetComponent<Manager>().coins_collided_togueder.Add(gameObject);
    }
}


