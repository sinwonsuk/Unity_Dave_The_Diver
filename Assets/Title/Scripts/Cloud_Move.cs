using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cloud_Move : MonoBehaviour
{
    // Start is called before the first frame update

    float Pos_X;
    float Pos_Y;
    public float Speed = -1.0f;
    void Start()
    {
       
        Pos_Y = Random.Range(183.0f, 723.0f);

        Pos_X = 1186.0f;
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(new Vector3(Speed * Time.deltaTime*2, Speed * Time.deltaTime, 0));


        if(transform.localPosition.x < -1116.0f)
        {
            Pos_Y = Random.Range(183.0f, 723.0f);

            transform.localPosition = new Vector3(Pos_X, Pos_Y);
        }
    }
}
