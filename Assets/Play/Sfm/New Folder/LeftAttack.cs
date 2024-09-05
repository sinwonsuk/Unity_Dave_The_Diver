using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAttack : PlayerState
{
    bool audio_Check = false;

    Dave_Attack_Move attack_Move;

    CinemachineVirtualCamera virtualCamera;

    Attack_ready_State_Helper attack_State_Helper;



    Vector3 previousCameraPos= Vector3.zero;

    float Attack_Speed = 5.0f;

    float attack_Time = 0.0f;

   



    public LeftAttack(PlayerManager _sceneManager, GameObject _gameObject, Animator _animator, Dictionary<string, GameObject> _dave_Child_dictory, Dave_Attack_Move _attack_Move, CinemachineVirtualCamera _virtualCamera) : base(_sceneManager, pSCENE_STATE.Left_Attack)
    {
        dave_Object = _gameObject;
        animator = _animator;
       
        attack_Move = _attack_Move;
        virtualCamera = _virtualCamera;


        attack_State_Helper = new Attack_ready_State_Helper(_dave_Child_dictory);
    }









    public override void Update()
    {
       

        if (audio_Check == false)
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.harpoon_shot, false);
            audio_Check = true;
        }


        //virtualCamera.Follow = null;
        //virtualCamera.LookAt = null;


        Vector3 KnockBack =dave_Object.transform.position - attack_State_Helper.Get_dave_Attack_Help_Object()["Harpon_Head"].transform.position;



        attack_Time += Time.deltaTime;

        if(attack_Time < 0.3f)
        {
            Attack_Speed += 0.1f;

            //virtualCamera.transform.Translate(KnockBack.normalized * Attack_Speed * Time.deltaTime, Space.World);            
            
            dave_Object.transform.Translate(KnockBack.normalized * Attack_Speed * Time.deltaTime, Space.World);

        }

 
         if (attack_State_Helper.Get_dave_Attack_Help_Object()["Harpon_Head"].GetComponent<Harpoon_Head_Move>().GetFishCheck() == true && attack_State_Helper.Get_dave_Attack_Help_Object()["Harpon_Head"].GetComponent<Harpoon_Head_Move>().GetMove() == Move.Stop)
        {
            virtualCamera.GetComponent<DD_Camera>().StartScreenShake(1.8f, 0.15f);                
            Attack_Speed = 0.0f;
            attack_Time = 0.0f;
            audio_Check = false;
            animator.SetBool("Wait_After_Attack", true);

            p_Manager.fsm.SetState(pSCENE_STATE.Wait_After_Attack);
        }



        if (attack_State_Helper.Get_dave_Attack_Help_Object()["Harpon_Head"].gameObject.GetComponent<Harpoon_Head_Move>().GetStopCheck() == true)
        {
          
            Attack_Speed = 0.0f;
            attack_Time = 0.0f;
            attack_State_Helper.ChildSetActive_Off();
            attack_Move.Set_Stop(false);
            audio_Check = false;
            animator.SetBool("Attack_Ready", false);
            p_Manager.fsm.SetState(pSCENE_STATE.Idle);
            return;
        }

    }
}
