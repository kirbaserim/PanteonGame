using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingAction : MonoBehaviour
{
    public GameObject paintCircle;
    public GameObject instPaintCircle;

    private GameObject InstantiatedCircle;

    private bool dragging;

    void Update()
    {
        paintCircle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z+10f));
        if(Input.GetMouseButtonDown(0))
        {
            dragging = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    void LateUpdate()
    {
        if (dragging)
        {
            InstantiatedCircle = Instantiate(instPaintCircle, new Vector3(0f, 0f, 0f), paintCircle.transform.rotation);
            InstantiatedCircle.transform.parent = this.transform;
            InstantiatedCircle.transform.position = paintCircle.transform.position;
        }
    }
}
