using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sushi_Bar_Time_Check : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update

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


        image.fillAmount += Time.deltaTime*0.005f;

        if(image.fillAmount > 0.383)
        {
            image.fillAmount = 0.383f;
        }


    }
}
