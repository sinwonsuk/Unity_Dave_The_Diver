using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pase6_Alpha : MonoBehaviour
{
    // Start is called before the first frame update

    Image image;

    float time = 0.0f;

    float alpha = 1.0f;

    bool alpha_Change = false;

    public void Set_alpha_Change(bool _alpha_Change)
    {
        alpha_Change = _alpha_Change;
    }

    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha_Change ==false)
        {
            alpha -= Time.deltaTime;
        }

        if (alpha_Change == true)
        {
            alpha += Time.deltaTime;
        }


        image.color = new Color(1.0f, 1.0f, 1.0f, alpha);

        if(alpha <= 0)
        {
            alpha = 0;        
        }

        else if(alpha >= 1)
        {
           
            alpha = 1;

            time += Time.deltaTime;

            if(time > 0.5f)
            {
                Scene_Manager.Getinstance().Change_from_Title_to_sea();
            }

           
        }

    }
}
