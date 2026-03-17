using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    #region Singleton
    private static BGMManager instance;
    public static BGMManager Instance
    {
        get
        {
            if (!FindObjectOfType<BGMManager>())
            {
                GameObject g = new GameObject();
                instance = g.AddComponent<BGMManager>();
            }
            return instance;
        }
    }
    #endregion

     private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += ChangeMusic;
    }

    private void Start() 
    {
        if(FindObjectOfType<BGM>())
        {
            BGM bgm = FindObjectOfType<BGM>();
            audioSource.clip = bgm.AudioClip;
            audioSource.Play();
        }
    }

    private void ChangeMusic(Scene scene, LoadSceneMode mode)
    {
        if(FindObjectOfType<BGM>())
        {   
            BGM bgm = FindObjectOfType<BGM>();
            audioSource.clip = bgm.AudioClip;
            audioSource.Play();
        }
    }
}
