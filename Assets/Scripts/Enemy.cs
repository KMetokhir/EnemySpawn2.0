using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Mover))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Mover _mover;
    private PursuedObject _pursuedObject;

    private bool _isInited = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        if (_isInited == false)
        {
            return;
        }

        _mover.Move(_rigidbody, _pursuedObject.GetMoveDirection(transform.position));
    }

    public void Init(PursuedObject pursuedObject)
    {
        if (_isInited)
        {
            return;
        }

        _isInited = true;

        _pursuedObject = pursuedObject;
    }
}
