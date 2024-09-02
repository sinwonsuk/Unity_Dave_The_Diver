using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BanCho_Alpha_Image : MonoBehaviour
{
    // Start is called before the first frame update
    Color color;

    bool check = false;

    float time = 0;

    void Start()
    {
        color = new Color(1, 1, 1, 0);
    }

    private void OnDisable()
    {
        color = new Color(1, 1, 1, 0);
        check = false;

    }
    // Update is called once per frame
    void Update()
    {
        if(check ==false)
        {
            if(color.a >=1)
            {
                check = true;
            }


            for (int i = 0; i < transform.childCount-1; i++)
            {
                color.a += Time.deltaTime;
                transform.GetChild(i).GetComponent<Image>().color = color;
            }

            transform.GetChild(transform.childCount-1).GetComponent<TextMeshProUGUI>().color = color;


        }
        if(check == true)
        {          
            if (color.a <= 0)
            {             
                return;
            }
            time += Time.deltaTime;

            if (time >1)
            {
                for (int i = 0; i < transform.childCount - 1; i++)
                {
                    color.a -= Time.deltaTime;
                    transform.GetChild(i).GetComponent<Image>().color = color;
                }

                transform.GetChild(transform.childCount-1).GetComponent<TextMeshProUGUI>().color = color;

            }



        }





    }
}
