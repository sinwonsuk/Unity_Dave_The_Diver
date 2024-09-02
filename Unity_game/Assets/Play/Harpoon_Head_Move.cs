using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.RuleTile.TilingRuleOutput;


public enum Move
{
    Go,
    Stop,
    Pull,
    Turn,
    Wall_Turn,
    None,
}



public class Harpoon_Head_Move : MonoBehaviour
{

    Vector3 Dir;

    //[SerializeField]
    //private List<GameObject> gameObjects = new List<GameObject>();


    //public GameObject GameObject;
    //[SerializeField]
    //private GameObject GameObject2;
    [SerializeField]
    private Inventory_UI Inventory_UI;

   
    Move move = Move.None;

    Vector3 prevPos;

    public Move GetMove()
    {
        return move;
    }

    bool fishCheck = false;
    bool stopCheck = false;
    bool WallCheck = false;


    GameObject fish;

    float speed = 40.0f; 
    float time = 0.0f;

   
    //void Fish_Inventory_Move(string _fishName)
    //{
    //    if(test ==8)
    //    {
    //        RectTransform rectTransform = GameObject2.transform.parent.parent.GetComponent<RectTransform>();

    //        float temp = rectTransform.sizeDelta.y;

    //        temp += 50.0f;

    //        // 새로운 너비 설정 (기존 높이는 유지)
    //        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, temp);
    //    }

    //    if (test > 8)
    //    {
    //        RectTransform rectTransform = GameObject2.transform.parent.parent.GetComponent<RectTransform>();

    //        float temp = rectTransform.sizeDelta.y;

    //        temp += 100.0f;

    //        // 새로운 너비 설정 (기존 높이는 유지)
    //        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, temp);        
    //    }

    //    for (int i = 0; i < gameObjects.Count; i++)
    //    {
    //        if (gameObjects[i].name == _fishName)
    //        {
    //            Instantiate(gameObjects[i], GameObject2.transform.parent);
    //            test++;
    //            break;
    //        }
    //    }

        
                 
    //}

    public bool GetStopCheck()  
    {
        return stopCheck;
    }

    public bool GetFishCheck()
    {
        return fishCheck;
    }

    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.localPosition;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(fishCheck ==false && collision.gameObject.tag == "Fish" && move == Move.Go)
        {
            fish = collision.gameObject;
            fishCheck = true;
        }

        if (fishCheck == false && collision.gameObject.tag == "Wall" && move == Move.Go)
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.harpoon_pump_shot, false);
            Dir = transform.position- transform.parent.position;
            //Dir.y *= -1;
            speed = 20.0f;
            WallCheck = true;

            Vector3 incomingVector = Dir; 
            incomingVector = incomingVector.normalized;       
            Vector3 normalVector = collision.contacts[0].normal;
           
            Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector);
            reflectVector = reflectVector.normalized;

            Dir = reflectVector;

        }

    }
    void Update()
    {
       // transform.right = rb.velocity;



        if(fishCheck ==true && fish != null)
        {
            Vector3 moveDir = fish.transform.position - transform.position;

            fish.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

          



        }


        if(Input.GetMouseButtonDown(0))
        {
            move = Move.Go;          
        }
        switch (move)
        {
            case Move.Go:
                {
                    if(WallCheck ==true)
                    {
                        move = Move.Wall_Turn;
                    }
                   
                    

                    if (transform.localPosition.x > 0.5f)
                    {
                        gameObject.GetComponent<BoxCollider>().enabled = true;
                    }


                    stopCheck = false;
                  
                    transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));

                    if(transform.localPosition.x > 2.0f)
                    {
                        move = Move.Stop;
                    }

                }
                break;
            case Move.Stop:
                {
                    time += Time.deltaTime;

                    if(time > 1.0f && fishCheck ==false)
                    {
                        move = Move.Turn;
                        time = 0.0f;
                    }

                    if (time > 1.2f && fishCheck == true)
                    {
                        move = Move.Pull;
                        time = 0.0f;
                    }


                }
                break;

            case Move.Pull:
                {


                    if (transform.localPosition.x >= 1.7f)
                    {
                        transform.Translate(new Vector3(Time.deltaTime * -speed, 0, 0));                 
                    }
                    else if (transform.localPosition.x < 1.7f)
                    {
                         time += Time.deltaTime;
                    }

                    if (time > 0.5f)
                    {
                        move = Move.Turn;
                    }



                }
                break;
            case Move.Turn:
                {
                    //for(int i = 1; i <30; i++)
                    //{
                    //    gameObject.GetComponent<Rope_Physics>().segments.RemoveAt(i);
                    //}

                    if (transform.localRotation.z >= 0)
                    {
                        transform.Rotate(new Vector3(0, 0, -1.5f));
                    }

                    else
                    {
                        transform.Rotate(new Vector3(0, 0, 1.5f));
                    }


                    Vector3 Dir = transform.position- transform.parent.position;

                    Dir.z = 0.0f;

                    transform.Translate(-Dir.normalized*Time.deltaTime*speed/2,Space.World);


                    speed += 0.3f;

                    if(Dir.magnitude <= 0.5)
                    {
                        if(fish != null)
                        {
                            fish.SetActive(false);

                            
                            Inventory_UI.Fish_Inventory_Move(Json_Manager.Get_Instance().GetFishList().fishDictionary,fish.name);
                       
                            fish = null;
                        }   
                         
                        gameObject.GetComponent<BoxCollider>().enabled = false;                     
                      
                        // transform.rotation = Quaternion.identity;
                        transform.localRotation = Quaternion.Euler(0, 0,0);

                        transform.localPosition = prevPos;
                        stopCheck = true;
                        speed = 40.0f;
                        fishCheck = false;
                        WallCheck = false;
                        move = Move.None;
                    }

                }
                break;

            case Move.Wall_Turn:
                {


                    transform.right = Dir;

                    transform.Translate(Dir.normalized * Time.deltaTime * speed, Space.World);


                    speed -= Time.deltaTime * 100.0f;

                     if (speed <= 0)
                     {
                        
                         speed = 40.0f;
                         move = Move.Turn;

                     }

                }
                break;
            default:
                break;
        }


       


    }
}
