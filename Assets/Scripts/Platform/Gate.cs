using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] GateTrigger gateTrigger;
    [SerializeField] VoidEventChannel gateTriggerEventChanels;

    private void OnEnable()
    {
        gateTriggerEventChanels.AddListen(Open);
    }

    private void OnDisable()
    {
        gateTriggerEventChanels.RemoveListen(Open);

    }

    private void Start()
    {
        if (gateTrigger == null) gateTrigger = FindObjectOfType<GateTrigger>();
    }
    void Open()
    {
        Destroy(gameObject);
    }
}
