using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi_Dave_Run : Sushi_Dave_State
{

    Dave_Flip dave_Flip;

    Animator animator;
    GameObject dave;

    Dash_Gauage dash_Gauage;

    float dash_speed = 6.0f;



    public Sushi_Dave_Run(Sushi_Dave _sceneManager, Animator _animator, GameObject _dave, Dash_Gauage _dash_gauge) : base(_sceneManager, Sushi_SCENE_STATE.RunMove)
    {
        animator = _animator;

        dave = _dave;

        dave_Flip = new Dave_Flip(_dave);

        dash_Gauage = _dash_gauge;

    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
    }
    public override void Update()
    {
        base.Update();

        if (dash_Gauage.GetGuage() <= 0)
        {
            animator.SetBool("Tired_Move", true);
            animator.SetBool("Serve_Tired", true);
            p_Manager.fsm.SetState(Sushi_SCENE_STATE.TiredMove);
            return;
        }




        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            dash_Gauage.gauageDown();

            dave_Flip.LeftFlip();

            dave.transform.Translate(Vector3.left * dash_speed * Time.deltaTime);
            return;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            dash_Gauage.gauageDown();


            dave_Flip.RightFlip();

            dave.transform.Translate(Vector3.right * dash_speed * Time.deltaTime);
           
            return;
        }
        else if (Input.anyKey == false)
        {
            animator.SetBool("Run_Move", false);
            animator.SetBool("Serve_Run",false);

            p_Manager.fsm.SetState(Sushi_SCENE_STATE.Idle);
            return;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Run_Move", false);
            animator.SetBool("Move", true);

            animator.SetBool("Serve_Run", false);
            animator.SetBool("Serve_Move", true);

            p_Manager.fsm.SetState(Sushi_SCENE_STATE.Move);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Run_Move", false);
            animator.SetBool("Move", true);

            animator.SetBool("Serve_Run", false);
            animator.SetBool("Serve_Move", true);

            p_Manager.fsm.SetState(Sushi_SCENE_STATE.Move);
        }

    }

}
