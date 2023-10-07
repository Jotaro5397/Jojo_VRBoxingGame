using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingState : State
{
    public override State RunCurrentState()
    {
        return this;
    }
}
