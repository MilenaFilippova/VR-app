using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class NewBehaviourScript: MonoBehaviour {

    CharacterController characterController;
    GameObject FemaleDummy;
    public float speed = 0.01F;
    public float speedRotation = 3;
    // public Vector3 end;
    private float step;
    public Vector3 start;
    public Vector3 end;


    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        Vector3 end = new Vector3(UnityEngine.Random.Range(-6.0f, 6.0f), 0, UnityEngine.Random.Range(-4.0f, 4.0f));
        Vector3 start = transform.position;
    }
    
    // Update is called once per frame
    void Update () 
    {
        transform.LookAt(transform.position + end);
        if (transform.position != end)
        {
            transform.position = Vector3.Lerp(transform.position, end, step);
            step += speed;
        }
        else{
            end = new Vector3(UnityEngine.Random.Range(-5.0f, 5.0f), 0, UnityEngine.Random.Range(-4.0f, 4.0f));
            step = 0;
        }
    }


}
