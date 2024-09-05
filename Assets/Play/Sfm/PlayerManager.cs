using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class PlayerManager : MonoBehaviour
{
    float breat_time = 0;

    public static PlayerManager instance;
    private CharacterController controller;
    private float speed = 5.0f;

    bool left_camera_check = false;
    bool right_camera_check = false;
    bool OutCollision_check = false;


  
    [SerializeField]
    Animator animator;

    [SerializeField]
    GameObject dave;
  
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    GameObject scene_Change_UI;


    [SerializeField]
    In_The_Sea_Alpha in_The_Sea_Alpha;



   


    [SerializeField]
    private List<GameObject> dave_Child_Objects = new List<GameObject>();



    private Dictionary<string, GameObject> dave_Child_dictory = new Dictionary<string, GameObject>();

    [SerializeField]
    private Dave_Attack_Move attack_Move;


    public FsmClass<pSCENE_STATE> fsm = new FsmClass<pSCENE_STATE>();

    private void DaveReset()
    {
        in_The_Sea_Alpha.gameObject.SetActive(true);      
    }

    private void OnEnable()
    {
        Audio_Manager.GetInstance().PlayBgm(Audio_Manager.bgm.Dive);
        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.dave_diving, false);

    }
    private void OnDisable()
    {
        fsm.SetState(pSCENE_STATE.Start);
        transform.localPosition = new Vector3(-14.21837f, 22.78f, -5);
        virtualCamera.transform.localPosition = new Vector3(-12.21837f, 12.93999f, -10f);
        scene_Change_UI.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
       
        
    }

    Vector3 previousPosition;
    Vector3 currentPosition;
    Vector3 movementDirection;

    public Vector3 Get_movementDirection()
    {
        return movementDirection;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "OutCollison")
        {
            scene_Change_UI.SetActive(true);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "OutCollison")
        {
            OutCollision_check = true;

          
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "OutCollison")
        {
            OutCollision_check = false;
             scene_Change_UI.SetActive(false);          
        }
    }

    public void Init()
    {
        fsm.AddFsm(new Dive(this, animator, virtualCamera));

        fsm.AddFsm(new Idle(this, animator, virtualCamera, dave_Child_dictory));

        fsm.AddFsm(new Left_Move(this, gameObject, animator, dave_Child_dictory,controller,speed));

        fsm.AddFsm(new Right_Move(this, gameObject, animator, dave_Child_dictory, controller,speed));

        fsm.AddFsm(new Down_Move(this, gameObject, animator, controller,speed));

        fsm.AddFsm(new Up_Move(this, gameObject, animator, controller, speed));

        fsm.AddFsm(new Left_SideMoveUp(this, gameObject, animator, controller, speed));

        fsm.AddFsm(new Right_SideMoveUp(this, gameObject, animator, controller, speed));

        fsm.AddFsm(new Left_SideMoveDown(this, gameObject, animator, controller, speed));

        fsm.AddFsm(new Right_SideMoveDown(this, gameObject, animator, controller, speed));

        fsm.AddFsm(new LeftAttack_Ready(this, gameObject, animator, dave_Child_dictory, attack_Move, virtualCamera));

        fsm.AddFsm(new RightAttack_Ready(this, gameObject, animator, dave_Child_dictory, attack_Move, virtualCamera));

        fsm.AddFsm(new RightAttack(this, gameObject, animator, dave_Child_dictory, attack_Move, virtualCamera, dave.transform));

        fsm.AddFsm(new LeftAttack(this, gameObject, animator, dave_Child_dictory, attack_Move, virtualCamera));

        fsm.AddFsm(new Wait_After_Attack(this, gameObject, animator, dave_Child_dictory, attack_Move));

    }

 


    public void Awake()
    {
        instance = this;
    }
    void Start()
    {

        controller = GetComponent<CharacterController>();

        Init();
        fsm.SetState(pSCENE_STATE.Start);



        for (int i = 0; i < dave_Child_Objects.Count; i++)      
        {
            dave_Child_dictory.Add(dave_Child_Objects[i].name, dave_Child_Objects[i]);
        }    

        previousPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        breat_time += Time.deltaTime;

        if(breat_time >3.0f)
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.dave_breathe, false);
            breat_time = 0;
        }





        if(OutCollision_check ==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DaveReset();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                scene_Change_UI.SetActive(false);
            }
        }




        if (fsm.Getstate.stateType != pSCENE_STATE.Start )
        {
            if (transform.localPosition.x <= -17.0f )
            {
                Vector3 vector3 = transform.position;

                vector3.x = virtualCamera.transform.position.x;
                vector3.y = transform.position.y;
                vector3.z = -10.0f;
                virtualCamera.Follow = null;
                virtualCamera.transform.position = vector3;
                left_camera_check = true;
            }

            else if (transform.localPosition.x > -17.0f && left_camera_check ==true)
            {
                Vector3 vector3 = transform.position;
                vector3.z = -10.0f;

                virtualCamera.transform.position = vector3;
                virtualCamera.Follow = transform;
                left_camera_check = false;


            }


            if (transform.localPosition.x >= 52)
            {
                Vector3 vector3 = transform.position;

                vector3.x = virtualCamera.transform.position.x;
                vector3.y = transform.position.y;
                vector3.z = -10.0f;
                virtualCamera.Follow = null;

                virtualCamera.transform.position = vector3;

                right_camera_check = true;
            }

            else if (transform.localPosition.x < 52 && right_camera_check == true)
            {
                virtualCamera.Follow = transform;
                right_camera_check = false;
            }

          
        }


       

       // MoveDir();

        fsm.Update();


    }
}
