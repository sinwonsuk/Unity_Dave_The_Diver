using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Sushi_SCENE_STATE
{
   
    Idle,
    Move,
    RunMove,
    TiredMove,
    Right_Move,
    Left_Move,
   
}

public class Sushi_Dave_State : FsmState<Sushi_SCENE_STATE>
{
    protected Sushi_Dave p_Manager;





    public Sushi_Dave_State(Sushi_Dave _sceneManager, Sushi_SCENE_STATE _stateType) : base(_stateType)
    {
        p_Manager = _sceneManager;
    }


}
