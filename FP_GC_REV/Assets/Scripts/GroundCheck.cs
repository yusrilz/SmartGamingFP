using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public bool isGrounded;
    private void OnTriggerStay2D(Collider2D collider) {
        if(collider != null && collider.gameObject.layer != platformLayerMask) isGrounded = true;
        // Debug.Log(isGrounded);
    }

    private void OnTriggerExit2D(Collider2D collider) {
        isGrounded = false;
    }
}
