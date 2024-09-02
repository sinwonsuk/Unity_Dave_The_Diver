using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;
public class Customer : MonoBehaviour
{
    public delegate void customer_Seat_Function(int _seat);


    public customer_Seat_Function customer_Seat_function;

    GameObject collision;
    enum Customer_State
    {
        Move,
        Seat,
        Menu,
        Wait,
        Eat,
        Good,
        Anger,
        BackMove,
    }

    [SerializeField]
    GameObject talk_Effect;

    [SerializeField]
    GameObject Sushi_Info;


    [SerializeField]
    Image wait_gauge;

    [SerializeField]
    Image sushi_Sprite;

    [SerializeField]
    Animator banchoAni;

    [SerializeField]
    GameObject cook_Perfab;


    Transform cook_Transform_Parent;

    [SerializeField]
    GameObject coin;


    List<Menu> menus = new List<Menu>();

    int menuindex = 0;


    float time = 0;

    float Speed = 10.0f;

    int[] arr;

    int seat;

    int arr_index = 0;

    int menu_Count_Check = 0;

    bool one_Check = false;

    bool cook_Check = false;

    bool spacebar_Check = false;

    bool seat_Check = false;


    Customer_State state = Customer_State.Move;

    RectTransform rectTransform;

    Animator animator;


    List<Transform> transforms = new List<Transform>();

    RectTransform seat_Transform { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnCollisionStay2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == "Player")
        {
            collision = _collision.gameObject;
            spacebar_Check = true;           
        }       
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Player")
        {
            collision = null;
            spacebar_Check = false;
        }
    }


    public void Make_Prefab(Transform ins_transform, RectTransform _Seat_transforms, List<GameObject> _menus,Transform _cook_Transform_Parent, int _Seat, customer_Seat_Function _customer_Seat_function)
    {



        GameObject customer = Instantiate(gameObject, ins_transform);

        customer.GetComponent<Customer>().customer_Seat_function = _customer_Seat_function;

        customer.GetComponent<Customer>().seat_Transform = _Seat_transforms;

        customer.GetComponent<Customer>().cook_Transform_Parent = _cook_Transform_Parent;

        customer.GetComponent<Customer>().seat = _Seat; 


        if (_menus != null)
        {
            for (int i = 0; i < _menus.Count; i++)
            {
                if(_menus[i].transform.childCount == 0)
                {
                    continue;
                }

                customer.GetComponent<Customer>().menus.Add(_menus[i].transform.GetChild(0).GetComponent<Menu>());
            }
        }
    }

    void Menu_Choice()
    {
        if (one_Check == false)
        {
            one_Check = true;

            arr = new int[menus.Count];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = -1;
            }


            //  메뉴 count가 전부 0인지 체크 

            for (int i = 0; i < menus.Count; i++)
            {
                if (menus[i].Get_count() == 0)
                {
                    // 매뉴 인덱스 값 순서대로 저장 
                    arr[menu_Count_Check] = i;
                    menu_Count_Check++;
                }
            }

            if (menu_Count_Check == menus.Count)
            {
                sushi_Sprite.sprite = Resources.Load<Sprite>("Sushi/Sushi_Gim");
                return;
            }



            while (true)
            {



                // 매뉴의 인덱스 랜덤으로 값 가져오기 

                menuindex = Random.Range(0, menus.Count);

                //arr의 매뉴 개수가 0인것들 저장해둠


                for (int i = 0; i < arr.Length; i++)
                {


                    if (arr[i] == menuindex)
                    {
                        break;
                    }

                    arr_index++;
                }

                //통과 
                if (arr_index == arr.Length)
                {
                    sushi_Sprite.sprite = Resources.Load<Sprite>(menus[menuindex].Get_sushi_path());
                    menus[menuindex].Set_Mus_count(1);
                    menus[menuindex].Get_text_Count().text = menus[menuindex].Get_count().ToString();
                    break;
                }
                // 다시 
                else
                {
                    arr_index = 0;
                }

            }
        }
    }

    void Cook_Make()
    {
        if (cook_Check == false)
        {
            if (menu_Count_Check == menus.Count)
            {
                cook_Perfab.GetComponent<Cook>().Make_Prefap(cook_Transform_Parent, "Sushi/Sushi_Gim");
            }
            else
            {
                cook_Perfab.GetComponent<Cook>().Make_Prefap(cook_Transform_Parent, menus[menuindex].Get_sushi_path());
            }

            cook_Check = true;
        }
    }

        // Update is called once per frame
        void Update()
        {
           if (spacebar_Check == true && Input.GetKeyDown(KeyCode.Space) && collision != null)
           {
              AnimatorStateInfo stateInfo = collision.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Sushi_Dave_Serve_Idle") && state == Customer_State.Wait)
            {
                Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sushi_customer_served, false);

                if (collision.gameObject.GetComponent<Sushi_Dave>().Get_Sushi_Path() == "Sushi/Sushi_Gim")
                {
                    Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sushi_customer_eat, false);
                    state = Customer_State.Eat;
                    animator.SetTrigger("Eat");
                    collision.gameObject.GetComponent<Sushi_Dave>().Get_animatior().SetTrigger("Back_Idle");
                    collision.transform.Find("Sushi_Give").gameObject.SetActive(false);
                    Sushi_Info.SetActive(false);
                }
                else if (collision.gameObject.GetComponent<Sushi_Dave>().Get_Sushi_Path() == menus[menuindex].Get_sushi_path())
                {
                    Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sushi_customer_eat, false);
                    state = Customer_State.Eat;
                    animator.SetTrigger("Eat");
                    collision.gameObject.GetComponent<Sushi_Dave>().Get_animatior().SetTrigger("Back_Idle");
                    collision.transform.Find("Sushi_Give").gameObject.SetActive(false);
                    Sushi_Info.SetActive(false);
                }

            }


           }  


        



       
            switch (state)
            {
                case Customer_State.Move:
                    {
                        if (seat_Transform.anchoredPosition.x > rectTransform.anchoredPosition.x)
                        {
                            rectTransform.Translate(Vector2.right * Speed * Time.deltaTime);
                        }
                        else
                        {   
                            int random = Random.Range(0, 2);

                            if(random == 0)
                            {
                                Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sushi_customer_enter_talk, false);
                            }
                            else
                            {
                                Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sushi_customer_enter_talk_02, false);
                            }

                            animator.SetTrigger("Menu");                          
                            state = Customer_State.Menu;
                        }

                    }
                    break;
                case Customer_State.Menu:
                    {
                        time += Time.deltaTime;

                        talk_Effect.SetActive(true);

                        if (time > 2)
                        {
                            time = 0;

                            talk_Effect.SetActive(false);
                            animator.SetTrigger("Wait");
                            Sushi_Info.SetActive(true);
                            Menu_Choice();
                            Cook_Make();


                            state = Customer_State.Wait;
                        }
                    }
                    break;
                case Customer_State.Wait:
                    {




                        wait_gauge.fillAmount += Time.deltaTime*0.05f;

                        if (wait_gauge.fillAmount >= 1)
                        {
                           Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sushi_customer_enter_talk_03, false);
                           Sushi_Info.SetActive(false);
                           state = Customer_State.Anger;
                           animator.SetBool("Anger", true);
                        }
                      


                    }
                    break;
                case Customer_State.Eat:
                {
                   

                    time += Time.deltaTime;

                    if(time >=2)
                    {
                        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sound_sushibar_pay, false);
                        time = 0;
                        state = Customer_State.Good;
                        animator.SetTrigger("Happy");
                    }


                }
                    break;
                case Customer_State.Good:
                {

                    time += Time.deltaTime;

                    coin.SetActive(true);


                    if (time > 2.5)
                    {
                        

                      




                        time = 0;
                        state = Customer_State.BackMove;
                        animator.SetTrigger("Back_Move");
                    }

                }
                    break;
                case Customer_State.Anger:
                {

                    time += Time.deltaTime;

                    if (time >= 2)
                    {
                       


                        time = 0;
                        state = Customer_State.BackMove;
                        animator.SetBool("Anger", false);                       
                    }










                }
                break;
                case Customer_State.BackMove:
                {
                    if(seat_Check ==false)
                    {
                        customer_Seat_function(seat);
                       

                       

                        seat_Check = true;
                    }
                  

                   

                    time += Time.deltaTime;
                    rectTransform.localScale = new Vector3(-1, 1, 1);
                    rectTransform.Translate(Vector2.left * Speed * Time.deltaTime);

                    if (time > 3)
                    {
                        Destroy(gameObject);
                    }

                 
                    



                }
                    break;



                default:
                    break;
            }




        }

    internal void Make_Prefab(Transform transform, RectTransform rectTransform, List<GameObject> menus, Transform cook_Transform_Parent, int seat, object v)
    {
        throw new System.NotImplementedException();
    }
}
