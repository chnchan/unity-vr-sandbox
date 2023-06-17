/* 
    Purpose:
            Puts target object back into specified socket when de-selected from a grab interaction.
    How to use: 
            1. Put script on target object or manually set Target* reference.
            2. Set the Socket reference in inspector / via script.
*/

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class AlwaysSocketedItem : MonoBehaviour
{
    /// <summary>
    /// Specifies the socket interactor this interactable should socket back into when it is unselected.
    /// Set to <see langword-"null"/› to disable this behavior.
    /// </summary>
    public XRSocketInteractor Socket = null;
    public Transform Target = null;

    public bool Animated = false;
    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(Animated))]
    public float AnimationDuration = 1f;
    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(Animated))]
    [Tooltip("If unset, 'Socket will be the target location of the lerp.")]
    public Transform Anchor = null;
    
    private IXRSelectInteractable _interactable = null;
    private MoveTo _moveScript = null;


    /// <summary>
    ///
    /// </summary>
    public void Activate()
    {
        if (!Socket) return;

        if (!Animated)
        {
            Socket.StartManualInteraction(_interactable);
        }
        else
        {
            _moveScript.AnimationDuration = AnimationDuration;

            if (Anchor)
            {
                _moveScript.Activate(Anchor.transform);
            }
            else 
            {
                _moveScript.Activate(Socket.transform);
            }
        }
    }


    /// <summary>
    /// Sets defaults if not set.
    /// </summary>
    private void Awake()
    {
        if (!Target)    Target = this.transform;
        if (Animated)   gameObject.AddComponent<MoveTo>();
    }
    

    /// <summary>
    /// Adds UnityEvent to trigger the socket snapping upon de-selecting the target object.
    /// </summary>
    private void Start()
    {
        _interactable = GetComponent<XRBaseInteractable>();
        if (Animated) _moveScript = GetComponent<MoveTo>();

        _interactable.lastSelectExited.AddListener((selectExitEventArgs) => 
        {
            Activate();
        });
    }
}