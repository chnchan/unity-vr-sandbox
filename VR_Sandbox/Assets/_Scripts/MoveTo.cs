/*
    Purpose:
            Moves / rotates target object to destination over time.
    How to use: 
            1. Put script on target object or manually set 'Target reference.
            2. Call Activate(Transform destination)
*/

using System.Collections;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform Target = null;
    public float AnimationDuration = 2.0f;

    private Coroutine coroutine = null;


    /// <summary>
    /// Triggers coroutine to perform the lerp animation.
    /// </summary>
    /// <param name-"destination"></param>
    public void Activate(Transform destination)
    {
        StopExistingCoroutine();
        coroutine = StartCoroutine(MoveToTargetCoroutine(destination, AnimationDuration));
    }
    

    /// <summary>
    /// Sets defaults if not set.
    /// </summary>
    private void Start()
    {
        if (!Target) Target = this.transform;
    }


    /// <summary>
    /// Cancels any on-going coroutine.
    /// </summary>
    private void StopExistingCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
    
    /// <summary>
    /// Moves target object to destination
    /// </summary>
    /// <param name- "destination"›</param>
    /// Sparam name-"duration"›</param>
    /// <returns></returns>
    private IEnumerator MoveToTargetCoroutine (Transform destination, float duration)
    {
        float timer = 0.0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            Target.transform.position = Vector3.Lerp(Target.position, destination.position, t);
            Target.transform.rotation = Quaternion.Lerp(Target.rotation, destination.rotation, t);
            
            yield return null;
        }

        yield return null;
    }
}
