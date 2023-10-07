using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attckState;
    public bool isInAttackRange;

    public override State RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attckState;
        }
        else
        {
            return this;
        }
        return this;
    }
}
