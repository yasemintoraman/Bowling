using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool _done;

    private List<GameObject> _pins = new();

    public Vector3[] pinPositions;
    public bool[] pinIsDown;


    private readonly Dictionary<GameObject, Transform> _pinsDefaultTransform = new();

    public int Point { get; set; }


    private void Start()
    {
       
        _pins = GameObject.FindGameObjectsWithTag("Pin").ToList();
        pinPositions = new Vector3[_pins.Count];
        pinIsDown = new bool[_pins.Count];

        for (int i = 0; i < _pins.Count; i++)
        {
            pinPositions[i] = _pins[i].transform.position;

            pinIsDown[i] = false;
        }


        /*foreach (var pin in _pins)
        {
            _pinsDefaultTransform.Add(pin, pin.transform);
     
  
        }*/

        //feedBack = GameObject.FindGameObjectWithTag("FeedBack").GetComponent<TextMeshProUGUI>();
    }


    /*private void FixedUpdate()
    {
        for (int i = 0; i < _pins.Count; i++)
        {
            if (_pins[i].transform.position.y < 0f)
            {
                pinIsDown[i] = true;
            }
        }

        for (int i = 0; i < _pins.Count; i++)
        {
            if (!pinIsDown[i]) {
                _pins[i].transform.position = pinPositions[i];
                

                _pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                _pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }




        }
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("Ball") || collision.collider.CompareTag("Pin")) && !_done)
        {
            // get the velocity of the pin after the collision
            float velocity = GetComponent<Rigidbody>().velocity.magnitude;

            // check if the velocity has dropped below the fall threshold
            if (velocity < 5)
            {
                var point = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().Point;
                //point += 1;
                GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().Point = point;
                //Debug.Log("düþtü");
                _done = true;
            }

        }

    }

}