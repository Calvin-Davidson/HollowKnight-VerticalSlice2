using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusquitoDamage : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject myPrefab;
    [SerializeField] float damageDelay;
    private float delay;


    void Update()
    {
        delay += Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(delay > damageDelay){
           if(collider.tag == "PlayerSwordSwing")
             {
                health -= 1;
                Instantiate(myPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
                Debug.Log("Current Health: " + health);
                if(health < 1)
                {
                    Destroy(this.gameObject);
                }
                delay = 0;
            } 
            
        }
        
        
    }
}
