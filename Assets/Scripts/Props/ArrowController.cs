using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject midPointVisual, arrowPrefab, arrowSpawnPoint;
    [SerializeField] private ArrowPrefabSpell spell;
    [SerializeField] private ArrowManager am;


    [SerializeField]
    private float arrowMaxSpeed = 10;

    [SerializeField]
    private AudioSource bowReleaseAudioSource;

    public void PrepareArrow()
    {
        midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        bowReleaseAudioSource.Play();
        midPointVisual.SetActive(false);

        GameObject arrow = Instantiate(arrowPrefab);
        Debug.Log("heheheheheooooooooo" + am.spellIdx);
        if(am.spellIdx== 0)
        {
            Transform effect = arrow.transform.Find("Arrow/Loading_free_yellow");
            effect.gameObject.SetActive(true);

        }
        else if(am.spellIdx== 1)
        {
            Transform effect = arrow.transform.Find("Arrow/Loading_free_blue");
            effect.gameObject.SetActive(true);
        }
        else if(am.spellIdx== 2)
        {
            Transform effect = arrow.transform.Find("Arrow/Loading_free_purple");
            effect.gameObject.SetActive(true);
        }
        else if(am.spellIdx== 3)
        {
            Transform effect = arrow.transform.Find("Arrow/Loading_free_green");
            effect.gameObject.SetActive(true);
        }

        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = midPointVisual.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);

    }
}