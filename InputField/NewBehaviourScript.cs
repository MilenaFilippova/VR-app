using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    CharacterController characterController;

    public InputField InputX;
    public InputField InputZ;
    public Text TextX;
    public Text TextZ;
    public Text TextS;

    public float speed = 0.001F;
    public float speedRotation = 0.05f;
    private float step;
    public float startX;
    public float startZ;


   // public Vector3 end = new Vector3(0, 0, 0);

    void Start () 
    {
        characterController = GetComponent<CharacterController>();
        startX = float.Parse(InputX.text);
        startZ = float.Parse(InputZ.text);

        Vector3 end = new Vector3(startX, 0, startZ);
    }
    
    // Update is called once per frame
    void Update () 
    {
        Vector3 interval = end - transform.position;
        //вращения задаются в кватернионах
        Quaternion rot = Quaternion.LookRotation(interval);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, speedRotation);


        //если еще не пришли в конечную точку, то плавно идем
        if (transform.position != end)
        {
            transform.position = Vector3.Lerp(transform.position, end, step);
            step += speed;
        }
        else
        {
            //пришли и все обнулили
            step = 0;
            startX = float.Parse(InputX.text);
            startZ = float.Parse(InputZ.text);
            end = new Vector3(startX, 0, startZ);
        }


        //отправили данные с координатами в текстовые окна на вывод
        TextX.text = ((System.Math.Round(transform.position.x, 2)).ToString());
        TextZ.text = ((System.Math.Round(transform.position.z, 2)).ToString());
        TextS.text = (System.Math.Round((System.Math.Sqrt(System.Math.Pow((transform.position.x - end.x), 2) + System.Math.Pow((transform.position.z - end.z), 2))), 2)).ToString(); 
    }
}
