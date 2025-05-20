using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopOff : MonoBehaviour
{
    public void HopOffGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Editor
#else
        Application.Quit(); // Quit the built game
#endif
    }
}
