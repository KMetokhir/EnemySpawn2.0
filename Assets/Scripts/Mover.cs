using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxSpeed;

    private void OnValidate()
    {
        _acceleration = Mathf.Abs(_acceleration);
        _maxSpeed = Mathf.Abs(_maxSpeed);
    }

    public void Move(Rigidbody rigidbody, Vector3 direction)
    {
        if (rigidbody.velocity.magnitude <= _maxSpeed)
        {
            rigidbody.AddForce(direction * _acceleration);        
        }
        else
        {
            rigidbody.velocity = rigidbody.velocity.normalized * _maxSpeed;
        }
    }

    public void Move(Rigidbody rigidbody, Vector3 direction, float fixedDeltaTime)
    {
        rigidbody.MovePosition(rigidbody.position+ direction* fixedDeltaTime* _maxSpeed);
    }
}