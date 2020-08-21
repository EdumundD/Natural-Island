using System.Collections.Generic;
using UnityEngine;

public enum BaseObjectKind{
    None,
}

public class BaseObject : MonoBehaviour
{
    protected BaseObjectKind m_type = BaseObjectKind.None;
    protected object m_unit = null;
    private Transform m_tr = null;
    private StateMachine m_stateMachine;

    public StateMachine StateMachine
    {
        get { return m_stateMachine; }
        set { m_stateMachine = value; }
    }
}
