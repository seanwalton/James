using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class JumpCounterUI : MonoBehaviour
{
    private TextMeshProUGUI myText;
    private JumpCounter jumpCounter;

    private int lastJumps;

    private void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        jumpCounter = FindObjectOfType<JumpCounter>();
    }

    private void Start()
    {
        UpdateJumpUI();
    }

    private void UpdateJumpUI()
    {
        lastJumps = jumpCounter.NumberOfJumps;
        SetText(lastJumps);
    }

    private void Update()
    {
        if (lastJumps != jumpCounter.NumberOfJumps)
        {
            UpdateJumpUI();
        }
    }

    private void SetText(int numJumps)
    {
        myText.text = numJumps.ToString() + " jumps";
    }


}
