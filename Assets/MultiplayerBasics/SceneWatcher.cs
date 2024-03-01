using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWatcher : MonoBehaviourPunCallbacks
{
    public static SceneWatcher Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
            return;
        }
        
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
    
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);
        if (scene.buildIndex >= 1)
        {
            Vector3 spawnPoint = SpawnManager.Instance.GetRandomSpawnPoint().position;
            spawnPoint.z = 0;
            // INSTANTIATE THE PLAYER
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnPoint, Quaternion.identity);
        }
    }
}
