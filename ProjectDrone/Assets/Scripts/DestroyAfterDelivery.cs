using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelivery : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        print("test");
        if (other.gameObject.CompareTag("HealingPlatform"))
        {
            Destroy(gameObject);
        }
    }
}
