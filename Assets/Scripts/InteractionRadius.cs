using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRadius : MonoBehaviour {

  
    private List<Interactable> interactables = new List<Interactable>();
    public Interactable target;
    private float minimumDistance = 0.3f;


    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
        target = null;
        float targetDistance = minimumDistance;
        foreach (Interactable interactiable in interactables)
        {
            float distance = Vector2.Distance(transform.position, interactiable.transform.position);
            if (targetDistance > distance)
            {
                target = interactiable;
                targetDistance = distance;
            }
        }
        if (target != null)
        {
            InteractionPopup.CallInteractionPopup(target);
        }
        else
        {
            InteractionPopup.DismissInteractionPopup();
        }
    }

    /// <summary>
    /// Handles triggers
    /// </summary>
    public void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null && !interactables.Contains(interactable))
        {
            interactables.Add(interactable);
        }
    }
}
