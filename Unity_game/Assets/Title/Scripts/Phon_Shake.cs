using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone_Shake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Pos_X = Random.Range(-0.7f, 0.7f);
        float Pos_Y = Random.Range(-0.7f, 0.7f);

        transform.Translate(new Vector3(Pos_X, Pos_Y, 0));
    }
}
