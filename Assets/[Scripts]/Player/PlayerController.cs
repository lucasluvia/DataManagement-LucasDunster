using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isJumping;
    public bool isRunning;
    public bool isPickingUp;

    [Header("ItemVariables")]
    public bool speed;
    public bool grav;
    public bool mag;
    public bool sticky;
}
