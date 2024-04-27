using Oculus.Voice;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VoiceIntentController : MonoBehaviour
{
    [SerializeField] private ActionBasedController rightHand;
    [SerializeField] private AppVoiceExperience appVoiceExperience;
    [SerializeField] private GameObject[] aura;
    [SerializeField] private GameObject[] bow_viz_aura;
    [SerializeField] private ArrowManager am;

    private bool appVoiceActive;

    [System.Obsolete]
    private void Awake()
    {

        appVoiceExperience.TranscriptionEvents.OnFullTranscription.AddListener((transcription) =>
        {
            Debug.Log(transcription);

            ResetPower(aura);
            ResetPower(bow_viz_aura);
            
            if (transcription == "Fire spell")
            {
                SetPower(aura[0]);
                SetPower(bow_viz_aura[0]);
                am.SetSpellIdx(0);
            }
            else if (transcription == "Lightening spell")
            {
                SetPower(aura[1]);
                SetPower(bow_viz_aura[1]);
                am.SetSpellIdx(1);
            }
            else if (transcription == "Meteor spell")
            {
                SetPower(aura[2]);
                SetPower(bow_viz_aura[2]);
                am.SetSpellIdx(2);
            }
            else if (transcription == "Teleportation spell")
            {
                SetPower(aura[3]);
                SetPower(bow_viz_aura[3]);
                am.SetSpellIdx(3);
            }

        });

        appVoiceExperience.TranscriptionEvents.OnPartialTranscription.AddListener((transcription) =>
        {
            Debug.Log(transcription);
        });

        appVoiceExperience.VoiceEvents.OnRequestCreated.AddListener((request) =>
        {
            appVoiceActive = true;
            Debug.Log("voice init");
        });

        appVoiceExperience.VoiceEvents.OnRequestCompleted.AddListener(() =>
        {
            appVoiceActive = false;
            Debug.Log("voice completed");
        });
    }

    private void OnEnable()
    {
        // Subscribe to Select and Activate actions
        rightHand.activateAction.action.started += OnSelectPressed;
        rightHand.activateAction.action.canceled += OnSelectReleased;

    }

    private void OnSelectReleased(InputAction.CallbackContext obj)
    {
        Debug.Log("activate released");

    }

    private void OnSelectPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("activate pressed");
        if (true)
        {
            appVoiceExperience.Activate();
        }
        
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        rightHand.activateAction.action.started -= OnSelectPressed;
        rightHand.activateAction.action.canceled -= OnSelectReleased;

    }

    public enum Spells 
    {
        fire,
        lightening,
        meteor,
        teleportation
    }

    public void ResetPowerAll()
    {
        ResetPower(aura);
        ResetPower(bow_viz_aura);
    }

    public void ResetPower(GameObject[] arr)
    {
        foreach(var item in arr)
        {
            item.SetActive(false);
        }
    }

    public void SetPower(GameObject item)
    {item.SetActive(true);
    }

    public void SetFireSpell(String[] info)
    {
        Debug.Log("testttting" + info[0]);
        if(info.Length > 0 && Enum.TryParse(info[0], out Spells spell))
        {
            Debug.Log("entered " + info[0]);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
