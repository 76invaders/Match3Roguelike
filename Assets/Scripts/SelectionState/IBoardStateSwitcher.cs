using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardStateSwitcher
{
    void SwitchState<T>() where T : BaseState;
}