using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Move : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 move = Vector3.right;

    private float speed = 2.0f;
    bool CollisionCheck = false;



    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {


       

        if(CollisionCheck ==false)
        {
            move *= -1;
            CollisionCheck = true;
        }
       
        //else if (move.x <= 0)
        //{
        //    move.x = Random.Range(0.0f, 1.0f);        
        //}

        //if(move.y >=0)
        //{
        //    move.y = Random.Range(0.0f, -1.0f);
        //}

        //else if (move.y <= 0)
        //{
        //    move.y = Random.Range(0.0f, 1.0f);
        //}


        //move.x = Random.Range(0.0f, 1.0f);
        //move.y = Random.Range(0.0f, 1.0f);
    }


    // Update is called once per frame
    void Update()
    {


      

         transform.Translate(move.normalized * speed *Time.deltaTime);
    }
}
