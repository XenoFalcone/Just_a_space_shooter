using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour 
{


    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource bossMusicSource;
    [SerializeField] private AudioSource VictoryMusicSource;

    const float FADE_TIME_SECONDS = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicTransition()
    {
        StartCoroutine(FadeOut(0.1f));
    }

    IEnumerator FadeOut(float delay)
    {
        yield return new WaitForSeconds(delay);
        var timeElapsed = 0f;

        while (musicSource.volume > 0)
        {
            musicSource.volume = Mathf.Lerp(0.4f, 0, timeElapsed / FADE_TIME_SECONDS);
            timeElapsed += Time.deltaTime;
            yield return delay;
        }

        yield return new WaitForSeconds(3);
        
        bossMusicSource.Play();

        /*while (bossMusicSource.volume < 0.4)
        {
            musicSource.volume = Mathf.Lerp(0, 1, timeElapsed / FADE_TIME_SECONDS);
            timeElapsed += Time.deltaTime;
            yield return delay;
        }*/


    }

    public void starVictoryMusic()
    {
        bossMusicSource.Stop();
        VictoryMusicSource.Play();
    }
}
