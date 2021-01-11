using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector3 direction;

    [SerializeField] private float shrinkMultiplier;

    [SerializeField] private bool shrinkX = true;
    [SerializeField] private bool shrinkY = true;
    [SerializeField] private bool shrinkZ = true;

    private Transform _transform;
    // Start is called before the first frame update

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Shrinking();
        Movement();
    }


    private void Movement()
    {
        _transform.position += direction * Time.deltaTime * movementSpeed;
    }
    private void Shrinking()
    {
        Vector3 beginScale = _transform.localScale;
        Vector3 currentScale = beginScale;
        if (shrinkX)
        {
            currentScale.x -= shrinkMultiplier * Time.deltaTime;
            if (currentScale.x < 0.2) currentScale.x = 0;
        }

        if (shrinkY)
        {
            if (currentScale.y < 0.2) currentScale.y = 0;
            currentScale.y -= shrinkMultiplier * Time.deltaTime;
        }

        if (shrinkZ)
        {
            if (currentScale.z < 0.2) currentScale.z = 0;
            currentScale.z -= shrinkMultiplier * Time.deltaTime;
        }

        if (beginScale.x < 0.2 || beginScale.y < 0.2 || beginScale.z < 0.2) Destroy(gameObject);
        _transform.localScale = currentScale;
    }
}