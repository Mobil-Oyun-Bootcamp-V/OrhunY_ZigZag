using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    public float _speed;
    private Vector3 _direction;
    public enum BallState{Wait, Moving, Falling}
    public static BallState _state;
    

    private void FixedUpdate()
    {
        switch (_state)
        {
            case BallState.Moving:
                MoveBall();
                if(transform.position.y < .24f){_state = BallState.Falling;}
                    break;
            
            case BallState.Falling:

                break;
            
            case BallState.Wait:
                if (Input.touchCount > 0) { _state = BallState.Moving; }
                break;
        }

    }

    void MoveBall()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Ended){ChangeDirection();}
        }

        _rb.velocity = _direction * (Time.fixedDeltaTime * _speed);
    }

    private void ChangeDirection()
    {
        if (_direction == Vector3.forward)
        {
            _direction = Vector3.left;
            Debug.Log("left");
        }
        else
        {
            _direction = Vector3.forward;
            Debug.Log("forward");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            //StartCoroutine(other.transform.parent.GetComponent<RoadSpawner>().CallBack(other.transform.gameObject));
        }
    }
}
