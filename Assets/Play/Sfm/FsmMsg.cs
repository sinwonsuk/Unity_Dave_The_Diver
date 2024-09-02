using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmMsg 
{
    public int m_msgType;

    public int msgType { get { return m_msgType; } }

    public FsmMsg(int _m_msgType)
    {
        m_msgType  = _m_msgType;
    }


}
