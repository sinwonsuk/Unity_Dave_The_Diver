using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Open_Object_false : MonoBehaviour
{
    // Start is called before the first frame update

    float time = 0;
    bool big_Small = false;
    public float speed = 1;
    Image image;

    [SerializeField]
    Customer_Manager customer_Manager;

  

    Vector2 vector2 = new Vector2(0, 0);

    Vector2 prevVector;


    void Start()
    {
        image = GetComponent<Image>();

        prevVector = image.rectTransform.localScale;
    }

    private void OnDisable()
    {
        image.rectTransform.localScale = prevVector;
        big_Small = false;
        image.color = new Color(1, 1, 1, 1);
    }




    // Update is called once per frame
    void Update()
    {
        if(big_Small ==false)
        {
            vector2.x += Time.deltaTime * speed;
            vector2.y += Time.deltaTime * speed;


            if (vector2.x < 1.0f)
            {
                image.rectTransform.localScale = vector2;
             
            }
            else
            {
                big_Small = true;
            }
        }

        if(big_Small ==true)
        {
            time += Time.deltaTime;  

            if(time > 1)
            {
                

               

                vector2.x -= Time.deltaTime * speed;
                vector2.y -= Time.deltaTime * speed;

                Color colr = new Color(255, 255, 255, vector2.x);

              

                if (vector2.x > 0.0f)
                {
                    image.color = colr;
                }
                else
                {
                    gameObject.SetActive(false);
                    customer_Manager.enabled = true;
                }


            }

        }


   
    }
}
