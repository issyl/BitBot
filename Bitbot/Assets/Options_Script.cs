﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options_Script : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void setVolume(float volume)
    {
        audiomixer.SetFloat("MasterVolume", volume);
    }

    public void setFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    #region Resolutions Setting

    #region Attributes

    #region Player Pref Key Constants

    private const string RESOLUTION_PREF_KEY = "resolution";
    
    #endregion

    #region Resolution

    [SerializeField]
    private Text resolutionText;

    private Resolution[] resolutions;

    private int currentResolutionIndex = 0;
    #endregion

    #endregion

    #endregion

    void Start()
    {
        resolutions = Screen.resolutions;

        currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, 0);
    }

    #region Resolution Cycling

    private void SetResolutionText(Resolution resolution)
    {
        resolutionText.text = resolution.width + "x" + resolution.height;
    }

    public void SetNextResolution()
    {
        currentResolutionIndex = GetNextWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);
    }

    public void SetPreviousResolution()
    {
        currentResolutionIndex = GetPreviousWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);
    }

    #endregion

    #region Misc Helpers

    #region Index Wrap Helpers
    private int GetNextWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if(collection.Count < 1) return 0;
        return (currentIndex + 1) % collection.Count;
    }

    private int GetPreviousWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        if ((currentIndex - 1) < 0) return collection.Count - 1;
        return (currentIndex - 1) % collection.Count;
    }

    #endregion

    #endregion

}