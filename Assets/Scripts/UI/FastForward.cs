using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForward : MonoBehaviour
{
    public static bool FastForwarded;

    public void ToggleFastForward()
    {
        if (PauseMenu.paused)
        {
            return;
        }
        if (FastForwarded)
        {
            Time.timeScale = 1f;
            FastForwarded = false;
        }
        else
        {
            Time.timeScale = 10f;
            FastForwarded = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}