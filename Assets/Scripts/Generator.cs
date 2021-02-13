using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Generator : MonoBehaviour
{
    public GameObject coin;
    public string[] positions_in_plane =
      {
        "up",
        "down",
        "left",
        "right"
    };

    void Start()
    {
        InvokeRepeating("generate_coins", 0, 1.5f);
    }

    void Update()
    {

    }
    void generate_coins()
    {

        GameObject instance_police_car = Instantiate(coin, new Vector3(-20, -20, -20), Quaternion.identity);
        System.Random random = new System.Random();
        int get_position = random.Next(positions_in_plane.Length);
        string current_position = "down";
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);
        Vector3 vector = new Vector3(0, 0, 0);

        if (positions_in_plane.Length > 0)
        {
            if (positions_in_plane[get_position].Equals("up"))
            {
                current_position = "up";
                vector = new Vector3(1, -5, 3);
                quaternion = Quaternion.Euler(0, 0, 180);
               
            }
            if (positions_in_plane[get_position].Equals("down"))
            {
                current_position = "down";
                vector = new Vector3(-1, 5, 3);
            }
            if (positions_in_plane[get_position].Equals("left"))
            {
                current_position = "left";
                vector = new Vector3(7.26f, 0.7f, 4);
                quaternion = Quaternion.Euler(0, 0, 270);
            }
            if (positions_in_plane[get_position].Equals("right"))
            {
                current_position = "right";
                vector = new Vector3(-7.26f, -0.7f, 4);
                quaternion = Quaternion.Euler(0, 0, 90);



            }

            instance_police_car.transform.position = vector;
            instance_police_car.transform.rotation = quaternion;
            instance_police_car.GetComponent<Coin>().pos = current_position;
            instance_police_car.GetComponent<Coin>().move = true;

            //instance_police_car.GetComponent<MovementSystem>().move3_4 = false;


        }

    }
}
