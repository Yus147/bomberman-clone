using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovePattern : MonoBehaviour
{
    public Vector2 force;

    private void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(force,ForceMode2D.Impulse);
    }

}
