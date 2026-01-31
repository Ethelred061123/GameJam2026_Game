using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //playerµÄ×´Ì¬
    public bool isInvisible = false;

    public void Invisibility(float time)
    {
        StartCoroutine(InvisibilityRoutine(time));
    }

    IEnumerator InvisibilityRoutine(float time)
    {
        isInvisible = true;
        yield return new WaitForSeconds(time);
        isInvisible = false;
    }
}
