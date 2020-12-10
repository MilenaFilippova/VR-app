using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class ExampleScript : MonoBehaviour {
    public Camera camera;
    CharacterController characterController;
    GameObject GroundPlane;
    GameObject FemaleDummy;
    public float speed = 0.01f;
    public float speedRotation = 3;
    public bool isMoving = false;
    public Vector3 end;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    IEnumerator Move (Vector3 moveEnd)
    {
        isMoving = true;
        var iniPosition = transform.position;
        while(Math.Abs(transform.position.x) < Mathf.Abs(moveEnd.x) && Mathf.Abs(transform.position.z) < Mathf.Abs(moveEnd.z) )
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            yield return new WaitForSeconds(1.0f);
            Debug.Log("move: " + transform.position.x.ToString() + "; " + transform.position.y.ToString());
        }
        isMoving = false;
    }

    void SetPosition()
    {
        transform. LookAt(end + transform.position);
        Debug.Log(transform.position.x.ToString() + "; " + transform.position.y.ToString()+ "; " + transform.position.z.ToString());

    }

    void Update () 
    {
        GameObject hitObject; //базовый класс всех объектов сцены
        RaycastHit hit; //объект пересечения
        Ray ray = camera.ScreenPointToRay(Input.mousePosition); //луч «зрения»
        
        
        //Debug.DrawRay (camera.position, camera.rotation * Vector3.forward * 100.0f);
        if (Physics.Raycast (ray, out hit))
        {
            hitObject = hit.collider.gameObject; //объект пересечения
            if (hitObject == GroundPlane)
            {
                if(!isMoving)
                {
                    SetPosition();
                }
                end = hit.point; //координаты точки пересечения

                StartCoroutine(Move(end));
            }
        }
    }
}
