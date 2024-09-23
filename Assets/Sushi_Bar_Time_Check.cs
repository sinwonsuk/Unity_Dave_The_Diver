using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sushi_Bar_Time_Check : MonoBehaviour
{
    Image image;
    float close = 0.383f;
    float speed = 0.005f;
    public float time {  get; set;} 


    void Start()
    {
        image = GetComponent<Image>();
    }

    private void OnDisable()
    {
        image.fillAmount = 0;
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        time = image.fillAmount;

        image.fillAmount += Time.deltaTime* speed;

        if(image.fillAmount > close)
        {
            image.fillAmount = close;
        }
    }
}
