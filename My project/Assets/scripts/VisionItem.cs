using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionItem : MonoBehaviour
{
    //怪物描边，还需要测试
    public float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MonsterOutline[] monsters = FindObjectsOfType<MonsterOutline>();
            foreach (var m in monsters)
            {
                m.ShowOutline(duration);
            }

            Destroy(gameObject);
        }
    }
}
