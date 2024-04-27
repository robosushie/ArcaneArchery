using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private SphereCollider myCollider;
    [SerializeField] private GameObject[] children;
    [SerializeField] private GameObject[] effects;

    [SerializeField] private AudioSource meteor;
    [SerializeField] private AudioSource lightening;

    [SerializeField]
    private GameObject stickingArrow;


    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject arrow = Instantiate(stickingArrow, transform.position, Quaternion.LookRotation(transform.forward));

        if (collision.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
        }

        if (children[0].activeSelf)
        {
            GameObject effect = Instantiate(effects[0], transform.position, Quaternion.identity);
            if (effect != null)
            {
                Destroy(effect, 5f);
            }
            Destroy(arrow, 5f);
        }
        else if (children[1].activeSelf)
        {
            GameObject effect = Instantiate(effects[1], transform.position, Quaternion.identity);
            if (effect != null)
            {
                Destroy(effect, 5f);
            }
            Destroy(arrow, 5f);
        }
        else if (children[2].activeSelf)
        {
            GameObject effect = Instantiate(effects[2], transform.position, Quaternion.identity);
            if (effect != null)
            {
                Destroy(effect, 5f);
            }
            Destroy(arrow, 5f);
        }

        // Destroy arrow and effect after 5 seconds
        
        Destroy(gameObject);
    }
}
