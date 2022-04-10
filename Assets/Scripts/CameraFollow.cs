using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public GameObject Wall, paintBrush;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private bool movementFinished = false;
    private bool cameraToWall = false;

    void Update()
    {
        if(movementFinished && !cameraToWall)
            StartCoroutine(MoveCameraToWall(5f, new Vector3(0f, 90f, 0f), new Vector3(22f, 0.5f, 0f)));
    }

    void LateUpdate()
    {
        if (!movementFinished)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
        }

        if (target.position.x == 21f)
            movementFinished = true;
    }

    IEnumerator MoveCameraToWall(float seconds, Vector3 targetRot, Vector3 targetPos)
    {
        cameraToWall = true;
        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, targetRot, (elapsedTime / seconds));
            transform.position = Vector3.Lerp(transform.position, targetPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        this.transform.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        //this.transform.GetComponent<Camera>().orthographic = true;
        Destroy(Wall.gameObject);
        paintBrush.gameObject.SetActive(true);
    }
}