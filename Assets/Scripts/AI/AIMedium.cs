using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AIMedium : AI
{
    public Transform _player;
    public Transform _enemy;

    private int CHASE_THRESHOLD = 5;

    public AIMedium(Transform player, Transform enemy)
    {
        _player = player;
        _enemy = enemy;
    }

    public override int calculateDirection()
    {
        float X_distance = _player.position.x - _enemy.position.x;
        float Y_distance = _player.position.y - _enemy.position.y;
        bool _chasing = Math.Abs(X_distance) <= CHASE_THRESHOLD && Math.Abs(Y_distance) <= CHASE_THRESHOLD;
        
        if(_chasing)
        {
            int moveHorizontal = random.Next(2);
            if (moveHorizontal == 1)
            {
                if (X_distance < 0)
                    return 2;
                else return 1;
            }
            else
            {
                if (Y_distance < 0)
                    return 3;
                else return 0;
            }
        }
        else
        {
            return random.Next(4);
        }
    }
}
