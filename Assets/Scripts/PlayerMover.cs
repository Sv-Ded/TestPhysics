using UnityEngine;

[RequireComponent (typeof(CharacterController),typeof(InputReader))]
public class PlayerMover:MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private CharacterController _controller;
    private InputReader _inputReader;

    private void Awake()
    {
        _controller = GetComponent<CharacterController> ();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_inputReader.HorizontalShift, 0, _inputReader.VerticalShift);

        _controller.SimpleMove(direction* _moveSpeed);
    }
}
