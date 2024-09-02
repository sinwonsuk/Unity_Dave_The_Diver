using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Pase_Wave_Move : MonoBehaviour
{
    // Start is called before the first frame update


    public float Speed = 1.0f;

    float time = 0.0f;

    public float wave_time = 0.7f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;


        if (time < wave_time)
        {
            transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
        }

        else if (time > wave_time && time < wave_time * 2.0f)
        {
            transform.Translate(new Vector3(0, Speed * Time.deltaTime, 0));       
        }
        else if(wave_time * 2.0f > 1.4)
        {
            time = 0;
        }


    }
}
