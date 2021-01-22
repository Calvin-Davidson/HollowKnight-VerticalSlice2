using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound1 : MonoBehaviour
{
    [SerializeField] new CameraLerp camera;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("1");
        camera.changeBound(camera.bounds1);
    }
}
