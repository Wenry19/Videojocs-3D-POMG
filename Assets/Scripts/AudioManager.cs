using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource musicAS;
    AudioSource soundsAS;
    AudioSource ropeAS;
    AudioSource colliAS;

    public AudioClip[] music;
    public AudioClip[] soundsArray;
    public AudioClip[] colliSounds;
    Dictionary<string, AudioClip> sounds;

    // Start is called before the first frame update
    void Start()
    {
        sounds = new Dictionary<string, AudioClip>();
        musicAS = transform.GetChild(0).GetComponent<AudioSource>();
        soundsAS = transform.GetChild(1).GetComponent<AudioSource>();
        ropeAS = transform.GetChild(2).GetComponent<AudioSource>();
        colliAS = transform.GetChild(3).GetComponent<AudioSource>();

        musicAS.clip = music[0];
        musicAS.loop = true;
        musicAS.Play();

        sounds["Space"] = soundsArray[0];
        sounds["Checkpoint"] = soundsArray[1];
        sounds["Open"] = soundsArray[2];
        sounds["Rope"] = soundsArray[3];
        sounds["Tecla"] = soundsArray[4];
        sounds["Explosion"] = soundsArray[5];
        sounds["WinLevel"] = soundsArray[6];
        sounds["WinGame"] = soundsArray[7];
        sounds["GameOver"] = soundsArray[8];


        ropeAS.clip = sounds["Rope"];
        ropeAS.loop = true;
    }

    public void nextLevel(int i)
    {
        musicAS.Stop();
        musicAS.clip = music[i];
        musicAS.Play();
    }

    public void playSound(string s)
    {
        soundsAS.PlayOneShot(sounds[s]);
    }
    public void playColli()
    {
        colliAS.Stop();
        colliAS.PlayOneShot(colliSounds[Random.Range(0, colliSounds.Length)]);
    }
    public void startRope()
    {
        ropeAS.Play();
    }

    public void stopRope()
    {
        ropeAS.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
