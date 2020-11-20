using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    private static float _startTime;
    private static float _accumTime;
    private static bool _isPaused = false;

    public static int nextStage = 0;

    public static bool isPaused => _isPaused;

    public static float time => _accumTime + (!_isPaused ? (Time.time - _startTime) : 0);

    public static GameTimer _instance;

    public static GameObject playerObject;

    // Start is called before the first frame update
    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else
        {
            _instance = this;
            ResetTimer();
            DontDestroyOnLoad(gameObject);
        }
        _isPaused = false;

        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private Vector3 spawnPoint;

    public void LoadItemShop(int next_stage = 2)
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform.position + Vector3.up * 3;
        Player.playerInstance.gameObject.SetActive(false);
        nextStage = next_stage;
        SceneManager.LoadScene(4);
        
    }

    public void LoadDeathScene()
    {
        Destroy(Player.playerInstance.gameObject);
        SceneManager.LoadScene(3);
    }

    public void LoadStage(int stage = 2)
    {
        Player.playerInstance.gameObject.SetActive(true);
        Player.playerInstance.transform.position = spawnPoint;
        SceneManager.LoadScene(stage);
        spawnPoint = GameObject.Find("SpawnPoint").transform.position + Vector3.up * 3;
    }

    public void LoadNextStage()
    {
        LoadStage(nextStage);
    }

    public static void ResetTimer()
    {
        
        _startTime = Time.time;
        _accumTime = 0;
    }

    public static void PauseTimer()
    {
        _isPaused = true;
        _accumTime += Time.time - _startTime;
    }

    public static void UnpauseTimer()
    {
        _isPaused = false;
        _startTime = Time.time;
    }

}
