using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    Vector3 previousMousePos;
    Vector3 mouseDelta;

    public GameObject target;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
        //automatically move to the target position
        Drag();

    }

    void Drag()
    {
    
        if(Input.GetMouseButton(1))
        {
            //while the mouse is held down  the cube can be moved around its central axis to provide visual feedback
            mouseDelta = (Input.mousePosition - previousMousePos) * .1f;

            // mouseDelta's x and y is either both negative or both positive in one axis, while x and y's polarity is different on the other axis. This is important to decide if we want to rotate X or Z
            bool axisDirection = mouseDelta.x * mouseDelta.y < 0; 

            transform.rotation = Quaternion.Euler(axisDirection ? mouseDelta.y : mouseDelta.y * 0.2f, -mouseDelta.x,
                                                  axisDirection ? -mouseDelta.y * 0.2f : -mouseDelta.y) *transform.rotation; 
            
        }
        else
        {
            //automatically move to the target position
            if (transform.rotation != target.transform.rotation)
            {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }

        previousMousePos   = Input.mousePosition;

    }

    void Swipe()
    {
        //get the 2d position of the first mouse click
        if(Input.GetMouseButtonDown(1))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }

        if(Input.GetMouseButtonUp(1))
        {
            //get the 2d position of the second mouse click
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //create a vector prom the first and second click positions
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            currentSwipe.Normalize(); 

            if(LeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0,90,0, Space.World);
            }
            else if(RightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (UpLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (UpRightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, -90, Space.World);
            }
            else if (DownLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, 90, Space.World);
            }
            else if (DownRightSwipe(currentSwipe))
            {
                target.transform.Rotate(-90, 0, 0, Space.World);
            }
        }

    }

    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool UpLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0f;
    }

    bool UpRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x > 0f;
    }

    bool DownLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x < 0f;
    }

    bool DownRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0f;
    }
}
