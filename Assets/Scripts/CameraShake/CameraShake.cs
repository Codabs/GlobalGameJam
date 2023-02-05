using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public IEnumerator Shake (float Duration, float Magnitude)
    {
        Vector3 OriginalPosition = this.gameObject.transform.position;

        float time = 0.0f;

        while (time< Duration)
        {
            float x = Random.Range(-1f, 1f) * Magnitude;
            float y = Random.Range(-1f, 1f) * Magnitude;

            this.gameObject.transform.position = new Vector3(x,y,OriginalPosition.z);

            time += Time.deltaTime;

            yield return null;
        }

        this.gameObject.transform.position = OriginalPosition;
    }
}
