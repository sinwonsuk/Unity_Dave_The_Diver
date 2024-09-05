using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi_Dave_Tired_Move : Sushi_Dave_State
{

    Dave_Flip dave_Flip;

    Animator animator;
    GameObject dave;

   
    float speed = 1.0f;

    float time = 0.0f;



    public Sushi_Dave_Tired_Move(Sushi_Dave _sceneManager, Animator _animator, GameObject _dave ) : base(_sceneManager, Sushi_SCENE_STATE.TiredMove)
    {
        animator = _animator;

        dave = _dave;

        dave_Flip = new Dave_Flip(_dave);


    }



    public override void Update()
    {
        base.Update();

        time += Time.deltaTime;

        if(Input.GetKey(KeyCode.A))
        {
            dave_Flip.LeftFlip();
            dave.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            dave_Flip.RightFlip();
            dave.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if(time > 3)
        {
            time = 0;
            animator.SetBool("Tired_Move", false);
            animator.SetBool("Serve_Tired", false);
            p_Manager.fsm.SetState(Sushi_SCENE_STATE.Idle);
            return;
        }



    }
}

