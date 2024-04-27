using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAura : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = hand.transform.position;
    }
}
