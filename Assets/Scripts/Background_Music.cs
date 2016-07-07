using UnityEngine;
using System.Collections;

public class Background_Music : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] audio_clips;
    private int currentClip = 0;

    void Start()
    {
        StartCoroutine(LoopClips());
    }

    IEnumerator LoopClips()
    {
        while (true)
        {
            source.clip = audio_clips[currentClip];
            source.Play();

            yield return new WaitForSeconds(source.clip.length);

            currentClip++;

            if (currentClip >= audio_clips.Length)
                currentClip = 1;
        }
    }
}
