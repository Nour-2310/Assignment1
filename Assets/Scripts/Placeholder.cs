using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Placeholder : MonoBehaviour
{
    public string acceptedTag;
    public AudioSource buzzSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(acceptedTag))
        {
            // Correct cube
            var grab = other.GetComponent<XRGrabInteractable>();
            if (grab) grab.enabled = false;

            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = transform.position;
            PuzzleManager.Instance.MarkCubePlaced(acceptedTag);
        }
        else
        {
            // Wrong cube
            buzzSound?.Play();
            other.transform.position = other.GetComponent<ResetPosition>().originalPosition;
        }
    }
}
