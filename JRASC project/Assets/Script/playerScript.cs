using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    private float speed = 20;
    private Vector3 targetPosition;
    private bool isMoving;

	// Use this for initialization
	void Start () {
        targetPosition = transform.position;
        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Right mouse button
     if(Input.GetMouseButton(1))
        {
            setTargetPosition();
        }
     if(isMoving)
        {
            MovePlayer();
        }
    }

    void setTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if(plane.Raycast (ray, out point))
        {
            targetPosition = ray.GetPoint(point);
        }

        isMoving = true;
    }
    void MovePlayer()
    {
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(transform.position == targetPosition)
        {
            //found destination
            isMoving = false;
        }

    }
}
