using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public UnityEvent OnPauseEvent = new UnityEvent();
    public UnityEvent OnVictory = new UnityEvent();
    public int score = 0;
    public TextMeshProUGUI EndScoreLabel;
    public TextMeshProUGUI VictoryLabel;
    public TextMeshProUGUI ScoreLabel;
    //public bool waveMode = false;
    public int NbrDestroyedEnnemies = 0;
    public int BossApparition = 30;
    public bool BossPhase;
    public bool BossDestroyed;

    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject bossSpawner;
    [SerializeField] private GameObject music;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(BossPhaseRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    public void OnPause()
    {
        OnPauseEvent.Invoke();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddScore(int value)
    {
        score += value;
        //scoreLabel.text = score.ToString();
        EndScoreLabel.text = "Score : "+score.ToString();
        ScoreLabel.text = "Score : " + score.ToString();
        VictoryLabel.text = "Score : " + score.ToString();
    }

    public void AddDestroy()
    {
        NbrDestroyedEnnemies++;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DeselectClickedButton(GameObject button)
    {
        if (EventSystem.current.currentSelectedGameObject == button)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    IEnumerator BossPhaseRoutine()
    {
        //transform.position : position dans le monde
        //transform.localPosition : position par rapport au parent
        //transform.parent = null


        while(NbrDestroyedEnnemies < BossApparition)
        {
            yield return new WaitForSeconds(1);
        }

        BossPhase = true;
        yield return new WaitForSeconds(3);

        music.GetComponent<MusicController>().MusicTransition();

        yield return new WaitForSeconds(7);



        //Faire apparaitre le boss
        Instantiate(boss, bossSpawner.transform);

        while (!BossDestroyed)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(5);

        music.GetComponent<MusicController>().starVictoryMusic();

        OnVictory.Invoke();

    }

}
