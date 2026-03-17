using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    public AudioClip AudioClip { get { return audioClip; } }  
}
