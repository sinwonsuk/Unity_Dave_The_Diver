using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UI;
public class MenuMove : MonoBehaviour
{
    // Start is called before the first frame update

   

    [SerializeField]
    GameObject sushi_Info;

    [SerializeField]
    GameObject recipe;


    [SerializeField]
    GameObject normal_Menu;

    [SerializeField]
    GameObject recipe_Focus;

    [SerializeField]
    GameObject select;
    [SerializeField]
    GameObject menu_Focus;



    public float speed = 500f;
    bool MoveOn = false;

    Vector2 first_Position;

    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        first_Position = rectTransform.anchoredPosition;
    }

    private void Move()
    {
        
        if(rectTransform.anchoredPosition.y <= 0 && MoveOn ==true)
        {
            Vector2 TargetPosition = new Vector2(rectTransform.anchoredPosition.x, 0.0f);

            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, TargetPosition, Time.deltaTime *speed);
         
        }      
              
        else if(rectTransform.anchoredPosition.y > first_Position.y && MoveOn ==false)
        {
            Vector2 TargetPosition = new Vector2(rectTransform.anchoredPosition.x, -1000.0f);

            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, TargetPosition, Time.deltaTime * speed);

        }

    }

    public void Reverse_InvenChange()
    {

        sushi_Info.SetActive(false);
        recipe.SetActive(false);
        normal_Menu.SetActive(true);
        recipe_Focus.SetActive(false);
        select.SetActive(true);
        menu_Focus.SetActive(true);

        rectTransform.anchoredPosition = new Vector2(0, 0);
    }

    public void MainMove_On()
    {      
       MoveOn = true;       
    }

    public void MainMove_Off()
    {     
       MoveOn = false;      
    }

    public void InvenChange()
    {
        if (Input.GetKeyDown(KeyCode.Space) && MoveOn == true)
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);

            Vector2 vector2 = Vector2.left * 745;

            rectTransform.anchoredPosition = vector2;

            sushi_Info.SetActive(true);
            recipe.SetActive(true);
            normal_Menu.SetActive(false);
            recipe_Focus.SetActive(true);          
            select.SetActive(false);
        }

    }



    
    // Update is called once per frame
    void Update()
    {
        Move();




    }
}
