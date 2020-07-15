using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPopup : MonoBehaviour {
    public static InteractionPopup instance;


	// Use this for initialization
	void Start () {
        instance = this;

    }
	

    /// <summary>
    /// Call the interaction popup
    /// </summary>
    public static void CallInteractionPopup(Interactable interactor)
    {
        Vector2 offset = interactor.offset;
        instance.transform.position = Camera.main.WorldToScreenPoint((Vector2)interactor.transform.position + offset);
    }

    /// <summary>
    /// Dismiss the interaction popup
    /// </summary>
    public static void DismissInteractionPopup()
    {
        instance.transform.position = new Vector3(10000, 10000, 100);
    }
}
