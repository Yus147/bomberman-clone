using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AI : MonoBehaviour
{
    public System.Random random = new System.Random();
    public abstract int calculateDirection();
}
