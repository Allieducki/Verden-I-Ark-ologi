using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    #region Singleton

    public static Interactable instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public float radius = 5f;

    bool isFocus = false;

    public Transform interactionTransform;

    Transform player;

    bool hasInteracted = false;

    public Material highlightMaterial;

    public Material defaultMaterial;

    public bool hasPressed = false;

    

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with: " + transform.name);
        if (hasInteracted == false)
        {
            hasInteracted = true;
        } else if (hasInteracted == true)
        {
            hasInteracted = false;
        }
        
    }



    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                
                var selectionRenderer = transform.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                hasInteracted = true;
                
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        
        isFocus = true;
        player = playerTransform;

        
    }

    public void OnDeFocused()
    {
        var selectionRenderer = transform.GetComponent<Renderer>();
        selectionRenderer.material = defaultMaterial;
        isFocus = false;
        player = null;
        hasInteracted = false;
        
    }


    private void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
