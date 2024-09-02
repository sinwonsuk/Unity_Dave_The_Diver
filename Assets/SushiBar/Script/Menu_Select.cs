using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Select : MonoBehaviour
{
    // Start is called before the first frame update

    RectTransform RectTransform;
    Vector2 PrevMove;

    int input_num = 4;

    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        PrevMove = RectTransform.anchoredPosition;
    }

    void Move()
    {
          
        if(RectTransform.anchoredPosition.y > PrevMove.y)
        {
            RectTransform.anchoredPosition = PrevMove;
        }
        else if(RectTransform.anchoredPosition.y < PrevMove.y)
        {
            RectTransform.anchoredPosition = PrevMove;
        }


    }

    public int SelectMove()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (RectTransform.anchoredPosition.y <= -425.0f)
            {
                return input_num;
            }
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);

            input_num += 1;
            PrevMove.y -= 142.0f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (RectTransform.anchoredPosition.y >= 0.0f)
            {
                return input_num;
            }
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);

            input_num -= 1;

            PrevMove.y += 142.0f;
        }




        Move();
        return input_num;
    }


    // Update is called once per frame
    void Update()
    {

  

        



    }
}
