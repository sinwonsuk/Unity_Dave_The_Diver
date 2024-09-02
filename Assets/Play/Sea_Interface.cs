using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sea_Interface : MonoBehaviour
{
    // Start is called before the first frame update


    public List<GameObject> sea_Interfaces = new List<GameObject>();

    void Start()
    {
         for (int i = 0; i < 5; i++) 
        {
            //Vector3 vector3 = sea_Interfaces[i].transform.position;

            //vector3.y -= 100.0f;

            //sea_Interfaces[i].transform.position = vector3;
           // Instantiate(sea_Interfaces[0],transform.parent);

          
        }

    }

    // Update is called once per frame
    void Update()
    {
       


    }
}
