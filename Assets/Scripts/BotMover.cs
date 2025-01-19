using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BotMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _sqrOffset;
    [SerializeField] private float _groundedOffset = 1;

    private Rigidbody _rigidbody;
    private RaycastHit _hit;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CheckGround();
        Move();
    }

    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _groundedOffset))
        {
            _hit = hit;
        }
    }

    private void Move()
    {
        Vector3 distance = GetDistance();

        if (distance.sqrMagnitude > _sqrOffset)
        {
            Vector3 direction = Vector3.ProjectOnPlane(distance, _hit.normal).normalized * _moveSpeed;
            _rigidbody.velocity = new Vector3(direction.x*_moveSpeed,_rigidbody.velocity.y,direction.z*_moveSpeed);
        }
        else
        {
            _rigidbody.velocity = new Vector3(0,_rigidbody.velocity.y,0);
        }
    }

    private Vector3 GetDistance() => _target.position - _rigidbody.position;
}
