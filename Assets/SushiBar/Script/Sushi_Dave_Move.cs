using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sushi_Dave_Move : Sushi_Dave_State
{
    Dave_Flip dave_Flip;

    Animator animator;
    GameObject dave;



    Dash_Gauage dash_Gauage;


    float speed = 3.0f;


  
    // Start is called before the first frame update
    public Sushi_Dave_Move(Sushi_Dave _sceneManager, Animator _animator,GameObject _dave, Dash_Gauage _dash_gauge) : base(_sceneManager, Sushi_SCENE_STATE.Move)
    {
        animator = _animator;

        dave = _dave;

        dave_Flip = new Dave_Flip(_dave);

        dash_Gauage = _dash_gauge;


    }




    public override void Update()
    {
        dash_Gauage.GauageUp();

        base.Update();





        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {          
            dave_Flip.LeftFlip();      
            
            animator.SetBool("Run_Move", true);
            animator.SetBool("Serve_Run", true);
            p_Manager.fsm.SetState(Sushi_SCENE_STATE.RunMove);
            return;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {          
            dave_Flip.RightFlip();          
            
            animator.SetBool("Run_Move", true);
            animator.SetBool("Serve_Run", true);
            p_Manager.fsm.SetState(Sushi_SCENE_STATE.RunMove);
            return;
        }
        else if (Input.anyKey == false)
        {
            animator.SetBool("Move", false);
            animator.SetBool("Serve_Move", false);
            p_Manager.fsm.SetState(Sushi_SCENE_STATE.Idle);
            return;
        }







        else if (Input.GetKey(KeyCode.A))
        {
            dave_Flip.LeftFlip();
            
            animator.SetBool("Move", true);
            dave.transform.Translate(Vector3.left * speed * Time.deltaTime);
            return;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            dave_Flip.RightFlip();
            
            animator.SetBool("Move", true);
            dave.transform.Translate(Vector3.right * speed * Time.deltaTime);
            return;
        }

        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Move", false);
            p_Manager.fsm.SetState(Sushi_SCENE_STATE.Idle);
            return;
        }

        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Move", false);
            p_Manager.fsm.SetState(Sushi_SCENE_STATE.Idle);
            return;
        }

        




    }

}