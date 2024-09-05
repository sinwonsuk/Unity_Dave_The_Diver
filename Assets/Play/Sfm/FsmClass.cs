using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmClass<T> where T : System.Enum
{
    protected Dictionary<T, FsmState<T>> m_stateList = new Dictionary<T, FsmState<T>>();
    protected FsmState<T> m_state;
    protected bool m_isStateChanging = false;

    public FsmState<T> Getstate { get { return m_state; } }

    public T getStateType
    {
        get
        {
            if (m_state == null)
            {
                return default(T);
            }


            return m_state.stateType;
        }
    }
        public virtual void Init()
        {

        }
    public virtual void Clear()
    {
        m_stateList.Clear();
        m_state = null;
    }
    
    public virtual void AddFsm(FsmState<T> _state)
    {       
        if (null == _state)
        {
            Debug.LogError("FsmClass::AddFsm()[null == FsmState<T>]");
        }

        if(true == m_stateList.ContainsKey(_state.stateType))
        {
            Debug.LogError("FsmClass::AddFsm()[have state : " + _state.stateType);
        }

        m_stateList.Add(_state.stateType, _state);
    }
    
    public virtual void SetState(T _stateType, FsmMsg _msg = null)
    {
        if(m_stateList.ContainsKey(_stateType) ==false)
        {
            Debug.LogError("FsmClass::SetState()[no have state :]" + _stateType);
            return; 
        }

        FsmState<T> nextState = m_stateList[_stateType];

      
        if(m_isStateChanging ==true)
        {
            Debug.LogError("FsmClass::SetState()[m_isStateChanging : ]" + _stateType);
            return;
        }


        m_isStateChanging = true;

    

        m_state = nextState;
       

        m_isStateChanging = false;
    }

    public void SetMsg(FsmMsg _msg)
    {
        if(m_state == null)
        {
            return;
        }

        if(_msg == null)
        {
            return;
        }


    }


    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(null == m_state)
        {
            return;
        }

        m_state.Update();


    }
}
