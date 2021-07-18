using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum BallState
    {
        Wait,
        Moving,
        Falling
    }
    
    public static BallState _state;
    
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _player;
    public TextMeshProUGUI _scoreText;
    private int _score;
    
    private BallController _bc;

    private void Awake()
    {
        _bc = _player.GetComponent<BallController>();
    }

    
    //Game States controls the UI and ball movement.
    private void FixedUpdate()
    {
        switch (_state)
        {
            case BallState.Wait:
                if (Input.touchCount > 0)
                {
                    _state = BallState.Moving;
                }
                break;
            case BallState.Moving:
                _startScreen.SetActive(false);
                _bc.MoveBall();
                if (_player.transform.position.y < .22f) _state = BallState.Falling;
                break;
            case BallState.Falling:
                _startScreen.SetActive(true);
                if (Input.touchCount > 0) _state = BallState.Wait;
                break;
        }
    }
    
    public void AddScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

}