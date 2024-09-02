using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Move : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed = 5.0f;

    public GameObject GameObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Speed*Time.deltaTime*2.0f, Speed * Time.deltaTime, 0.0f));


        if(transform.localPosition.x > -160.0f)
        {
            GameObject.SetActive(true);
        }

    }
}
