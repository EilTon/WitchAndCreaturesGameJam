using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPNJ : MonoBehaviour
{
    // Pnj Prefab
    public GameObject pnjPrefab;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

        // Instantiate the food at (x, y)
        Instantiate(pnjPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}
