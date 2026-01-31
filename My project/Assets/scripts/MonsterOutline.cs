using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterOutline : MonoBehaviour
{
    //π÷ŒÔ∏ﬂ¡¡œ‘ æ
    public GameObject outline;

    public void ShowOutline(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(Show(duration));
    }

    IEnumerator Show(float duration)
    {
        outline.SetActive(true);
        yield return new WaitForSeconds(duration);
        outline.SetActive(false);
    }
}
