using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Swing : MonoBehaviour
{
    private float _motorDelay = 4f;
    private HingeJoint _joint;
    private JointMotor _motor;

    private void Awake()
    {
        _joint = GetComponent<HingeJoint>();
        _motor = _joint.motor;
    }

    public void SetMotorProperty(float velocity)
    {
        _motor.targetVelocity = velocity;

        _joint.motor = _motor;

        UseMotor();

        Invoke(nameof(StopMotor), _motorDelay);
    }

    private void UseMotor()=>_joint.useMotor = true;

    private void StopMotor()=>_joint.useMotor=false;
}
