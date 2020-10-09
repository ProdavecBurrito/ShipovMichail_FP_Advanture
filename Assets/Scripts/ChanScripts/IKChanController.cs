﻿using UnityEngine;


[RequireComponent(typeof(Animator))]
public class IKChanController: MonoBehaviour
{
    #region Fields

    protected Animator _animator;

    public bool IkActive = false;
    public Transform RightHandObj = null;
    public Transform LeftHandObj = null;
    public Transform LookObj = null;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        if (IkActive)
        {
            if (LookObj != null)
            {
                _animator.SetLookAtWeight(1);
                _animator.SetLookAtPosition(LookObj.position);
            }

            if (RightHandObj != null)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                _animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandObj.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, RightHandObj.rotation);
            }

            if (LeftHandObj != null)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                _animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandObj.position);
                _animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandObj.rotation);
            }
        }

        else
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            _animator.SetLookAtWeight(0);
        }
    }

    #endregion
}

