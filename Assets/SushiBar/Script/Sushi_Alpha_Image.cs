using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sushi_Alpha_Image : MonoBehaviour
{
    Image image;

    public float alpha {  get; private set; }

    public bool alpha_Up_Down_Check {  get; set; }


    private void OnDisable()
    {
        gameObject.SetActive(false);
        alpha_Up_Down_Check = false;
    }


    void Start()
    {
        alpha_Up_Down_Check = false;

        image = GetComponent<Image>();

        image.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha_Up_Down_Check ==false)
        {
            alpha += Time.deltaTime;
        }   

        else if (alpha_Up_Down_Check == true)
        {
            alpha -= Time.deltaTime;
        }
    
        image.color = new Color(1, 1, 1, alpha);
    }
}
