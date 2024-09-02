using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
public class In_The_Sea_Alpha : MonoBehaviour
{



    Image image;
    Color Color;

    

    [SerializeField]
    GameObject Slots;

    void Start()
    {

        image = GetComponent<Image>();
        image.color = new Color(1, 1, 1, 0);
        Color = image.color;
    }

   
   

    private void OnDisable()
    {
        RectTransform rectTransform = Slots.transform.parent.GetComponent<RectTransform>();
        float temp = 850.0f;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, temp);      
        image.color = new Color(1, 1, 1, 0);
        Color.a = 0;
        gameObject.SetActive(false);
    }




    // Update is called once per frame
    void Update()
    {
        Color.a += Time.deltaTime * 0.5f;

        image.color = Color;


        if (image.color.a >=1)
        {
            Scene_Manager.Getinstance().aftroon_or_night_Check = true;
            Scene_Manager.Getinstance().Change_from_dive_to_sea();
        }
    }
}
