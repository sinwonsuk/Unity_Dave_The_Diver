using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Alpha_Image : MonoBehaviour
{
    // Start is called before the first frame update

    float alpha = 0.0f;

    Image image;



    void Start()
    {
        image = GetComponent<Image>();

        image.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        alpha += Time.deltaTime;

        image.color = new Color(1, 1, 1, alpha);

        if(alpha  >= 1 )
        {
            Scene_Manager.Getinstance().TitleOn();
        }

    }
}
