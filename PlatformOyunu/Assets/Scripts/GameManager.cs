using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;
using Mirror;

public class GameManager : NetworkBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private float delay = 2f;
    [SerializeField] private bool isGameEnding = false;
    public GameObject winnerUI;
    public int score;
    public TMP_Text scoreText;
    public TMP_Text winText;

    void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
    }

    public void respawnPlayer()
    {
        if (!isGameEnding)
        {
            isGameEnding = true;
            //TurnSpawnPointCommand();
        }
    }

    


    //private IEnumerator respawnCoroutine()
    //{
    //    score = 0;
    //    scoreText.text = score.ToString();
    //    playerControl.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(delay);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    //    //playerControl.transform.position = playerControl.spawnPoint;
    //    //playerControl.gameObject.SetActive(true);
    //    isGameEnding = false;
    //}

    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = score.ToString();
    }

    public void LevelUp()
    {
        winnerUI.SetActive(true);
        winText.text = "Seviye Tamamlandý. Toplam Puan :" + score;
        Invoke("NextLevel", 2f);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
