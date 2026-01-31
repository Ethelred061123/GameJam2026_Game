using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour
{
    //π÷ŒÔŒÂ√Î≤ª◊∑
    public float disableTime = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ghost_move[] monsters = FindObjectsOfType<ghost_move>();

            foreach (ghost_move m in monsters)
            {
                m.DisableChase(disableTime);
            }

            Destroy(gameObject);
        }
    }
}
