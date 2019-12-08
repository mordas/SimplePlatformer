using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 15.0f;
    private bool _canDoubleJump = false;
    private int _score = 0;

    [SerializeField] private GameObject _uiManager;
    private float _yVelocity;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
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
}