using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioDetectorScript : MonoBehaviour
{
    private List<AudioSource> validAudioSources = new List<AudioSource>();

    public string tagToExclude1 = "IgnoreSound";
    public string tagToExclude2 = "Player"; 

    void Start()
    {
   
        AudioSource[] allSources = Object.FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

        foreach (AudioSource source in allSources)
        {
            if (!source.CompareTag(tagToExclude1) && !source.CompareTag(tagToExclude2))
            {
                validAudioSources.Add(source);
            }
        }
    }

    void Update()
    {
        if (IsValidAudioPlaying())
        {
            //Debug.Log("Audio is playing (excluding the tagged ones)!");
        }
    }

    public bool IsValidAudioPlaying()
    {
        for (int i = 0; i < validAudioSources.Count; i++)
        {
            // Null check in case an AudioSource was destroyed mid-game
            if (validAudioSources[i] != null && validAudioSources[i].isPlaying)
            {
                return true; 
            }
        }
        return false;
    }
}
