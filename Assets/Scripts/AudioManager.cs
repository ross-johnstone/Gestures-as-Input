using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
public GameObject Object1;
public GameObject Object2;
public GameObject Object3;
public AudioClip[] musicList;
private int current;
private AudioSource source;

public void PlayMusic()
{
    if (source.isPlaying)
    {
        return;
    }
    if (current < 0)
    {
        current = musicList.Length - 1;
    }
    source.clip = musicList[current];
    source.Play();
}

public void NextSong()
{
    source.Stop();
    current++;
    if (current > musicList.Length - 1)
    {
        current = 0;
    }
    source.clip = musicList[current];
    iTween.MoveTo(Object1, iTween.Hash("x", Object2.transform.position.x, "y", Object2.transform.position.y, "z", Object2.transform.position.z, "time", 1));
    iTween.MoveTo(Object2, iTween.Hash("x", Object3.transform.position.x, "y", Object3.transform.position.y, "z", Object3.transform.position.z, "time", 1));
    iTween.MoveTo(Object3, iTween.Hash("x", Object1.transform.position.x, "y", Object1.transform.position.y, "z", Object1.transform.position.z, "time", 1));
    source.clip = musicList[current];
    source.Play();
}

public void PreviousSong()
{
    source.Stop();
    current--;
    if (current < 0)
    {
        current = musicList.Length - 1;
    }
    source.clip = musicList[current];
    iTween.MoveTo(Object1, iTween.Hash("x", Object3.transform.position.x, "y", Object3.transform.position.y, "z", Object3.transform.position.z, "time", 1));
    iTween.MoveTo(Object2, iTween.Hash("x", Object1.transform.position.x, "y", Object1.transform.position.y, "z", Object1.transform.position.z, "time", 1));
    iTween.MoveTo(Object3, iTween.Hash("x", Object2.transform.position.x, "y", Object2.transform.position.y, "z", Object2.transform.position.z, "time", 1));
    source.clip = musicList[current];
    source.Play();
}

// Start is called before the first frame update
void Start()
{
    Object1 = GameObject.Find("Object1");
    Object2 = GameObject.Find("Object2");
    Object3 = GameObject.Find("Object3");
    source = GetComponent<AudioSource>();
}

// Update is called once per frame
void Update()
{

    if (Input.GetKeyDown(KeyCode.Keypad1))
    {
        if (!source.isPlaying)
        {
            PlayMusic();
        }
        else
        {
            source.Pause();
        }
    }
    if (Input.GetKeyDown(KeyCode.Keypad2))
    {
        NextSong();
    }
    if (Input.GetKeyDown(KeyCode.Keypad3))
    {
        PreviousSong();
    }
    if (Input.GetKey(KeyCode.Keypad4))
    {
        source.volume = source.volume + (float)0.1;
    }
    if (Input.GetKey(KeyCode.Keypad5))
    {
        source.volume = source.volume - (float)0.1;
    }
    }
}
