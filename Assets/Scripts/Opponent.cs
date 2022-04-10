using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    private float radiusToCheck = 0.1f;
    private Vector3 checkVectorM, checkVectorR, checkVectorL;
    private bool waitFinished = true;

    private float speedChar;
    private Vector3 startingPos;
    private bool movementTrue = true;
    private int directionInt;
    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        speedChar = Random.Range(0.95f, 1.05f);
        directionInt = 0;
        startingPos = new Vector3(transform.position.x,transform.position.y, Random.Range(-0.4f, 0.4f));
        moveVector = new Vector3(1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        checkVectorR = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z - 0.3f);
        checkVectorL = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z + 0.3f);

        if (waitFinished)
        {
            StartCoroutine(WaitFor(0.2f));
            if (Physics.CheckSphere(checkVectorR, radiusToCheck))
            {
                directionInt = -1;
                moveVector = new Vector3(1f, 0f, Random.Range(0.75f, 1f));
            }
            else if (Physics.CheckSphere(checkVectorL, radiusToCheck))
            {
                directionInt = 1;
                moveVector = new Vector3(1f, 0f, Random.Range(-1f, -0.75f));
            }
            else
            {
                directionInt = 0;
            }
        }
        MoveTo(directionInt);
    }

    private void MoveTo(int movementPos)
    {
        if (movementTrue)
        {
            if (movementPos != 0)
                transform.position = Vector3.Lerp(transform.position, transform.position + moveVector, speedChar * Time.deltaTime);
            else
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 0.5f, 0f, startingPos.z), 2*speedChar * Time.deltaTime);

            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -0.5f, 0.5f));
        }

        if (transform.position.x > 21f)
        {
            transform.position = new Vector3(21f, transform.position.y, transform.position.z);
            this.transform.GetComponent<Animator>().SetTrigger("Finished");
            movementTrue = false;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        //Check to see if the tag on the collider is equal to Obstacle
        if (coll.tag == "Obstacle")
        {
            transform.position = startingPos;
            startingPos = new Vector3(transform.position.x, transform.position.y, Random.Range(-0.4f, 0.4f));
        }
    }

    IEnumerator WaitFor(float seconds) //Oyun içi sayaç coroutine ile sayaç başlattım
    {
        float elapsedTime = 0;
        waitFinished = false;
        while (elapsedTime < seconds)
        {
            
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        waitFinished = true;
    }


}
