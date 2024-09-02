using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float speed = 1.0f;

    public float right_Speed = 10.0f;
    public float time = 0.0f;

    Vector3 prev_Position = Vector3.zero;
    //public float time_check = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        prev_Position = transform.position;
    }

    private void FixedUpdate()
    {

      

        transform.position += Vector3.right * right_Speed * Time.deltaTime;


        time += Time.deltaTime;


        if (time < 1.0f)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (time > 2.0f)
        {
            time = 0;
        }

        else if (time > 1.0f)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }

        if(transform.position.x >= 3.0f)
        {
            Vector3 vector3 = prev_Position;

            vector3.x = -3.9f;

            transform.position = vector3;
        }



    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.right * right_Speed * Time.deltaTime;




        //time += Time.deltaTime;


        //if(time < 1.0f)
        //{
        //    transform.position += Vector3.up * speed * Time.deltaTime;
        //}
        //else if (time > 2.0f)
        //{
        //    time = 0;
        //}

        //else if (time > 1.0f)
        //{
        //    transform.position -= Vector3.up * speed * Time.deltaTime;
        //}







    }
}
