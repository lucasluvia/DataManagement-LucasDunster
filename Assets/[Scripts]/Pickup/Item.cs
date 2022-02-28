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
    MORE_SPEED,
    LOW_GRAVITY,
    MAGNETIC_PICKUPS,
    STICKY_PICKUPS
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
