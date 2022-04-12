using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameConfig Config;

    public uint PlayerPoints;
    public uint PlayerXP;
    public uint PlayerLives;
    public uint PlayerCurrentLevel;

    public bool GameStarted;

    public Tank Player;
    Vector3 StartingTankPosition;

    float SpawnerTimer;

    Enemy[] EnemyTypes;
    public List<int> ProbabilityIndexes=new List<int>();

    public LevelConfig CurrentLevelConfig { get => Config.Levels[PlayerCurrentLevel]; }

    public UnityEvent OnGameEnded=new UnityEvent();
    public UnityEvent OnGameStarted = new UnityEvent();

    void Start()
    {
        Resources.LoadAll("/");
        EnemyTypes = Resources.FindObjectsOfTypeAll<Enemy>();

        for (int i = 0; i < EnemyTypes.Length; i++)
        {
            int pcount = (int)(EnemyTypes[i].SpawnProbability*50);
            for (int j = 0; j < pcount; j++)
            {
                ProbabilityIndexes.Add(i);
            }
        }

        StartingTankPosition = Player.transform.position;
        RestartGame();
    }

    public void RestartGame()
    {
        PlayerPoints = 0;
        PlayerXP = 0;
        PlayerCurrentLevel = 0;
        PlayerLives = Config.PlayerLives;

        Player.transform.position= StartingTankPosition;

        foreach (var item in FindObjectsOfType<Enemy>())
        {
            Destroy(item.gameObject);
        }
        foreach (var item in FindObjectsOfType<Bullet>())
        {
            Destroy(item.gameObject);
        }

        GameStarted = true;
        OnGameStarted.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarted)
        {
            SpawnerTimer += Time.deltaTime;
            if (SpawnerTimer>3f)
            {
                SpawnerTimer = 0;

                SpawnEnemy();
            }
        }
    }

    public void AddPoints(uint points)
    {
        PlayerPoints += points;
    }
    public void AddXp(uint xp)
    {
        PlayerXP += xp;

        if (PlayerCurrentLevel==Config.Levels.Length-1)
        {
            return;
        }

        if (PlayerXP >= Config.Levels[PlayerCurrentLevel+1].XPRequired)
        {
            PlayerCurrentLevel++;
        }
    }
    public void RemoveLife()
    {
        PlayerLives--;
        if (PlayerLives<=0)
        {
            GameStarted = false;
            OnGameEnded.Invoke();
        }
    }
    void SpawnEnemy()
    {
        int targetIndex = ProbabilityIndexes[Random.Range(0, ProbabilityIndexes.Count)];
        Enemy targetConfig = EnemyTypes[targetIndex];

        var gm = Instantiate(targetConfig.gameObject);
        gm.transform.position = new Vector3(Random.Range(-20f, 20f), 1, 40);
    }
}
