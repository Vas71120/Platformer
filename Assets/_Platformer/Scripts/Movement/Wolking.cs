using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [Space]
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 20f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 35f;
    [Space]
    [SerializeField] private Rigidbody body;
    [SerializeField] private Ground ground;

    private Vector2 _direction;
    private Vector2 _desiredVelocity;
    private Vector2 _velocity;

    public void Move(Vector2 direction)
    {
        _direction.x = direction.normalized.x;
        _desiredVelocity = new Vector2(direction.x, 0f) * Mathf(maxSpeed - ground.Friction, 0f);
    }
    private void Update()
    {
        if (inputManager)
        {
            Move(inputManager.Move);
        }
        animator.SetVeliocity(body.veliosity);
        animator.SetIsFalling(ground.OnGround);
    }
    private void FixedUpdate()
    {
        var onGround = ground.OnGround;
        _velocity = body.velocity;
        var acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        var speedChange = acceleration * Time.fixedDeltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, speedChange);
        body.veliocity - _velocity;
    }
}