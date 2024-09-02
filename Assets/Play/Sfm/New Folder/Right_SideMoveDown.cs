using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Right_SideMoveDown : PlayerState
{
    CharacterController controller;

    float speed = 0.0f;

    public Right_SideMoveDown(PlayerManager _sceneManager, GameObject _gameObject, Animator _animator, CharacterController _controller, float _speed) : base(_sceneManager, pSCENE_STATE.Right_Side_Down_Move)
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
        animator.SetBool("Down_Moving", false);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, moveY);

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.S))
        {
            dave_Object.GetComponent<SpriteRenderer>().flipX = false;
            dave_Object.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetTrigger("Side_To_Side_Down");
            p_Manager.fsm.SetState(pSCENE_STATE.Right_Move);
            return;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            dave_Object.transform.rotation = Quaternion.Euler(0, 0, -90);
            animator.SetTrigger("Down_To_Side_Down");
            p_Manager.fsm.SetState(pSCENE_STATE.Down_Move);
            return;
        }

    }
}
