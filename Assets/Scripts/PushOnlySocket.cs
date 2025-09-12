using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
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

    // private void OnObjectPlacedAsync(SelectEnterEventArgs args)
    // {
    //     OnObjectPlacedAsync(args).Forget();
    // }

    // Methods
    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        // Check item if is puttable
        Transform itemToPutIn = args.interactableObject.transform;
        if (itemToPutIn.TryGetComponent<Item>(out var i))
        {
            // switch (i)
            // {
            //     case EquipmentItem ei:
            //         ItemInstance eii = ei.ToItemInstance();
            //         InventoryManager.InventoryInstance.PutInInventory(eii);
            //         Debug.LogWarning(eii.ThisPrefab);
            //         Destroy(itemToPutIn.gameObject);
            //         break;
            //     case PropsItem pi:
            //         ItemInstance pii = pi.ToItemInstance();
            //         InventoryManager.InventoryInstance.PutInInventory(pii);
            //         Destroy(itemToPutIn.gameObject);
            //         break;
            // }

            // If yes, put it and destory the world object.
            ItemInstance instancedItem = i.ToItemInstance();
            InventoryManager.InventoryInstance.PutInInventory(instancedItem);
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
