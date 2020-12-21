using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube2 : MonoBehaviour {


	public GameObject StartButton, StopButton, Cube;
	bool on = false;
	float timer = 5.0f;
	float maxX = 0;
	float minX = 0;
	public float rayDistance;
	public Vector3 hitpoint;
	public bool go = false;

	void Start()
	{
		StartButton = GameObject.Find("StartButton");
		StopButton = GameObject.Find("StopButton");
		Cube = GameObject.Find("Cube");

		minX = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x + 0.3f;
        maxX = -minX;
	}


	//метод update
	void Update()
	{
		//Reycast на мышь
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		//отрисовка Reycast
        Debug.DrawRay(transform.position, ray.direction * rayDistance);
        

        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
            	Debug.Log("yeeeeeeeees");

                if(hit.collider.gameObject.name == "StartButton")
                {
                    Debug.Log("StartButton");
                    Cube.transform.Translate(2, 0, 0); 
					//таймер
					timer = Time.deltaTime;
					//Debug.Log(timer);
					if (timer < 0.0f)
					{
						on = !on;
						timer = 5.0f;
					}
					go = true;
					
				}
				 if(hit.collider.gameObject.name == "StopButton")
                {
                    Debug.Log("StopButton");
					go = false;
				}
				if(hit.collider.gameObject.name == "Cube")
                {
                    Debug.Log("Cube");
				}
			}
		}
		Debug.Log("x= " + Cube.transform.position.x);
        if(Cube.transform.position.x > maxX  & Cube.transform.position.x < minX )
        {
        	go = false;
        }
        if(go)
        {
        	Cube.transform.Translate(1, 0, 0);
        	Debug.Log("t = " + timer);
        }


	}


}
