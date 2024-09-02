using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Left_SideMoveUp : PlayerState
{
    CharacterController controller;

    float speed = 0.0f;


    public Left_SideMoveUp(PlayerManager _sceneManager, GameObject _gameObject, Animator _animator, CharacterController _controller, float _speed) : base(_sceneManager, pSCENE_STATE.Left_Side_Up_Move)
    {
        dave_Object = _gameObject;
        animator = _animator;
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

        animator.SetBool("Side_Moving", false);
        animator.SetBool("Up_Moving", false);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, moveY);

        controller.Move(move * speed * Time.deltaTime);



        if (Input.GetKeyUp(KeyCode.W))
        {
            dave_Object.GetComponent<SpriteRenderer>().flipX = true;
            dave_Object.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetTrigger("Side_To_Side_Up");
            p_Manager.fsm.SetState(pSCENE_STATE.Left_Move);
            return;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            dave_Object.transform.rotation = Quaternion.Euler(0, 0, -90);
            animator.SetTrigger("Up_To_Side_Up");
            p_Manager.fsm.SetState(pSCENE_STATE.Up_Move);
            return;
        }
    }
}
