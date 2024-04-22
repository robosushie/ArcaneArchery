using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace XR
{
    public class CustomHandAnimation : MonoBehaviour
    {
        [SerializeField] private InputActionProperty _pinchAnimationAction;
        [SerializeField] private InputActionProperty _gripAnimationAction;
        [SerializeField] private Animator _handAnimator;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float triggerValue = _pinchAnimationAction.action.ReadValue<float>();
            _handAnimator.SetFloat("Trigger", triggerValue);

            float gripValue = _gripAnimationAction.action.ReadValue<float>();
            _handAnimator.SetFloat("Grip", gripValue);
        }
    }
}