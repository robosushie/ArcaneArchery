using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static System.TimeZoneInfo;
using System.Collections;

public class ControllerInputListener : MonoBehaviour
{
    [SerializeField] private ActionBasedController _leftController;
    [SerializeField] private GameObject _bowString;
    [SerializeField] private MeshRenderer _bowMesh;

    public float _transitionTime = 2.0f; // Duration of the fade transition

    private Material _mat;
    private Coroutine _currentCoroutine;

    
    private void OnEnable()
    {
        // Subscribe to Select and Activate actions
        _leftController.selectAction.action.started += OnSelectPressed;
        _leftController.selectAction.action.canceled += OnSelectReleased;

    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        _leftController.selectAction.action.started -= OnSelectPressed;
        _leftController.selectAction.action.canceled -= OnSelectReleased;

    }

    private void OnSelectPressed(InputAction.CallbackContext context)
    {
        StartDissolve(0);
    }

    private void OnSelectReleased(InputAction.CallbackContext context)
    {
        _bowString.SetActive(false);
        StartDissolve(1);
    }

    void Start()
    {
        if (_bowMesh != null)
        {
            _mat = _bowMesh.material; // Cache the material reference
        }
        else
        {
            Debug.LogError("Renderer not assigned.");
        }
        _bowString.SetActive(false);
    }

    void StartDissolve(float target)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(FadeDissolve(target));
    }

    IEnumerator FadeDissolve(float target)
    {
        float time = 0;
        float startOpacity = _mat.GetFloat("_Dissolve");
        while (time < _transitionTime)
        {
            time += Time.deltaTime;
            float newOpacity = Mathf.Lerp(startOpacity, target, time / _transitionTime);
            _mat.SetFloat("_Dissolve", newOpacity);
            yield return null;
        }
        _mat.SetFloat("_Dissolve", target); // Ensure target opacity is set at the end
        if(target == 0)
        {
            _bowString.SetActive(true);
        }
    }

}
