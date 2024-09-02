using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Dave : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField]
    private GameObject line;

    [SerializeField]
    private Dave_Attack_Move attack_Move;

    float Camera_Speed = 5.0f;

    float attack_Ready_Time = 0.0f;

    Rigidbody Rigidbody;
    enum State
    {
        Start,
        Idle,
        Right_Move,
        Left_Move,
        Up_Move,
        Down_Move,
        Left_Side_Up_Move,
        Right_Side_Up_Move,
        Left_Side_Down_Move,
        Right_Side_Down_Move,
        Left_Attack_Ready,
        Right_Attack_Ready,
        Left_Attack,
        Right_Attack,   
    }


    [SerializeField]
    private new Camera camera;


    private Vector3 StartPos;

    private float Speed = 5.0f;

    private Animator animator;

    private State state = State.Start;

   
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
       
        StartPos = transform.position;
        animator = GetComponent<Animator>();    
    }


    void CameraMove()
    {
        if (transform.position.x <= 18 && transform.position.x >= -17)
        {
            if (state == State.Right_Move)
            {
                camera.transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
            }
            if (state == State.Left_Move)
            {
                camera.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
            }
        }

        if (transform.position.y <= 32 && transform.position.y >= -21)
        {
            if (state == State.Down_Move)
            {
                camera.transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.World);
            }
            if (state == State.Up_Move)
            {
                camera.transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.World);
            }
        }
        
    }


    void StateUpdate()
    {
        switch (state)
        {
            case State.Start:
                //Dive();
                break;
            case State.Idle:
                //SetIdle();
                break;
            case State.Right_Move:
                //RightMove();
                break;
            case State.Left_Move:
                //LeftMove();
                break;
            case State.Up_Move:              
                //UpMove();
                break;
            case State.Down_Move:         
               // DownMove();
                break;
            case State.Left_Side_Up_Move:
                //Left_SideMoveUp();
                break;
            case State.Right_Side_Up_Move:
               // Right_SideMoveUp();
                break;
            case State.Left_Side_Down_Move:
                //Left_SideMoveDown();
                break;
            case State.Right_Side_Down_Move:
               // Right_SideMoveDown();
                break;
            case State.Left_Attack_Ready:
               // LeftAttack_Ready();
                break;
            case State.Right_Attack_Ready:
              // RightAttack_Ready();
                break;
            case State.Right_Attack:
                //RightAttack();
                break;
            case State.Left_Attack:
               // LeftAttack();
                break;
            default:
                break;
        }
    }

    void ChangeState(State _state) 
    {
        state = _state;
    }

    void ChildSetActive_Attack_Ready(bool _check)
    {
        if(_check ==true)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if(i==3)
                {
                    continue;
                }
                gameObjects[i].SetActive(true);
            }
        }
        else
        {
            gameObjects[3].SetActive(true);

            for (int i = 4; i < gameObjects.Count; i++)
            {
                gameObjects[i].SetActive(false);
            }
        }



    }
    void ChildSetActive_Off()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(false);
        }
    }
    void Dive()
    {
        Vector3 PrevPos = transform.position;

        float posX = Mathf.Cos(-Time.time * 1.5f + 180 * Mathf.Deg2Rad);
        float posY = Mathf.Sin(-Time.time * 1.5f);

        if (posX <= 0.2f)
        { 

            transform.position = new Vector3(posX * 10 + StartPos.x, posY * 10 + StartPos.y);
            Vector2 newPos = transform.position - PrevPos;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);        
        }

       else if(posX > 0.25f)
       {
            transform.rotation = Quaternion.identity;
            animator.SetTrigger("Idle_Start");        
            state = State.Idle;
       }
    }

    void SetIdle()
    {
        if (camera.fieldOfView <= 10.0)
        {
            //러프를 써야 할까 

            camera.fieldOfView += Time.deltaTime * Camera_Speed*2.0f;
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Side_Moving", true);
            ChangeState(State.Left_Move);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Side_Moving", true);
            ChangeState(State.Right_Move);
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            animator.SetBool("Up_Moving", true);
            ChangeState(State.Up_Move);
            return;
        }

        if (Input.GetKey(KeyCode.S))
        { 
            transform.rotation = Quaternion.Euler(0, 0, -90);
            animator.SetBool("Down_Moving", true);
            ChangeState(State.Down_Move);
            return;
        }

        if(Input.GetMouseButton(1))
        {
            attack_Ready_Time += Time.deltaTime;
        }


        if (Input.GetMouseButton(1) && transform.eulerAngles.y > 0 && attack_Ready_Time > 0.5f)
        {
            attack_Ready_Time = 0.0f;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Attack_Ready", true);
            ChildSetActive_Attack_Ready(true);
            ChangeState(State.Left_Attack_Ready);
            return;
        }
        if (Input.GetMouseButton(1) && attack_Ready_Time > 0.5f)
        {
            attack_Ready_Time = 0.0f;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Attack_Ready", true);
            ChildSetActive_Attack_Ready(true);
            ChangeState(State.Right_Attack_Ready);
            return;
        }   
    }

    void LeftMove()
    {
        animator.SetBool("Side_Moving", true);

        if (Input.GetKey(KeyCode.A))
        {

           transform.Translate(Vector3.left *Speed*Time.deltaTime, Space.World);
        }



        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 180, 45);
            animator.SetTrigger("Side_To_Side_Up");
            ChangeState(State.Left_Side_Up_Move);
            return;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {

            transform.rotation = Quaternion.Euler(0, 180, -45);
            animator.SetTrigger("Side_To_Side_Down");
            ChangeState(State.Left_Side_Down_Move);
            return;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Side_Moving", false);
            ChangeState(State.Idle);
            return;
        }

        if (Input.GetMouseButton(1))
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Side_Moving", false);
            animator.SetBool("Attack_Ready", true);
            ChildSetActive_Attack_Ready(true);
            ChangeState(State.Left_Attack_Ready);
            return;
        }

        if (!Input.anyKey)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Side_Moving", false);
            ChangeState(State.Idle);
            return;
        }


    }

    void RightMove()
    {
        animator.SetBool("Side_Moving", true);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
        }



        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            animator.SetTrigger("Side_To_Side_Up");
            ChangeState(State.Right_Side_Up_Move);
            return;
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {

            transform.rotation = Quaternion.Euler(0, 0, -45);
            animator.SetTrigger("Side_To_Side_Down");
            ChangeState(State.Right_Side_Down_Move);
            return;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Side_Moving", false);
            ChangeState(State.Idle);
            return;
        }

        if (Input.GetMouseButton(1))
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Side_Moving", false);
            animator.SetBool("Attack_Ready", true);
            ChildSetActive_Attack_Ready(true);
            ChangeState(State.Right_Attack_Ready);
            return;
        }

        if (!Input.anyKey)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Side_Moving", false);
            ChangeState(State.Idle);
            return;
        }
    }

    void DownMove()
    {
        animator.SetBool("Down_Moving", true);

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, -45);
            animator.SetTrigger("Down_To_Side_Down");
            ChangeState(State.Left_Side_Down_Move);
            return;
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
            animator.SetTrigger("Down_To_Side_Down");
            ChangeState(State.Right_Side_Down_Move);
            return;
        }


        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Down_Moving", false);
            ChangeState(State.Idle);
            return;
        }


        if (!Input.anyKey)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Up_Moving", false);
            ChangeState(State.Idle);
            return;
        }

    }

    void UpMove()
    {
        animator.SetBool("Up_Moving", true);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.World);
        }


        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, -180, 45);
            animator.SetTrigger("Up_To_Side_Up");
            ChangeState(State.Left_Side_Up_Move);
            return;
        }


        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            animator.SetTrigger("Up_To_Side_Up");
            ChangeState(State.Right_Side_Up_Move);
            return;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Up_Moving", false);
            ChangeState(State.Idle);
            return;
        }

        if (!Input.anyKey)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Up_Moving", false);
            ChangeState(State.Idle);
            return;
        }

    }

   void Left_SideMoveUp()
   {
        animator.SetBool("Side_Moving", false);
        animator.SetBool("Up_Moving", false);

        if (Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1,1,0) *Speed *Time.deltaTime,Space.World);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetTrigger("Side_To_Side_Up");
            ChangeState(State.Left_Move);
            return;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            animator.SetTrigger("Up_To_Side_Up");
            ChangeState(State.Up_Move);
            return;
        }
   }

   void Right_SideMoveUp()
   {
        animator.SetBool("Side_Moving", false);
        animator.SetBool("Up_Moving", false);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 1, 0) * Speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetTrigger("Side_To_Side_Up");
            ChangeState(State.Right_Move);
            return;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            animator.SetTrigger("Up_To_Side_Up");
            ChangeState(State.Up_Move);
            return;
        }

   }






    void Left_SideMoveDown()
    {
       animator.SetBool("Side_Moving", false);
       animator.SetBool("Down_Moving", false);

       if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
       {
           transform.Translate(new Vector3(-1, -1, 0) * Speed * Time.deltaTime, Space.World);
       }

       if (Input.GetKeyUp(KeyCode.S))
       {
           transform.rotation = Quaternion.Euler(0, 180, 0);
           animator.SetTrigger("Side_To_Side_Down");
           ChangeState(State.Left_Move);
           return;
       }

       if (Input.GetKeyUp(KeyCode.A))
       {
           transform.rotation = Quaternion.Euler(0, 0, -90);
           animator.SetTrigger("Down_To_Side_Down");
           ChangeState(State.Down_Move);
           return;
       }
    }

    void Right_SideMoveDown()
    {
        animator.SetBool("Side_Moving", false);
        animator.SetBool("Down_Moving", false);

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, -1, 0) * Speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetTrigger("Side_To_Side_Down");
            ChangeState(State.Right_Move);
            return;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            animator.SetTrigger("Down_To_Side_Down");
            ChangeState(State.Down_Move);
            return;
        }
    }
    void LeftAttack_Ready()
    {
        if (camera.fieldOfView > 8.0)
        {
            //러프를 써야 할까 

            camera.fieldOfView -= Time.deltaTime * Camera_Speed;
        }

        if (Input.GetMouseButtonUp(1))
        {
            ChildSetActive_Off();
            animator.SetBool("Attack_Ready", false);
            ChangeState(State.Idle);
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {

            ChildSetActive_Attack_Ready(false);
            line.SetActive(true);
            attack_Move.Set_Stop(true);
            ChangeState(State.Left_Attack);
            return;
        }
    }

    void RightAttack_Ready()
    {
        if(camera.fieldOfView > 8.0)
        {
            //러프를 써야 할까 

            camera.fieldOfView -= Time.deltaTime * Camera_Speed;
        }

        if (Input.GetMouseButtonUp(1))
        {
            ChildSetActive_Off();

            animator.SetBool("Attack_Ready", false);
            ChangeState(State.Idle);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            line.SetActive(true);
            ChildSetActive_Attack_Ready(false);
            attack_Move.Set_Stop(true);
            ChangeState(State.Right_Attack);
            return;
        }

    }

    void LeftAttack()
    {
        //transform.get
        if (line.transform.localScale.x < 0)
        {
            line.transform.localScale = new Vector3(0.0f, 1.0f, 1.0f);
            ChildSetActive_Off();
            attack_Move.Set_Stop(false);
            animator.SetBool("Attack_Ready", false);
            ChangeState(State.Idle);
            return;
        }

    }

    void RightAttack()
    {
        if (line.transform.localScale.x < 0 )
        {
            line.transform.localScale = new Vector3(0.0f, 1.0f, 1.0f);
            ChildSetActive_Off();
            attack_Move.Set_Stop(false);
            animator.SetBool("Attack_Ready", false);
            ChangeState(State.Idle);
            return;
        }

    }


    void Update()
    {
        Rigidbody.velocity = Vector3.zero;
        CameraMove();

       // StateUpdate();
    }
}
