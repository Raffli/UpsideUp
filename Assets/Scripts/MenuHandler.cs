using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {

    public AudioSource buttonCLick;
    public Text score;

    void Start () {
        int soundInt = PlayerPrefs.GetInt("Sound");
        int score1 = PlayerPrefs.GetInt("Score1");
        int score2 = PlayerPrefs.GetInt("Score2");
        int score3 = PlayerPrefs.GetInt("Score3");

        score.text = "Highscores: \n 1: " + score1 + "\n2: " + score2 + "\n3: " + score3;

        if (soundInt == 1) {
            AudioListener.pause = true;
        }
        else {
          AudioListener.pause = false;
        }

    }

    void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();


        }

    }

    public void StartGame() {
        buttonCLick.Play();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartStopAudio()
    {
        if (AudioListener.pause)
        {
            AudioListener.pause = false;
            PlayerPrefs.SetInt("Sound",0);
        }
        else {
            AudioListener.pause = true;
            PlayerPrefs.SetInt("Sound", 1);
        }
    }
}
