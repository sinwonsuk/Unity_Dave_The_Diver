using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAttack_Ready : PlayerState
{
    bool audio_Check = false;

    Dave_Attack_Move attack_Move;

    CinemachineVirtualCamera virtualCamera;

    Attack_ready_State_Helper attack_Ready_State_Helper;



   

    public RightAttack_Ready(PlayerManager _sceneManager, GameObject _gameObject, Animator _animator, Dictionary<string, GameObject> _dave_Child_dictory, Dave_Attack_Move _attack_Move, CinemachineVirtualCamera _camera) : base(_sceneManager, pSCENE_STATE.Right_Attack_Ready)
    {
        dave_Object = _gameObject;
        animator = _animator;      
        attack_Move = _attack_Move;
        virtualCamera = _camera;

        attack_Ready_State_Helper = new Attack_ready_State_Helper(_dave_Child_dictory);
    }




  



    public override void Update()
    {
        if (audio_Check == false)
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.harpoon_aim, false);
            audio_Check = true;
        }


        Time.timeScale = 0.5f;
        base.Update();

        if (virtualCamera.m_Lens.FieldOfView > 60.0)
        {
            //러프를 써야 할까 
            virtualCamera.m_Lens.FieldOfView -= Time.deltaTime * 10.0f;
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
            Time.timeScale = 1.0f;
            //gameObjects[3].GetComponent<LineRenderer>().enabled = true;
            attack_Ready_State_Helper.Attack_Ready(false);
            attack_Move.Set_Stop(true);
            audio_Check = false;
            p_Manager.fsm.SetState(pSCENE_STATE.Right_Attack);
            return;
        }

    }
}
