using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius=5f;//互動半徑
    private Transform interactionTransform;
    private Transform player;

    void Start()
    {
       player = GameObject.Find("Player").transform;

        interactionTransform = GetComponent<Transform>();
    }


    void Update()
    {
        
           float distance = Vector3.Distance(player.position, interactionTransform.position);
            // If we haven't already interacted and the player is close enough
            if (distance <= radius)
            {
            if (Input.GetKeyDown(KeyCode.E))
            // Interact with the object
            { 
                Interact();
            }
            }
        
    }

  
    public virtual void Interact()
    {
        //Debug.Log("Interacting");
    }
}
