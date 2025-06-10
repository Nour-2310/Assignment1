using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Placeholder : MonoBehaviour
{
    public string acceptedTag;           // e.g. "Red", "Green", "Blue"
    public AudioSource audioSource;      // Shared AudioSource
    public AudioClip buzzClip;           // Sound to play when cube is wrong

    private void OnTriggerEnter(Collider other)
    {
        // If the cube matches the correct tag (correct color)
        if (other.CompareTag(acceptedTag))
        {
            // Lock it in place
            XRGrabInteractable grab = other.GetComponent<XRGrabInteractable>();
            if (grab) grab.enabled = false;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb) rb.isKinematic = true;

            // Snap to placeholder position
            other.transform.position = transform.position;

            // Notify PuzzleManager
            PuzzleManager.Instance.MarkCubePlaced(acceptedTag);
        }
        else
        {
            // Play buzz sound for wrong placement
            if (audioSource && buzzClip)
            {
                audioSource.clip = buzzClip;
                audioSource.Play();
            }

            // Reset cube to original position
            ResetPosition reset = other.GetComponent<ResetPosition>();
            if (reset != null)
            {
                other.transform.position = reset.originalPosition;
            }
        }
    }
}
