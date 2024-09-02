using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Right_Move : PlayerState
{

    Attack_ready_State_Helper attack_Ready_State_Helper;

    CharacterController controller;

    float speed = 0.0f;

    public Right_Move(PlayerManager _sceneManager, GameObject _gameObject, Animator _animator, Dictionary<string, GameObject> _dave_Child_dictory, CharacterController _controller, float _speed) : base(_sceneManager, pSCENE_STATE.Right_Move)
    {
        dave_Object = _gameObject;
        animator = _animator;

        attack_Ready_State_Helper = new Attack_ready_State_Helper(_dave_Child_dictory);

        controller = _controller;

        speed = _speed;
    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
    }

    


    public override void Update()
    {
        base.Update();

        animator.SetBool("Side_Moving", true);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, moveY);

        controller.Move(move * speed * Time.deltaTime);



        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            dave_Object.transform.rotation = Quaternion.Euler(0, 0, 45);
            animator.SetTrigger("Side_To_Side_Up");
            p_Manager.fsm.SetState(pSCENE_STATE.Right_Side_Up_Move);    
            return;
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {

            dave_Object.transform.rotation = Quaternion.Euler(0, 0, -45);
            animator.SetTrigger("Side_To_Side_Down");
            p_Manager.fsm.SetState(pSCENE_STATE.Right_Side_Down_Move);       
            return;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            dave_Object.GetComponent<SpriteRenderer>().flipX = false;

            animator.SetBool("Side_Moving", false);
            p_Manager.fsm.SetState(pSCENE_STATE.Idle);
            return;
        }
        if (Input.GetMouseButton(1))
        {
            attack_Ready_State_Helper.Get_dave_Attack_Help_Object()["Attack_Ready_Parent"].transform.rotation = Quaternion.Euler(0, 0, 0);

            attack_Ready_State_Helper.Get_dave_Attack_Help_Object()["Target_Curve_Parent"].transform.rotation = Quaternion.Euler(0, 0, 0);

            dave_Object.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Side_Moving", false);
            animator.SetBool("Attack_Ready", true);
            attack_Ready_State_Helper.ChildSetActive_Attack_Ready(true);
            p_Manager.fsm.SetState(pSCENE_STATE.Right_Attack_Ready);
            return;
        }

        if (!Input.anyKey)
        {
            dave_Object.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Side_Moving", false);
            p_Manager.fsm.SetState(pSCENE_STATE.Idle);
            return;
        }
    }

}
