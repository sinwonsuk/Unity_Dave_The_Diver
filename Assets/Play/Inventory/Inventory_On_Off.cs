using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory_On_Off : MonoBehaviour
{
    bool on_Off_Check = false;


    [SerializeField]
    private GameObject pannel;

    [SerializeField]
    private GameObject Scroll_View;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && on_Off_Check ==false)
        {
            pannel.SetActive(true);
            Scroll_View.SetActive(true);
            Time.timeScale = 0.0f;
            on_Off_Check = true;
        }
        else if(Input.GetKeyDown(KeyCode.I) && on_Off_Check == true)
        {
            pannel.SetActive(false);
            Scroll_View.SetActive(false);
            Time.timeScale = 1.0f;
            on_Off_Check = false;

        }


    }
}
