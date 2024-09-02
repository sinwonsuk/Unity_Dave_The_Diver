using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sea_Dave : MonoBehaviour
{
    enum Sea_Dave_State
    { 
       Idle,
       Walk,
       Sea_Ready,
       Sushi_Ready,
    }

    private void OnEnable()
    {
        Audio_Manager.GetInstance().PlayBgm(Audio_Manager.bgm.Lobby);
        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.amb_lobby_far_bird,true);
        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.amb_lobby_loop, true);
    }
    float time = 0.0f;

    public bool Night_Aftroon_check {  get; private set; }

    public float speed = 1.0f;   
 
    Animator Animator;

    new SpriteRenderer renderer;

    [SerializeField]
    GameObject dive_Log;

    [SerializeField]
    GameObject sushi_Log;


    [SerializeField]
    GameObject alpha_image;

    [SerializeField]
    Image fillimage;

    Vector3 start_transform;


    //Rigidbody Rigidbody;

    Sea_Dave_State sea_Dave_State = Sea_Dave_State.Idle;

    

    void Start()
    {
        
        

        Night_Aftroon_check = false;
        renderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        start_transform = transform.position;       
    }

    private void OnCollisionStay(Collision collision)
    {
        

    }

    private void OnDisable()
    {
        fillimage.fillAmount = 0.0f;
        transform.position = start_transform;
        renderer.flipX = false;
        Animator.SetBool("Ready", false);
    }


    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -0.1661153f && Night_Aftroon_check ==true)
        {
            sushi_Log.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.Vib_lobby_boat_move,false);
                Night_Aftroon_check = false;
                alpha_image.SetActive(true);
                alpha_image.GetComponent<Sprite_Alpha_Image>().change_Scene = Sprite_Alpha_Image.Change_Scene.Sushi;
            }
        }
        else
        {
            sushi_Log.SetActive(false);
        }

 
        if (transform.position.x > -0.114f && Night_Aftroon_check == false)
        {
            dive_Log.SetActive(true);
        }
        else
        {
            dive_Log.SetActive(false);
        }

        if(fillimage.fillAmount >=1)
        {
            Audio_Manager.GetInstance().Sfx_Stop(Audio_Manager.sfx.ui_lobby_dive);
            Night_Aftroon_check = true;
            Animator.SetBool("Walk", false);
            Animator.SetBool("Ready", true);
            sea_Dave_State = Sea_Dave_State.Sea_Ready;
        }






        switch (sea_Dave_State)
        {
            case Sea_Dave_State.Idle:
                {
                    if(Input.GetKey(KeyCode.D))
                    {
                        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.lobby_dave_foot, true,0.6f);
                        Animator.SetBool("Walk", true);
                        renderer.flipX = false;
                        sea_Dave_State = Sea_Dave_State.Walk;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.lobby_dave_foot, true, 0.6f);
                        Animator.SetBool("Walk", true);
                        renderer.flipX = true;
                        sea_Dave_State = Sea_Dave_State.Walk;
                    }


                }
                break;
            case Sea_Dave_State.Walk:
                {
                    

                    if (Input.GetKey(KeyCode.D) && transform.position.x < -0.114f)
                    {
                        transform.Translate(Vector3.right * speed *Time.deltaTime);                      
                    }
                    
                    if (Input.GetKey(KeyCode.A) && transform.position.x > -0.1661153f)
                    {
                        transform.Translate(Vector3.left * speed * Time.deltaTime);                     
                    }


                    if (Input.GetKeyUp(KeyCode.D))
                    {
                        Animator.SetBool("Walk", false);
                        sea_Dave_State = Sea_Dave_State.Idle;
                        Audio_Manager.GetInstance().Sfx_Stop(Audio_Manager.sfx.lobby_dave_foot);

                    }
                    if (Input.GetKeyUp(KeyCode.A))
                    {
                        Animator.SetBool("Walk", false);
                        sea_Dave_State = Sea_Dave_State.Idle;
                        Audio_Manager.GetInstance().Sfx_Stop(Audio_Manager.sfx.lobby_dave_foot);

                    }



                }

                break;
            case Sea_Dave_State.Sea_Ready:
                {
                    time += Time.deltaTime;

                    if(time > 1.0f)
                    {
                        sea_Dave_State = Sea_Dave_State.Idle;
                        alpha_image.SetActive(true);
                        alpha_image.GetComponent<Sprite_Alpha_Image>().change_Scene = Sprite_Alpha_Image.Change_Scene.Dive;

                    }
                }
                break;        
            default:
                break;
        }


    }
}
