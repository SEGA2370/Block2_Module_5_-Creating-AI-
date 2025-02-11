using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    private JobHandle jobHandle;
    private ConfigPrintJob job;
    private bool jobRunning = false;

    // NativeArrays for job data
    private NativeArray<float> playerSpeed;
    private NativeArray<int> enemyCount;
    private NativeArray<int> gameMode;

    private void OnEnable()
    {
        ConfigurationManager.OnConfigLoaded += StartConfigJob;
    }

    private void OnDisable()
    {
        ConfigurationManager.OnConfigLoaded -= StartConfigJob;
    }

    private void StartConfigJob()
    {
        var config = ConfigurationManager.Instance.ConfigAsync;

        if (config == null)
        {
            Debug.LogError("Configuration not loaded in time!");
            return;
        }

        // Allocate memory for NativeArrays
        playerSpeed = new NativeArray<float>(1, Allocator.Persistent);
        enemyCount = new NativeArray<int>(1, Allocator.Persistent);
        gameMode = new NativeArray<int>(1, Allocator.Persistent);

        playerSpeed[0] = config.playerSpeed;
        enemyCount[0] = config.enemyCount;
        gameMode[0] = config.gameMode == "Hard" ? 1 : 0; // Convert string to int for Job

        job = new ConfigPrintJob
        {
            PlayerSpeed = playerSpeed,
            EnemyCount = enemyCount,
            GameMode = gameMode
        };

        jobHandle = job.Schedule(); // Schedule without blocking
        jobRunning = true;
    }

    private void Update()
    {
        if (jobRunning && jobHandle.IsCompleted)
        {
            jobHandle.Complete(); // Ensure the job has finished
            Debug.Log("Job Finished - All Config Loaded!");

            // Dispose of NativeArrays
            playerSpeed.Dispose();
            enemyCount.Dispose();
            gameMode.Dispose();

            jobRunning = false;
        }
    }

    struct ConfigPrintJob : IJob
    {
        public NativeArray<float> PlayerSpeed;
        public NativeArray<int> EnemyCount;
        public NativeArray<int> GameMode;

        public void Execute()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Debug.Log("Job Started - Loading Config");

            while (stopwatch.ElapsedMilliseconds < 2000) { }
            Debug.Log($"Player Speed: {PlayerSpeed[0]}");

            while (stopwatch.ElapsedMilliseconds < 4000) { }
            Debug.Log($"Enemy Count: {EnemyCount[0]}");

            while (stopwatch.ElapsedMilliseconds < 6000) { }
            Debug.Log($"Game Mode: {(GameMode[0] == 1 ? "Hard" : "Easy")}");
        }
    }
}
