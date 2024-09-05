using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Idle : PlayerState
{
   

    float Camera_Speed = 20.0f;

    float attack_Ready_Time = 0.0f;

    CinemachineVirtualCamera virtualCamera;

    Attack_ready_State_Helper attack_Ready_State_Helper;

    float time = 0.0f;

    public Idle(PlayerManager _sceneManager,Animator _animator, CinemachineVirtualCamera _cam, Dictionary<string, GameObject> _dave_Child_dictory) : base(_sceneManager, pSCENE_STATE.Idle)
    {
        dave_Object = _sceneManager.gameObject;
        animator = _animator;
        virtualCamera = _cam;
       

        attack_Ready_State_Helper = new Attack_ready_State_Helper(_dave_Child_dictory);

    }



    public override void Update()
    {
        base.Update();
        time += Time.deltaTime; 


        if(dave_Object.transform.localPosition.x > -17.0f && dave_Object.transform.localPosition.x < 52.0f)
        {
            virtualCamera.Follow = dave_Object.transform;
        }

       


        if (time>  0.5f)
        {
            //CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

            //transposer.m_XDamping = 1.0f;
            //transposer.m_YDamping = 1.0f;
        }
       


        if (virtualCamera.m_Lens.FieldOfView < 80.0)
        {         
            virtualCamera.m_Lens.FieldOfView += Time.deltaTime * Camera_Speed * 2.0f;
        }
        else
        {
            virtualCamera.m_Lens.FieldOfView = 80;

            if (Input.GetKey(KeyCode.A))
            {
                dave_Object.GetComponent<SpriteRenderer>().flipX = true;


              
                animator.SetBool("Side_Moving", true);
                p_Manager.fsm.SetState(pSCENE_STATE.Left_Move);
                return;
            }

            if (Input.GetKey(KeyCode.D))
            {
                dave_Object.GetComponent<SpriteRenderer>().flipX = false;

                animator.SetBool("Side_Moving", true);
                p_Manager.fsm.SetState(pSCENE_STATE.Right_Move);
                return;
            }

            if (Input.GetKey(KeyCode.W))
            {
                dave_Object.GetComponent<SpriteRenderer>().flipX = false;
                dave_Object.transform.rotation = Quaternion.Euler(0, 0, 90);
                animator.SetBool("Up_Moving", true);
                p_Manager.fsm.SetState(pSCENE_STATE.Up_Move);
                return;
            }

            if (Input.GetKey(KeyCode.S))
            {

                if(dave_Object.GetComponent<SpriteRenderer>().flipX == true)
                {
                    dave_Object.GetComponent<SpriteRenderer>().flipX = false;
                }
                

                dave_Object.transform.rotation = Quaternion.Euler(0, 0, 270);
                animator.SetBool("Down_Moving", true);
                p_Manager.fsm.SetState(pSCENE_STATE.Down_Move);
                return;
            }

            if (Input.GetMouseButton(1))
            {
                attack_Ready_Time += Time.deltaTime;
            }


            if (Input.GetMouseButton(1) && dave_Object.GetComponent<SpriteRenderer>().flipX == true && attack_Ready_Time > 0.5f)
            {
                attack_Ready_Time = 0.0f;

             
                attack_Ready_State_Helper.Get_dave_Attack_Help_Object()["Attack_Ready_Parent"].transform.rotation = Quaternion.Euler(0, -180, 0);

                attack_Ready_State_Helper.Get_dave_Attack_Help_Object()["Target_Curve_Parent"].transform.rotation = Quaternion.Euler(0, -180, 0);


                dave_Object.GetComponent<SpriteRenderer>().flipX = true;

                animator.SetBool("Attack_Ready", true);

                attack_Ready_State_Helper.Attack_Ready(true);
                p_Manager.fsm.SetState(pSCENE_STATE.Left_Attack_Ready);
                return;
            }

            if (Input.GetMouseButton(1) && attack_Ready_Time > 0.5f && dave_Object.GetComponent<SpriteRenderer>().flipX == false)
            {
                attack_Ready_Time = 0.0f;


                attack_Ready_State_Helper.Get_dave_Attack_Help_Object()["Attack_Ready_Parent"].transform.rotation = Quaternion.Euler(0, 0, 0);

                attack_Ready_State_Helper.Get_dave_Attack_Help_Object()["Target_Curve_Parent"].transform.rotation = Quaternion.Euler(0, 0, 0);
                dave_Object.GetComponent<SpriteRenderer>().flipX = false;

                animator.SetBool("Attack_Ready", true);
                attack_Ready_State_Helper.Attack_Ready(true);
                p_Manager.fsm.SetState(pSCENE_STATE.Right_Attack_Ready);
                return;
            }

        }
       
    }
}
