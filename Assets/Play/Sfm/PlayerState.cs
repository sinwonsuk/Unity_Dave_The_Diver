
using UnityEngine;

public enum pSCENE_STATE
{
    Start,
    Idle,
    Right_Move,
    Left_Move,
    Up_Move,
    Down_Move,
    Left_Side_Up_Move,
    Right_Side_Up_Move,
    Left_Side_Down_Move,
    Right_Side_Down_Move,
    Left_Attack_Ready,
    Right_Attack_Ready,
    Left_Attack,
    Right_Attack,
    Wait_After_Attack,

}

public class PlayerState : FsmState<pSCENE_STATE>
{
    protected PlayerManager p_Manager;

    protected GameObject dave_Object;
    protected Animator animator;
    protected float Speed = 5.0f;


    public PlayerState(PlayerManager _sceneManager, pSCENE_STATE _stateType) : base(_stateType)
    {
        p_Manager = _sceneManager;       
    }

}