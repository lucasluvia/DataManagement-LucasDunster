using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] float turretLifetime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, turretLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
