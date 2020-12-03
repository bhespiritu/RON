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
        SceneManager.sceneLoaded += OnSceneLoad;
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

    private Vector2 spawnPoint;

    public void LoadItemShop(int next_stage = 3)
    {
        Player.playerInstance.gameObject.SetActive(false);
        nextStage = next_stage;
        SceneManager.LoadScene(6);
        
    }

    public void LoadDeathScene()
    {
        Destroy(Player.playerInstance.gameObject);
        SceneManager.LoadScene(5);
    }

    public void LoadStage(int stage = 3)
    {
        Player.playerInstance.gameObject.SetActive(true);
        SceneManager.LoadScene(stage);

    }

    public void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "ItemShop")
        {
            var gameObject = GameObject.Find("SpawnPoint");
            spawnPoint = GameObject.Find("SpawnPoint").transform.position + Vector3.up * 3;
            Player.playerInstance.transform.position = spawnPoint;
        }
        if(scene.name == "StartScreen")
        {
            Player.playerInstance.gameObject.SetActive(false);
        }
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
