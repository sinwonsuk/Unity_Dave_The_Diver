using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAttack_Ready : PlayerState
{
    bool audio_Check = false;

    Dave_Attack_Move attack_Move;

    CinemachineVirtualCamera virtualCamera;

    Attack_ready_State_Helper attack_Ready_State_Helper;


   
    

    public LeftAttack_Ready(PlayerManager _sceneManager, GameObject _gameObject, Animator _animator, Dictionary<string, GameObject> _dave_Child_dictory, Dave_Attack_Move _attack_Move, CinemachineVirtualCamera _camera) : base(_sceneManager, pSCENE_STATE.Left_Attack_Ready)
    {
        dave_Object = _gameObject;
        animator = _animator;
      
        attack_Move = _attack_Move;
        virtualCamera = _camera;

        attack_Ready_State_Helper = new Attack_ready_State_Helper(_dave_Child_dictory);
    }




    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
    }





    public override void Update()
    {
        if(audio_Check ==false)
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.harpoon_aim, false);
            audio_Check =true;
        }

        Time.timeScale = 0.5f;



        base.Update();

        dave_Object.GetComponent<SpriteRenderer>().flipX = true;

        if (virtualCamera.m_Lens.FieldOfView > 60.0)
        {
            //러프를 써야 할까 
            virtualCamera.m_Lens.FieldOfView -= Time.deltaTime * 15.0f;
        }

        if (Input.GetMouseButtonUp(1))
        {
            attack_Ready_State_Helper.ChildSetActive_Off();
            animator.SetBool("Attack_Ready", false);
            Time.timeScale = 1.0f;
            audio_Check = false;
            p_Manager.fsm.SetState(pSCENE_STATE.Idle);    
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            attack_Ready_State_Helper.ChildSetActive_Attack_Ready(false);         
            attack_Move.Set_Stop(true);
            Time.timeScale = 1.0f;
            audio_Check = false;
            p_Manager.fsm.SetState(pSCENE_STATE.Left_Attack);
            return;
        }

    }
}
