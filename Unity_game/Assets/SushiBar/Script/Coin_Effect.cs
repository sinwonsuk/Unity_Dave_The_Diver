using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Coin_Effect : MonoBehaviour
{
    // Start is called before the first frame update

    float time = 0;

    float speed = 0.7f;

   Image Image;

    Color color;

    void Start()
    {
        color = new Color(1, 1, 1, 1);

        Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time < 1)
        {
            transform.Translate(Vector3.up*speed *Time.deltaTime);
        }
        if(time > 1)
        {
            
            color.a -= Time.deltaTime;

            Image.color = color;
        }

    }
}
