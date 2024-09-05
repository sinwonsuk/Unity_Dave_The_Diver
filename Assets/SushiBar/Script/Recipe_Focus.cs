using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class Recipe_Focus : MonoBehaviour
{
    // Start is called before the first frame update

    int input = 0;

    int CountY = 0;

    float rangeX = 85f;

    float rangeY = 86f;

    RectTransform rectTransform;

    Vector2 PrevPos = new Vector2();

    Vector2 start_pos = new Vector2();

    Vector2 vector2 = new Vector2();

    private void Move()
    {
        if(input > 4)
        {
            input = 4;
            return;
        }

        if (input < 0 && CountY <= 0)
        {
            input = 0;
            return;
        }

        if (input+ CountY*4 > Json_Manager.Get_Instance().GetFishList().fishlist_array.Length-1)
        {
            input = Json_Manager.Get_Instance().GetFishList().fishlist_array.Length-1;

            input-= CountY*4;

            return;
        }

        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);


        if (input < 0)
        {
            input += 4;

            CountY--;

            vector2.x = PrevPos.x + input * rangeX;
            vector2.y = PrevPos.y - rangeY * CountY;

        }


        if (input > 3)
        {
            input -= 4;
            CountY++;
            vector2.x = PrevPos.x + input * rangeX;
            vector2.y = PrevPos.y - rangeY * CountY;
        }
        else
        {
            vector2.x = PrevPos.x + input * rangeX;           
        }










        rectTransform.anchoredPosition = vector2;
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        PrevPos = rectTransform.anchoredPosition;
        start_pos = rectTransform.anchoredPosition;
        vector2.y = PrevPos.y;
    }

    private void OnDisable()
    {
        input = 0;

        CountY = 0;

        rangeX = 85f;

        rangeY = 86f;


        rectTransform.anchoredPosition = start_pos;
        vector2 = start_pos;
        PrevPos = start_pos;

    }

    public void Sushi_Icon_Move()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.D))
        {
            input += 1;
            Move();
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.A))
        {
            input -= 1;
            Move();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.S))
        {
            input += 4;
            Move();
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
        {
            input -= 4;
            Move();
        }
    }

    // Update is called once per frame
    void Update()
    {
      





       





      

    }
}
