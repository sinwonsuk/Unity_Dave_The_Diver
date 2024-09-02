using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pase6_Logo : MonoBehaviour
{
    // Start is called before the first frame update

    Image logo;

    float Alpha = 0.0f;

    public pase6_Alpha alpha_Image;

    void Start()
    {
        logo = GetComponent<Image>();

        logo.color = new Color(1.0f, 1.0f, 1.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Alpha += Time.deltaTime * 1.0f;

        logo.color = new Color(1.0f, 1.0f, 1.0f, Alpha);


        if(Alpha > 1.5f)
        {        
            alpha_Image.Set_alpha_Change(true);  
        }

    }
}
