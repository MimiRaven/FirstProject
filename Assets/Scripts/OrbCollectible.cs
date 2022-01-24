using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollectible : MonoBehaviour
{
    public AudioClip soulPickup;

    void OnTriggerEnter2D(Collider2D other)
    {
        GhoulController controller = other.GetComponent<GhoulController>();

        if (controller != null)
        {
            if (controller.score < controller.maxScore)
            {
                controller.ChangeScore(1);
                Destroy(gameObject);

                controller.PlaySound(soulPickup);
            }
        }
    }
}
