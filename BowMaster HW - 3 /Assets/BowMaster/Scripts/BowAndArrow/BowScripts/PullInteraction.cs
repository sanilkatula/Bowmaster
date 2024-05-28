using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class PullInteraction : MonoBehaviour
{
    public Transform pullTransform;
    public float maxDistance = 0.5f;

    public InputActionReference triggerActionL;
    public InputActionReference triggerActionR;

    public UnityEvent enteredGrabTrigger;
    public UnityEvent exitedGrabTrigger;
    public UnityEvent startedGrabEvent;
    public UnityEvent<float> endedGrabEvent;
    public UnityEvent<float> pullEvent;

    public AudioSource audioToPause; // Audio 2
    public AudioSource audioToPlay;  // Audio 3

    private Vector3 _initGrabPos;
    private bool _canGrab;
    private bool _isGrabbing;
    
    private XRBaseInteractor interactor;
    private Transform grabberTransform;

    void Start()
    {
        _initGrabPos = pullTransform.localPosition;
        _canGrab = false;
        _isGrabbing = false;

        triggerActionL.action.started += StartGrab;
        triggerActionL.action.canceled += EndGrab;
        triggerActionR.action.started += StartGrab;
        triggerActionR.action.canceled += EndGrab;
    }

    void OnDestroy()
    {
        triggerActionL.action.started -= StartGrab;
        triggerActionL.action.canceled -= EndGrab;
        triggerActionR.action.started -= StartGrab;
        triggerActionR.action.canceled -= EndGrab;
    }

    void Update()
    {
        if (_isGrabbing && grabberTransform)
        {
            pullTransform.position = grabberTransform.position;
            pullEvent?.Invoke(CalculatePullAmount());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactor = other.GetComponent<XRBaseInteractor>();
            if (interactor)
            {
                grabberTransform = interactor.attachTransform;   
            }

            enteredGrabTrigger?.Invoke();
            _canGrab = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canGrab = false;
            exitedGrabTrigger?.Invoke();
        }
    }

    void StartGrab(InputAction.CallbackContext ctx)
    {
        if(_isGrabbing || !_canGrab)
            return;

        _isGrabbing = true;
        startedGrabEvent?.Invoke();

        // Audio Logic: Pause Audio 2 and Play Audio 3
        if (audioToPause != null && audioToPause.isPlaying)
        {
            audioToPause.Pause();
            Debug.Log("Audio 2 paused because string was grabbed with trigger button.");
        }

        if (audioToPlay != null)
        {
            audioToPlay.Play();
            Debug.Log("Audio 3 started playing because string was grabbed with trigger button.");
        }
    }

    void EndGrab(InputAction.CallbackContext ctx)
    {
        if (!_isGrabbing)
            return;

        _isGrabbing = false;
        endedGrabEvent?.Invoke(CalculatePullAmount());

        // Audio Logic: Stop Audio 3
        if (audioToPlay != null && audioToPlay.isPlaying)
        {
            audioToPlay.Stop();
            Debug.Log("Audio 3 stopped because trigger button was released.");
        }

        pullTransform.localPosition = _initGrabPos;
        grabberTransform = null;
    }

    float CalculatePullAmount()
    {
        float pullAmount = Vector3.Distance(_initGrabPos, pullTransform.localPosition) / maxDistance;
        pullAmount = Mathf.Clamp(pullAmount, 0.0f, 1.0f);
        return pullAmount;
    }
}
