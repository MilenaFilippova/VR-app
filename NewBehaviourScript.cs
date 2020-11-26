//Зомби
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class NewBehaviourScript: MonoBehaviour {

    CharacterController characterController;
    public float speed = 0.01F;
    public float speedRotation = 3;
    private float step;
    public Vector3 start;
    public Vector3 end;
    public double Angle, AngleResult;

    double GetAngle(Vector3 Obj, Vector3 Destination)
    {
        // Получим косинус угла по формуле
        double cos = Math.Round((Obj.x * Destination.x + Obj.y * Destination.y) / (Math.Sqrt(Obj.x * Obj.x + Obj.y * Obj.y) * Math.Sqrt(Destination.x * Destination.x + Destination.y * Destination.y)), 9);
        // Вернем arccos полученного значения (в радианах!)
        Angle = Math.Acos(cos);
        double ToDegrees = Angle * 180 / Math.PI;
        return ToDegrees;
    }

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        Vector3 end = new Vector3(UnityEngine.Random.Range(-6.0f, 6.0f), 0, UnityEngine.Random.Range(-4.0f, 4.0f));
        Vector3 start = transform.position;
    }
    
    // Update is called once per frame
    void Update () 
    {
        AngleResult = GetAngle( start,end);
        Debug.Log($"{AngleResult}; \r\n"); 
        transform.Rotate(0, (float)AngleResult  * speedRotation, 0);
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
