using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private int _jumpForce = 100;
    [SerializeField] private int _movementSpeed = 5;
    [SerializeField] private int _maxSpeed = 25;

    [SerializeField] private PlayerGroundChecker _playerGroundChecker;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && _playerGroundChecker.Grounded == true)
            {
                _rigidbody2D.AddForce(new Vector2(_rigidbody2D.velocity.x, _jumpForce));
            }
        }
        _rigidbody2D.AddForce(new Vector2(_movementSpeed, _rigidbody2D.velocity.y));
        if (_rigidbody2D.velocity.x > _maxSpeed)
        {
            _rigidbody2D.velocity = new Vector2(_maxSpeed,_rigidbody2D.velocity.y);
        }
    }

}
