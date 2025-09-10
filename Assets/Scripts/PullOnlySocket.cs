using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PullOnlySocket : XRSocketInteractor
{
    // Unity Lifecycle
    protected override void Awake()
    {
        base.Awake();

        selectEntered.AddListener(OnItemSlot);
        selectExited.AddListener(OutOfItemSlot);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        selectEntered.RemoveListener(OnItemSlot);
        selectExited.RemoveListener(OutOfItemSlot);
    }

    // Methods: XRSocketInteractor
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        /*      Is this one better?
        **              return hasSelection;
        */

        if (!hasSelection) return false;
        return base.CanSelect(interactable);
    }

    // Methods: User Made
    void OnItemSlot(SelectEnterEventArgs args) => args.interactableObject.transform.localScale = _SmallSized;
    void OutOfItemSlot(SelectExitEventArgs args) => args.interactableObject.transform.localScale = _OriginalSized;

    // Private fields
    Vector3 _SmallSized = new Vector3(0.2f, 0.2f, 0.2f);
    Vector3 _OriginalSized = Vector3.one;

}
