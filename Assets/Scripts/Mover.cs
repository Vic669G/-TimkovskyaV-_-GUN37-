using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private Vector3 _start = Vector3.zero;
    [SerializeField] private Vector3 _end = Vector3.forward * 5f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _delay = 1f;

    private Rigidbody _rigidbody;
    private Vector3 _currentTarget;

    private IEnumerator Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody not found on this object!", this);
            yield break;
        }

        _rigidbody.isKinematic = true;

        _rigidbody.position = _start;
        _currentTarget = _end;

        while (true)
        {
            yield return StartCoroutine(MoveToTarget(_currentTarget));

            yield return new WaitForSeconds(_delay);

            _currentTarget = (_currentTarget == _end) ? _start : _end;
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        while (Vector3.Distance(_rigidbody.position, target) > 0.01f)
        {
            Vector3 direction = (target - _rigidbody.position).normalized;
            float distanceThisFrame = _speed * Time.fixedDeltaTime;

            Vector3 newPosition = Vector3.MoveTowards(_rigidbody.position, target, distanceThisFrame);

            _rigidbody.MovePosition(newPosition);

            yield return new WaitForFixedUpdate();
        }

        _rigidbody.MovePosition(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_start, 0.3f);
        Gizmos.DrawIcon(_start, "start", true);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_end, 0.3f);
        Gizmos.DrawIcon(_end, "end", true);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_start, _end);
    }

    public void SetPoints(Vector3 newStart, Vector3 newEnd)
    {
        _start = newStart;
        _end = newEnd;
    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    public void SetDelay(float newDelay)
    {
        _delay = newDelay;
    }
}
