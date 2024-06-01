using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Mover))]
public class Target : PursuedObject
{
    [SerializeField] private List<Waypoint> _waypoints = new List<Waypoint>();

    private Waypoint _currentWaypoint;

    private Rigidbody _rigidbody;
    private Mover _mover;

    private void OnValidate()
    {
        if (_waypoints.Count == 0)
        {
            Debug.LogError("Waipoint doesn't exist");
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mover = GetComponent<Mover>();

        SetNextWaypoint();
    }

    private void FixedUpdate()
    {
        if (_currentWaypoint.IsReached(transform.position))
        {
            SetNextWaypoint();
        }

        _mover.Move(_rigidbody, _currentWaypoint.GetMoveDirection(transform.position));
    }

    private void SetNextWaypoint()
    {
        Waypoint lastElement = _waypoints.Last();

        if (_waypoints.Contains(_currentWaypoint))
        {
            int currentWaipointIndex = _waypoints.IndexOf(_currentWaypoint);

            if (_currentWaypoint == lastElement)
            {
                _waypoints.Reverse();
                _currentWaypoint = _waypoints.First();
            }
            else
            {
                int nextWaypointIndex = currentWaipointIndex + 1;
                _currentWaypoint = _waypoints[nextWaypointIndex];
            }
        }
        else
        {
            _currentWaypoint = _waypoints.First();
        }
    }
}