using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake(){
        foreach(Sound mySound in sounds){
            mySound.source = gameObject.AddComponent<AudioSource>();
            mySound.source.clip = mySound.clip;

            mySound.source.volume = mySound.volume;
            mySound.source.pitch  = mySound.pitch;
            mySound.source.loop   = mySound.loop;
        }

    }
    // Start is called before the first frame update

    public void play_clip (string name){
        Sound mySound = Array.Find(sounds, sound => sound.name == name);
        if (mySound == null){
            Debug.LogWarning("sound " + name.ToString() + " is not found.");
            return;
        }
        mySound.source.Play();

    }

    public void lower_volume(string name){
        Sound mySound = Array.Find(sounds, sound => sound.name == name);
        mySound.source.volume = 0.1f; 
    }

    public void normal_volume(string name){
        Sound mySound = Array.Find(sounds, sound => sound.name == name);
        mySound.source.volume = 0.3f; 
    }

    public void volume_up(string name){
        Sound mySound = Array.Find(sounds, sound => sound.name == name);
        mySound.source.volume = mySound.source.volume + 0.1f;
    }

    public void volume_down(string name){
        Sound mySound = Array.Find(sounds, sound => sound.name == name);
        mySound.source.volume = mySound.source.volume - 0.1f;
    }

}
