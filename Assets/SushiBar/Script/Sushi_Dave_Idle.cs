using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi_Dave_Idle : Sushi_Dave_State
{
    Dave_Flip dave_Flip;

    GameObject dave;

    Animator animator;

    Dash_Gauage dash_Gauage;






    // ÀÌÇØ¾ÈµÊ 
    public Sushi_Dave_Idle(Sushi_Dave _sceneManager, Animator _animator, GameObject _dave, Dash_Gauage _dash_Gauage) : base(_sceneManager, Sushi_SCENE_STATE.Idle)
    {
        animator = _animator;
        dave = _dave;
        dave_Flip = new Dave_Flip(_dave);
        dash_Gauage = _dash_Gauage;

    }

  



    public override void Update()
    {
        
        base.Update();

        dash_Gauage.GauageUp();

        animator.SetBool("Move", false);
        animator.SetBool("Run_Move", false);
        animator.SetBool("Serve_Move", false);
        animator.SetBool("Serve_Run", false);


        if (Input.GetKey(KeyCode.A))
        {

            dave_Flip.LeftFlip();

           
                animator.SetBool("Move", true);
            
           
                animator.SetBool("Serve_Move", true);
            

            p_Manager.fsm.SetState(Sushi_SCENE_STATE.Move);
            return;
        }
      
        if (Input.GetKey(KeyCode.D))
        {
            dave_Flip.RightFlip();
         

           
                animator.SetBool("Move", true);
            
           
                animator.SetBool("Serve_Move", true);
            

            p_Manager.fsm.SetState(Sushi_SCENE_STATE.Move);
            return;
        }

    }
}