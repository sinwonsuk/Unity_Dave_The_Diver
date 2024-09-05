using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.name = Json_Manager.Get_Instance().GetFishList().fishlist_array[i].name;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
