using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactionText = "Interact";
    public Vector2 offset;



    /// <summary>
    /// Sets the Interaction-action of the object
    /// </summary>
    /// <param name="interactor">source of the interaction</param>
    public virtual void Interact(GameObject interactor)
    {
        Debug.LogWarning("No Interaction set");
    }
}
