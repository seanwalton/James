using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCounter : MonoBehaviour
{
    public int NumberOfJumps { private set; get; }

    private void Awake()
    {
        NumberOfJumps = 0;
    }

    public void AddJump()
    {
        NumberOfJumps++;
    }

}
