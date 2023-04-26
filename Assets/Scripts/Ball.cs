using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public object Point { get; internal set; }

    public Rigidbody rb; // reference to the Rigidbody component of the ball
    public float startSpeed = 40f; // the speed at which the ball starts moving

    private Transform _arrow;

    private bool _ballMoving;

    private Transform _startPosition;


    void Update()
    {
        if (_ballMoving)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shoot());
        }

    }

    private IEnumerator Shoot()
    {
        //ameraAnim.SetTrigger("Go");
        //cameraAnim.SetFloat("CameraSpeed", _arrow.transform.localScale.z);
        _ballMoving = true;
        _arrow.gameObject.SetActive(false);
        rb.isKinematic = false;

        // calculate the force vector to apply to the ball
        Vector3 forceVector = (-_arrow.forward) * (startSpeed * _arrow.transform.localScale.z);

        // calculate the position at which to apply the force (in this case, the center of the ball)
        Vector3 forcePosition = transform.position + (transform.right * 0.5f);

        // apply the force at the specified position
        rb.AddForceAtPosition(forceVector, -forcePosition, ForceMode.Impulse);


        yield return new WaitForSecondsRealtime(7);

        _ballMoving = false;


        //GenerateFeedBack();

        yield return new WaitForSecondsRealtime(2);

        //ResetGame();
    }


    private static void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*private void GenerateFeedBack()
    {
        feedBack.text = Point switch
        {
            0 => "Nothing!",
            > 0 and < 3 => "You are learning Now!",
            >= 3 and < 6 => "It was close!",
            >= 6 and < 10 => "It was nice!",
            _ => "Perfect! You are a master!"
        };

        feedBack.GetComponent<Animator>().SetTrigger("Show");
    }
    */
}