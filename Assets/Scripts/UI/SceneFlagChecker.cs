using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFlagChecker : MonoBehaviour
{
    public static bool globalFlag = false; // Global flag to be checked
    private static float resetTime = 180f; // 3 minutes (180 seconds)

    void Start()
    {
        // Load last interaction time from PlayerPrefs
        if (PlayerPrefs.HasKey("LastInteractionTime"))
        {
            float lastInteractionTime = PlayerPrefs.GetFloat("LastInteractionTime");

            // If too much time has passed, reset the flag
            if (Time.time - lastInteractionTime > resetTime)
            {
                globalFlag = false;
            }
        }

        // Set the flag to true the first time this object becomes active
        if (!globalFlag)
        {
            globalFlag = true;
        }
        else
        {
            CheckFlag();
        }
    }

    void Update()
    {
        // Detect interaction (Keyboard, Mouse, or Touch)
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || Input.touchCount > 0)
        {
            PlayerPrefs.SetFloat("LastInteractionTime", Time.time);
            PlayerPrefs.Save();
        }
    }

    void CheckFlag()
    {
        if (globalFlag)
        {
            gameObject.SetActive(false);
        }
    }
}
