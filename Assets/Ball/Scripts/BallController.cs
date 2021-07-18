using System;
using UnityEngine;

//This script contains functions that makes Ball move accordingly.
public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameManager _gameManager;
    public float _speed;
    public RoadSpawner _rs;
    private Vector3 _direction;

    
    //Initializes new random road objects every time player crosses one and increases the score count by one.
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            _gameManager.AddScore();
            _rs.Initialize(10);
        }
    }

    //This function gives a constant velocity on FixedUpdate and calls Change direction function on every single tap.
    public void MoveBall()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended) ChangeDirection();
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
}