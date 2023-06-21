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

    public Rigidbody rb; // reference to the Rigidbody component of the ball
    public float startSpeed = 40f; // the speed at which the ball starts moving

    private Transform _arrow;

    private bool _ballMoving;

    //private Transform _startPosition;

    private Vector3 startPosition;


    private readonly Dictionary<GameObject, Transform> _pinsDefaultTransform = new();

    public int Point { get; set; }


    public int shoutCount = 0;

    public AudioSource audio_ball;

    private Pin pin;



    private void Start()
    {

        Application.targetFrameRate = 60;

        _arrow = GameObject.FindGameObjectWithTag("Arrow").transform;

        // get the reference to the Rigidbody component of the ball
        rb = GetComponent<Rigidbody>();

        startPosition = transform.position;

        audio_ball = GetComponent<AudioSource>();

        

    }


    void Update()
    {
        if (_ballMoving)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio_ball.Play();
            StartCoroutine(Shoot());
            shoutCount += 1;
        }

    }

    private IEnumerator Shoot()
    {

        _ballMoving = true;
        _arrow.gameObject.SetActive(false);
        rb.isKinematic = false;

        // calculate the force vector to apply to the ball
        Vector3 forceVector = (-_arrow.forward) * (startSpeed * _arrow.transform.localScale.z);

        // calculate the position at which to apply the force (in this case, the center of the ball)
        Vector3 forcePosition = transform.position + (transform.right * 0.5f);

        // apply the force at the specified position
        rb.AddForceAtPosition(forceVector, -forcePosition, ForceMode.Impulse);


        yield return new WaitForSecondsRealtime(5);

   
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        _arrow.gameObject.SetActive(true);

        _ballMoving = false;


        //yield return new WaitForSecondsRealtime(1);

        if (shoutCount == 2)
        {
            ResetGame();
            shoutCount = 0;
        }

        
    }

    public static void ResetGame()
    {
        SceneManager.LoadScene(3);
    }


}