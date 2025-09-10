using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PushOnlySocket : XRSocketInteractor
{
    // Unity Lifecycle
    protected override void Awake()
    {
        base.Awake();

        selectEntered.AddListener(OnObjectPlaced);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        selectEntered.RemoveListener(OnObjectPlaced);
    }

    // Methods
    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        // Check item if is puttable
        Transform itemToPutIn = args.interactableObject.transform;
        if (itemToPutIn.TryGetComponent<ItemInstance>(out var i))
        {
            // If yes, put it and destory the world object.
            InventoryManager.InventoryInstance.PutInInventory(i);
            Destroy(itemToPutIn.gameObject);
            return;
        }

        // If no, drop it.
        if (hasSelection) interactionManager.SelectExit(this, interactablesSelected[0]);

        /* 
        ** Sample codes to prevent pulling.
        ** if (args.interactableObject.transform.TryGetComponent<XRGrabInteractable>(out var grabInteractable))
        ** {
        **     grabInteractable.enabled = false;
        ** }
        */ 
    }
}
