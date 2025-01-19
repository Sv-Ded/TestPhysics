using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{
    [SerializeField] private Rigidbody _projectile;
    [SerializeField] private HingeJoint _joint;
    [SerializeField] private SpringJoint _spring;
    [SerializeField] private Transform _projectilePosition;

    private float _shotDelay = 4f;
    private float _springForce = 100f;

    public void Shot()
    {
        _spring.spring = 0;

        _joint.useMotor = true;

    }

    public void Recharge()
    {
        _joint.useMotor = false;

        _spring.spring = _springForce;

        Invoke(nameof(CreateProjectile),_shotDelay);
    }

    private void StopMotor()=> _joint.useMotor = false;

    private void CreateProjectile()=>Instantiate(_projectile,_projectilePosition.position,Quaternion.identity);
}
