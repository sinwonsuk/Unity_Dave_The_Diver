using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wait_After_Attack : PlayerState
{
    bool audio_Check = false;


    Dave_Attack_Move attack_Move;


    Attack_ready_State_Helper attack_Ready_State_Helper;

    public Wait_After_Attack(PlayerManager _sceneManager, GameObject _gameObject, Animator _animator, Dictionary<string, GameObject> _dave_Child_dictory, Dave_Attack_Move _attack_Move) : base(_sceneManager, pSCENE_STATE.Wait_After_Attack)
    {
        dave_Object = _gameObject;
        animator = _animator;

        attack_Move = _attack_Move;
 
        attack_Ready_State_Helper = new Attack_ready_State_Helper(_dave_Child_dictory);
    }

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (audio_Check == false)
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.harpoon_line_pull_loop, true);
            audio_Check = true;
        }



        if (attack_Ready_State_Helper.Get_dave_Attack_Help_Object()["Harpon_Head"].GetComponent<Harpoon_Head_Move>().GetStopCheck() == true)
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sound_harpoon_QTE_Success_01,false);
            Audio_Manager.GetInstance().Sfx_Stop(Audio_Manager.sfx.harpoon_line_pull_loop);
            audio_Check = false;
            attack_Ready_State_Helper.ChildSetActive_Off();
            attack_Move.Set_Stop(false);
            animator.SetBool("Attack_Ready", false);
            animator.SetBool("Wait_After_Attack", false);
            p_Manager.fsm.SetState(pSCENE_STATE.Idle);
            return;
        }
    }
}
