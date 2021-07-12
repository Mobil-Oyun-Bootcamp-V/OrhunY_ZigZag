using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    public float _speed;
    private Vector3 _direction;
    private bool isForward;

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            ChangeDirection();
        }

        _rb.velocity = _direction * (Time.fixedDeltaTime * _speed);
    }

    private void ChangeDirection()
    {
        if (isForward)
        {
            _direction = Vector3.forward;
            isForward = true;
        }
        else
        {
            _direction = Vector3.left;
            isForward = false;
        }
    }
}
