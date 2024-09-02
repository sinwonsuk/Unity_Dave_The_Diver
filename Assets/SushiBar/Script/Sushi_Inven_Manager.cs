using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum On_Off
{
    Main_Menu_On,
    Main_Menu_Off,
    Main_Menu,
    Recipe,
    Recipe_Off,
    Menu_Add,
    Recipe_Add_Off,


}

public class Sushi_Inven_Manager : MonoBehaviour
{
    On_Off on_Off = On_Off.Main_Menu_Off;


       // Start is called before the first frame update

    [SerializeField]
    GameObject recipe;

    [SerializeField]
    GameObject food_Add;

    [SerializeField]
    GameObject today_Sushi_Menu_Info;

    [SerializeField]
    GameObject menu;

    [SerializeField]
    Transform menu_Parent;


    [SerializeField]
    MenuMove menuMove;

    [SerializeField]
    Menu_Select main_Menu_Select_Move;


    [SerializeField]
    Recipe_Focus recipe_Focus;

    // √ ±‚»≠
    int menu_add = 0;



    int input = 0;
    int count = 0;
    int main_Menu_Input = 0;

    GameObject temp;


    List<GameObject> prefab = new List<GameObject>();

    List<int> Main_Menu_Inputs = new List<int>();

 

    bool Check = false;

    void Menu_Control()
    {

        switch (on_Off)
        {

            case On_Off.Main_Menu_Off:
                {
                    if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                    {
                        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);
                        menuMove.MainMove_On();
                        on_Off = On_Off.Main_Menu_On;
                    }                 
                }
                break;
            case On_Off.Main_Menu_On:
                {

                    main_Menu_Input = main_Menu_Select_Move.SelectMove();

                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);
                        menuMove.MainMove_Off();
                        on_Off = On_Off.Main_Menu_Off;
                    }

                   

                    for (int i = 0; i < Main_Menu_Inputs.Count; i++)
                    {               
                        if (Main_Menu_Inputs[i] == main_Menu_Input)
                        {
                            Check = true;
                            return;
                        }
                        else
                        {
                            Check = false;
                        }
                    }

                    if (Check == false)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);

                            menuMove.InvenChange();
                            on_Off = On_Off.Recipe;
                            Check = true;
                        }
                    }




                }
                break;
            case On_Off.Recipe:
                {
                    Check = false;

                    Controll();

                    recipe_Focus.Sushi_Icon_Move();


                    int _count = int.Parse(prefab[input].transform.Find("Sushi_Recipe_Info").Find("Meat_Count").GetComponent<TextMeshProUGUI>().text);


                    if (Input.GetKeyDown(KeyCode.Space) && _count>=1)
                    {
                        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);

                        string Sushi_Name = prefab[input].transform.Find("Sushi_Recipe_Info").Find("Fish_Name").GetComponent<TextMeshProUGUI>().text;


                        food_Add.GetComponent<Sushi_Slot>().Make_PreFab(Sushi_Name, transform.Find("Recipe"), ref temp);

                        on_Off = On_Off.Menu_Add;
                    }

                    else if (Input.GetKeyDown(KeyCode.C))
                    {
                        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);

                        menuMove.Reverse_InvenChange();

                        on_Off = On_Off.Main_Menu_On;

                        input = 0;
                    }

                }
                break;
         
            case On_Off.Menu_Add:
                {

                    if (temp != null)
                    {
                        if (Input.GetKeyDown(KeyCode.C))
                        {
                            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);

                            input = 0;
                            Destroy(temp);

                            on_Off = On_Off.Recipe;
                        }

                        count = temp.GetComponent<Sushi_Slot>().Food_Add_Mus();

                        if(Input.GetKeyDown(KeyCode.Space) && count >=1)                          
                        {
                            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);

                            string Sushi_Name = prefab[input].transform.Find("Sushi_Recipe_Info").Find("Fish_Name").GetComponent<TextMeshProUGUI>().text;

                            menu.GetComponent<Menu>().Make_PreFab(Sushi_Name, menu_Parent.GetChild(menu_add), count);

                            menu_add += 1;

                            temp.GetComponent<Sushi_Slot>().Count_Change_And_Destory(prefab[input], Sushi_Name);

                            menuMove.Reverse_InvenChange();

                           
                            today_Sushi_Menu_Info.GetComponent<Today_Sushi_Menu_Info>().Make_PreFab(Sushi_Name, transform.GetChild(main_Menu_Input),count);

                            Main_Menu_Inputs.Add(main_Menu_Input);


                            input = 0;


                            on_Off = On_Off.Main_Menu_On;
                        }                     
                    }

                   


                }
                break;          
            default:
                break;
        }







      

       




    }

    void Controll()
    {
        

        if (Input.GetKeyDown(KeyCode.D))
        {
            input += 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            input += 4;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            input -= 4;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            input -= 1;
        }




        for (int i = 0; i < prefab.Count; i++)
        {
            if(input < 0)
            {
                input = 0;
                return;
            }

            if (input > prefab.Count - 1)
            {
                input = prefab.Count - 1;
                return;
            }

            if (input == i)
            {
                for (int j = 0; j < prefab[i].transform.childCount; j++)
                {
                    prefab[i].transform.GetChild(j).gameObject.SetActive(true);
                }
            }
            else
            {
                for (int j = 0; j < prefab[i].transform.childCount; j++)
                {
                    if (j <= 2)
                    {
                        prefab[i].transform.GetChild(j).gameObject.SetActive(true);
                    }

                    else
                    {
                        prefab[i].transform.GetChild(j).gameObject.SetActive(false);
                    }
                }


            }
        }

    }

    private void OnEnable()
    {
        recipe.GetComponent<Sushi_Recipe>().Make_PreFab(transform.Find("Recipe"), prefab);
    }
    private void OnDisable()
    {
        for (int i = 0; i < prefab.Count; i++)
        {
            Destroy(prefab[i]);
        }


        prefab.Clear();
        prefab = new List<GameObject>();
        Main_Menu_Inputs.Clear();
        Main_Menu_Inputs = new List<int>();
        on_Off = On_Off.Main_Menu_Off;
        menu_add = 0;
        input = 0;
        count = 0;
        main_Menu_Input = 0;
        Check = false;




    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Menu_Control();




    }
}
