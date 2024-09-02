using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dive : PlayerState
{



    private Vector3 StartPos;

    CinemachineVirtualCamera virtualCamera;

    float time = 0;

    public Dive(PlayerManager _sceneManager, GameObject _gameObject, Animator _animator, CinemachineVirtualCamera _virtualCamera) : base(_sceneManager,pSCENE_STATE.Start)
    {
        dave_Object = _gameObject;
        animator = _animator;
        StartPos = dave_Object.transform.position;

        virtualCamera = _virtualCamera;
    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
    }


    public override void Update()
    {
      

        base.Update();

        time += Time.deltaTime;

        Vector3 PrevPos = dave_Object.transform.position;

        float posX = Mathf.Cos(-time * 1.5f + 180 * Mathf.Deg2Rad);
        float posY = Mathf.Sin(-time * 1.5f);
        if (posX <= 0.2f)
        {

            dave_Object.transform.position = new Vector3(posX * 10 + StartPos.x, posY * 10 + StartPos.y);
            Vector2 newPos = dave_Object.transform.position - PrevPos;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            dave_Object.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }

        else if (posX > 0.25f)
        {
            dave_Object.transform.rotation = Quaternion.identity;
            animator.SetTrigger("Idle_Start");
            time = 0;
            virtualCamera.Follow = dave_Object.transform;

            p_Manager.fsm.SetState(pSCENE_STATE.Idle);
        }
    }

}
