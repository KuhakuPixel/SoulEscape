using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;//Sound is a class/script
    public static AudioManager instance;
    void Awake()//called even before start
    {
        //to fix the double audioManager problem
        if (instance == null) 
        {
            instance = this;
            
        }
        else 
        {
        Destroy(gameObject);
            return;//making sure no more code is called before destroying the game object
        }
        //
        foreach(Sound s in sounds) //s is the name of Sound Class
        {
            s.source=gameObject.AddComponent<AudioSource>();//adding an AudioSource in this empty gameobject called AudioManager
            s.source.clip = s.clip;//adding the type AudioSoure called clip into clip in the audiosource
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;


        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        play("Theme");
    }

    void Update()
    {
        
    }
    public void play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        
    }
}
