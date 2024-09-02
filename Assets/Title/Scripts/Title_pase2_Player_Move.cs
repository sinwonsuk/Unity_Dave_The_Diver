using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Pse2_Player_Move : MonoBehaviour
{
    // Start is called before the first frame update
    float Speed = 70.0f;

    float time = 0.0f;

    float time_Control = 7.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time < time_Control)
        {
            transform.Translate(new Vector3(Speed * Time.deltaTime, 0.0f, 0.0f));
        }
       
    }
}
