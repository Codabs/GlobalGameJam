using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownClickableZone : MonoBehaviour
{
    [SerializeField] private float value = -3;
    [SerializeField] private float value1 = -0.1f;
    [SerializeField] private float baseRessourcesGagne = 5;
    public bool IsSecondTree = false;
    public static MoveDownClickableZone Instance = null;
    [SerializeField] public Transform cameraEndPoint;
    [SerializeField] private Transform camera1;
    [SerializeField] private DuplicateBackground background;
    private bool delay = true;
    private void Awake()
    {
        Instance = this;
        cameraEndPoint = GameObject.Find("TransformPointEnd").transform;
        camera1 = GameObject.Find("Camera").transform;
        background = GameObject.Find("BackgroundRF").GetComponent<DuplicateBackground>();
    }
    public void MoveDown()
    {
        if (delay)
        {
            delay = false;
            camera1.GetComponent<CameraArrowsMovement>().MoveEndPoint(value1);

            GameObject obj = GameObject.Instantiate(this.gameObject, transform.parent);

            obj.transform.position = new(transform.position.x, transform.position.y + value, transform.position.z);

            camera1.GetComponent<CameraArrowsMovement>().MovingTheCameraYToARectTransform(cameraEndPoint);

            background.NewBackground();

            StartCoroutine(enumerator());
        }
    }
    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.01f);
        delay = true;
    }
}
