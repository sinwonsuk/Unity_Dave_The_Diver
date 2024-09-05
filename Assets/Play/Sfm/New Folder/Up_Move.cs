using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Up_Move : PlayerState
{
    CharacterController controller;

    float speed = 0.0f;

    public Up_Move(PlayerManager _sceneManager, GameObject _gameObject, Animator _animator, CharacterController _controller, float _speed) : base(_sceneManager, pSCENE_STATE.Up_Move)
    {
        dave_Object = _gameObject;
        animator = _animator;
        controller = _controller;
        speed = _speed;
    }






    public override void Update()
    {
        base.Update();

        animator.SetBool("Up_Moving", true);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, moveY);

        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            dave_Object.GetComponent<SpriteRenderer>().flipX = true;

            dave_Object.transform.rotation = Quaternion.Euler(0, 0, -45);
            animator.SetTrigger("Up_To_Side_Up");
            p_Manager.fsm.SetState(pSCENE_STATE.Left_Side_Up_Move);
            return;
        }


        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            dave_Object.GetComponent<SpriteRenderer>().flipX = false;

            dave_Object.transform.rotation = Quaternion.Euler(0, 0, 45);
            animator.SetTrigger("Up_To_Side_Up");
            p_Manager.fsm.SetState(pSCENE_STATE.Right_Side_Up_Move);    
            return;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            dave_Object.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Up_Moving", false);
            p_Manager.fsm.SetState(pSCENE_STATE.Idle);
            return;
        }

        if (!Input.anyKey)
        {
            dave_Object.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Up_Moving", false);
            p_Manager.fsm.SetState(pSCENE_STATE.Idle);
            return;
        }
    }
}
