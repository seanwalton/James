using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class JumpCounterUI : MonoBehaviour
{
    private TextMeshProUGUI myText;
    private CharacterController2D characterController;
    private JumpCounter jumpCounter;
    private int numJumps;

    private void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        characterController = FindObjectOfType<CharacterController2D>();
        characterController.OnJumpEvent.AddListener(AddJump);
    }

    private void Start()
    {
        numJumps = 0;
        UpdateJumpUI();
    }

    private void UpdateJumpUI()
    {     
        SetText(numJumps);
    }
  
    public void AddJump()
    {
        numJumps++;
        UpdateJumpUI();
    }

    private void SetText(int numJumps)
    {
        if (numJumps == 1)
        {
            myText.text = numJumps.ToString() + " Jump";
        }
        else
        {
            myText.text = numJumps.ToString() + " Jumps";
        }   
    }


}
