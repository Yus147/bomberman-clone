using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AILow : AI
{
    public override int calculateDirection()
    {
        return random.Next(4);
    }
}
