using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FMOD;
public class CameraArrowsMovement : MonoBehaviour
{
    bool canIMoveThePointDown = true;
    [SerializeField] private Transform endPoint;
    public void MovingTheCameraYToARectTransform(Transform point)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/FastScrolling");
        transform.DOMove(new(transform.position.x, point.position.y, transform.position.z), 0.3f);
    }
    public void MovingSecondTree()
    {
        transform.DOMove(new(transform.position.x, transform.position.y, transform.position.z), 0.1f);
    }
    public void MoveEndPoint(float value)
    {
        if (canIMoveThePointDown)
        {
            endPoint = GameObject.Find("TransformPointEnd").transform;
            endPoint.localPosition = new(endPoint.localPosition.x, endPoint.localPosition.y + value, endPoint.localPosition.z);
            canIMoveThePointDown = false;
        }
        StartCoroutine(SetTrue());
    }
    IEnumerator SetTrue()
    {
        yield return new WaitForSeconds(0.01f);
        canIMoveThePointDown = true;
    }
}
