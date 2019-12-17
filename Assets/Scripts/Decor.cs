using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor : MonoBehaviour
{

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Debug.Log(mainCamera.pixelHeight + " " + mainCamera.pixelWidth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
