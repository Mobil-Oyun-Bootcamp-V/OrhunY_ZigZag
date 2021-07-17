using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;


    private void Update()
    {
        if (BallController._state == BallController.BallState.Moving)
        {
            _startScreen.SetActive(false);
        }
        else
        {
            _startScreen.SetActive(true);
        }
    }
}
