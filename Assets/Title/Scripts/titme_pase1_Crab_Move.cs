using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Pase1_Crab_Move : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed = -5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Speed*Time.deltaTime,0,0));
    }
}
