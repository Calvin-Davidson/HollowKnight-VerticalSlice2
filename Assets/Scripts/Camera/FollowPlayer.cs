using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private GameObject playerObject;

    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = playerObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraNewPosition = _playerTransform.position;
        cameraNewPosition.y += 1;
        cameraNewPosition.z = -10;
        transform.position = cameraNewPosition;
    }
}
