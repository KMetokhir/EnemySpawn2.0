using UnityEngine;

public abstract class PursuedObject : MonoBehaviour
{
    [SerializeField] private float _aria = 0.5f;

    public virtual Vector3 GetPosition(Vector3 pursuterPosition)
    {
        Vector3 position = transform.position;
        position.y = pursuterPosition.y;

        return position;
    }

    public Vector3 GetMoveDirection(Vector3 pursuterPosition)
    {
        return GetDirection(pursuterPosition).normalized;
    }

    public float GetDistance(Vector3 pursuterPosition)
    {
        return GetDirection(pursuterPosition).magnitude;
    }

    public bool IsReached(Vector3 pursuterPosition)
    {
        if (GetDistance(pursuterPosition) <= _aria)
        {
            return true;
        }

        return false;
    }

    private Vector3 GetDirection(Vector3 pursuterPosition)
    {
        Vector3 direction = (GetPosition(pursuterPosition) - pursuterPosition);

        return direction;
    }
}