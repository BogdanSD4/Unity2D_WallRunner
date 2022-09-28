using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Rigidbody2D _rigi;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    public int _turn = 1;
    private bool _move;
    private bool _ground;
    private bool _wall;
    private bool _jump;

    private void Update()
    {
        if (_move)
        {
            transform.Translate(_speed * _turn * Time.deltaTime,0,0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _jump)
        {
            if (_wall && !_move && !_ground)
            {
                _move = true;
                if (_turn > 0) _turn = -1;
                else _turn = 1;
            }

            _rigi.velocity = Vector2.zero;
            _rigi.AddForce(transform.up * _jumpSpeed , ForceMode2D.Impulse);

            _jump = false;
        }
        if (_wall && _rigi.velocity.y < 0)
        {
            if (_rigi.gravityScale != .4f) _rigi.gravityScale = .4f;
        }
        else
        {
            if (_rigi.gravityScale != 2) _rigi.gravityScale = 2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.Layer_Wall)
        {
            print("Wall");
            _move = false;
            
            if(!_wall)_rigi.velocity = Vector2.zero;
            _jump = true;
            _wall = true;
        }

        if (collision.gameObject.layer == Constants.Layer_Ground)
        {
            print("ground");
            if (!_wall) _move = true;
            else _move = false;
            _jump = true;
            _ground = true;
        }

        if (collision.gameObject.layer == Constants.Layer_Down)
        {

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.Layer_Wall)
        {
            _wall = false;
            if (!_ground) _move = true;
        }

        if (collision.gameObject.layer == Constants.Layer_Ground)
        {
            _ground = false;
            _jump = true;
        }

        if (collision.gameObject.layer == Constants.Layer_Down)
        {

        }
    }
}
