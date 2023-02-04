using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraArrowsMovement : MonoBehaviour
{
    public void MovingTheCameraYToARectTransform(Transform point)
    {
        transform.DOMove(new(transform.position.x, point.position.y, transform.position.z), 0.3f);
    }
    public void MovingSecondTree()
    {
        transform.DOMove(new(transform.position.x, transform.position.y, transform.position.z), 0.1f);
    }
}
