using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool _done;

    private List<Vector3> pinPositions;
    private List<Quaternion> pinRotations;

    private List<GameObject> _pins = new();
    private List<GameObject> fallenPins = new();

    private Ball ball;

    private void Start()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();


        _pins = GameObject.FindGameObjectsWithTag("Pin").ToList();
        pinPositions = new List<Vector3>();
        pinRotations = new List<Quaternion>();

        foreach (var pin in _pins)
        {
            pinPositions.Add(pin.transform.position);
            pinRotations.Add(pin.transform.rotation);  
        }

    }

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
                    point += 1;
                    GameObject.FindGameObjectWithTag("Point").GetComponent<TextMeshProUGUI>().text = $"Score: {point}";
                    GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().Point = point;
                _done = true;
                float waitTime = 5f;
                StartCoroutine(DisableAfterTime(waitTime)); 

            }

        }
    }

    IEnumerator DisableAfterTime(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        gameObject.SetActive(false);
    }


    public void resetPins()
    {
        foreach (var pin in _pins)
        {
            if (!pin.activeSelf)
            {
                fallenPins.Add(pin);
            }
        }

        if (fallenPins.Count() == _pins.Count || ball.shoutCount ==2 )
        {
            foreach (var pin in _pins)
            {
                pin.SetActive(true);
                var pinPhysics = pin.GetComponent<Rigidbody>();
                pinPhysics.velocity = Vector3.zero;
                pinPhysics.position = pinPositions[_pins.IndexOf(pin)];
                pinPhysics.rotation = pinRotations[_pins.IndexOf(pin)];
                pinPhysics.angularVelocity = Vector3.zero;

            }
        }
    }
}




