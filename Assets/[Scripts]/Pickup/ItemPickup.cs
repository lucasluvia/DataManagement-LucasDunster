using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item itemType;

    InventoryManager inventoryManager;
    Renderer renderer;
    Collider collider;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 60 * Time.deltaTime, 0), Space.World);
    }

    public void RemovePickupFromWorld()
    {
        InventorySlot openSlot = inventoryManager.TempPlayerInventory.GetNextOpenSlot();
        openSlot.itemInSlot = itemType;

        renderer.enabled = false;
        collider.enabled = false;
        itemType.CollectItem();
    }

}
