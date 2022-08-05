using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithAi : MonoBehaviour
{
    public int _speed;
    public int _direction;
    public AI _ai;

    public int MAX_STEPS = 4;
    public double rest;
    public double _steps;

    public bool _alive = true;

    public void Enemy(int x, int y, int speed)
    {
        _speed = speed;

        rest = (MAX_STEPS - (int)MAX_STEPS) / MAX_STEPS;
        _steps = MAX_STEPS;
    }

    public void Update()
    {
        if (_alive)
        {
            calculateMove();
        }
    }
    public void calculateMove()
    {
        if(_steps <= 0)
        {
            _direction = _ai.calculateDirection();
            _steps = MAX_STEPS;
        }

        //if(_direction == 0)
        //{
        //    if(canMove)
        //}
    }
    //public bool canMove(double x, double y)
    //{
    //    return !
    //}
}
