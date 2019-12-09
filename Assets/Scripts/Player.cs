using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 15.0f;
    private bool _canDoubleJump = false;
    private int _score = 0;
    private int _lives = 3;

    [SerializeField] private GameObject _uiManager;
    private float _yVelocity;
    [SerializeField] private GameObject _restartPosition;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        CountLifes(0);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        if (!_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump)
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }

            _yVelocity -= _gravity;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                if (transform.parent != null)
                {
                    transform.parent = null;
                }

                _canDoubleJump = true;
            }
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }


    public void CountScore(int score)
    {
        _score += score;
        _uiManager.gameObject.GetComponent<UIManager>().UpdateCoins(_score);
    }

    public void CountLifes(int li)
    {
        _lives += li;
        _uiManager.gameObject.GetComponent<UIManager>().updateLives(_lives);
        if (_lives < 1)
        {
            SceneManager.LoadScene('0');
        }
    }

    public void Respawn()
    {
        Debug.Log("Respawn");
            
        transform.position = _restartPosition.transform.position;
    }

}