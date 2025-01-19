using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Swing _swing;
    [SerializeField] private Spoon _spoon;

    private float _velocityForStart = 100f;
    private float _velocityForFinish = 0f;
    private KeyCode _startSwingButton = KeyCode.A;
    private KeyCode _attackProjectile = KeyCode.Space;
    private KeyCode _rechargeSpoon = KeyCode.R;
    private bool _isSwing = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (_isSwing == false)
            {
                _swing.SetMotorProperty(_velocityForStart);
                _isSwing = true;
            }
            else
            {
                _swing.SetMotorProperty(_velocityForFinish);
                _isSwing = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _spoon.Shot();
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            _spoon.Recharge();
        }
    }
}
