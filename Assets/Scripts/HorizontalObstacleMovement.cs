using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleMovement : MonoBehaviour
{
    private bool moveRight;
    private float movementAmount = 0f;
    public float speedObs = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.z > 0)
            moveRight = true;
        else
            moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speedObs * Time.deltaTime);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speedObs * Time.deltaTime);

        movementAmount += speedObs * Time.deltaTime;

        if (movementAmount > 1.5f)
        {
            if (moveRight)
                transform.position = new Vector3(transform.position.x, transform.position.y, -0.75f);
            else
                transform.position = new Vector3(transform.position.x, transform.position.y, 0.75f);

            moveRight = !moveRight;
            movementAmount = 0f;
        }
    }
}
