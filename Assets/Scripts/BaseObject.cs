using System.Collections.Generic;
using UnityEngine;
public enum BaseState{
    Rest,
    Eating,
    Moving,
    Hunting,
    BeingHunting,
    Growing
}
public class BaseObject: MonoBehaviour
{
    private BaseState nowState;
    private BaseState PreviousState;
}
