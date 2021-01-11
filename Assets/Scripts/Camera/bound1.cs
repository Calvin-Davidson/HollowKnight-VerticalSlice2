using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound1 : MonoBehaviour
{
    [SerializeField] CameraLerp camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("1");
        camera.changeBound(camera.bounds1);
    }
}
