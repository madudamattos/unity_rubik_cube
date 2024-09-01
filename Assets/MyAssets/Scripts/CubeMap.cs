using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    CubeState cubeState;

    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform back;
    public Transform front;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set()
    {
        cubeState = FindAnyObjectByType<CubeState>();

        UpdateMap(cubeState.front, front);
        UpdateMap(cubeState.back, back);
        UpdateMap(cubeState.right, right);
        UpdateMap(cubeState.left, left);
        UpdateMap(cubeState.up, up);
        UpdateMap(cubeState.down, down);
        
    }

    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        foreach (Transform map in side)
        {

            if (face[i].name == "Front")
            {
                map.GetComponent<Image>().color = Color.yellow;
            }
            if (face[i].name == "Back")
            {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            if (face[i].name == "Up")
            {
                map.GetComponent<Image>().color = Color.red;
            }
            if (face[i].name == "Down")
            {
                map.GetComponent<Image>().color = Color.blue;
            }
            if (face[i].name == "Left")
            {
                map.GetComponent<Image>().color = Color.green;
            }
            if (face[i].name == "Right")
            {
                map.GetComponent<Image>().color = Color.white;
            }
            
            i++;
        }
    }
}
