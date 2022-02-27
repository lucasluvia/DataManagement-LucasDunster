using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupCategory
{
    DEFAULT,
    WORLD,
    PLAYER
}

public enum PickupEffect
{
    NONE,
    SPEED,
    HIGH_JUMP,
    STORAGE,
    PICKUP_RADUIS,
    LOW_GRAVITY
}

[CreateAssetMenu(fileName = "MyPickUp", menuName = "ItemSystem/Pickup")]
public class Item : ScriptableObject
{
    public string itemName = "item";
    public string itemDesc = "desc";
    public PickupCategory pickupType;
    public PickupEffect pickupEffect;

    public void CollectItem()
    {
        Debug.Log("Collected the " + itemName + " PickUp: " + itemDesc + ".");

    }

}
