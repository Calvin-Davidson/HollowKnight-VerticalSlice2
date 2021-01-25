using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraLerp : MonoBehaviour
{
    Vector3 desiredPosition;
    Vector3 smoothedPosition;
    [SerializeField] Transform player;
    CameraBounds2D bounds;
    [SerializeField] public CameraBounds2D bounds1;
    [SerializeField] public CameraBounds2D bounds2;
    [SerializeField] float speed = 3;
    [SerializeField] private float desiredZposition;
    
    Vector2 maxXPositions,maxYPositions;
    // Start is called before the first frame update
    void Awake()
    {
	    bounds = bounds1;
		bounds.Initialize(GetComponent<Camera>());
        	maxXPositions = bounds.maxXlimit;
        	maxYPositions = bounds.maxYlimit;
	}

    public void changeBound(CameraBounds2D bound)
    {
        bounds = bound;
        bounds.Initialize(GetComponent<Camera>());
        	maxXPositions = bounds.maxXlimit;
        	maxYPositions = bounds.maxYlimit;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        // transform.position = new Vector3(0,newY,-8);
        
         
         desiredPosition.z = desiredZposition;
         
         
         desiredPosition = new Vector3(Mathf.Clamp(player.position.x, maxXPositions.x, maxXPositions.y), Mathf.Clamp(player.position.y, maxYPositions.x, maxYPositions.y), desiredPosition.z);

         smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, Time.deltaTime*speed);
         transform.position = smoothedPosition;
    }
}
