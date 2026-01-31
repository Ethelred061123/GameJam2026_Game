using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityItem : MonoBehaviour
{
    public float invisibleTime = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NewBehaviourScript invis =
                other.GetComponent<NewBehaviourScript>();

            if (invis != null)
            {
                invis.Invisibility(invisibleTime);
            }

            Destroy(gameObject);
        }
    }
}
