using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float speedChar = 1f;
    private Vector3 startingPos;
    private bool movementTrue = true;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(movementTrue)
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(1f, 0f, 0f), speedChar * Time.deltaTime);

        if(transform.position.x > 21f)
        {
            transform.position = new Vector3(21f, transform.position.y, transform.position.z);
            movementTrue = false;
            this.transform.GetComponent<Animator>().SetTrigger("Finished");
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (coll.tag == "Obstacle")
        {
            transform.position = startingPos;
            //Debug.Log("Triggered by Obstacle");
        }
    }
}
