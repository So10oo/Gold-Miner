using System.Collections;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [SerializeField] SpawnSettings _settings;

    Pool pool = null;
    float StartSpawnX;
    float EndSpawnX;
    float SpawnY;

    Vector2 RandomSpawnPosition => new(Random.Range(StartSpawnX, EndSpawnX), SpawnY);

    [Inject]
    void Construct(IFactoryPool factory, ProgressGame progressGame)
    {
        pool = new(_settings.prefab, factory.Create);
        progressGame.OnStartGameAction += StartSpawn;
        progressGame.OnEndGameAction += StopSpawn;
    }

    private void Awake()
    {
        var x = _settings.prefab.gameObject.GetComponent<CircleCollider2D>().radius;
        StartSpawnX = -ScreenSize.width / 2 + x;
        EndSpawnX = ScreenSize.width / 2 - x;
        SpawnY = (Camera.main.orthographicSize + 1);
        //pool = new(_settings.prefab);
    }

    IEnumerator SpawnProgress()
    {
        while (true)
        {
            WaitForSeconds time = new(Random.Range(_settings.minSpawnTime, _settings.maxSpawnTime));
            yield return time;
            var fall = pool.Get(RandomSpawnPosition);
            (fall as GameElement).speed = Random.Range(_settings.minSpeed, _settings.maxSpeed);
        }
    }

    Coroutine _progress;
    Coroutine Progress
    {
        get
        {
            return _progress;
        }
        set
        {
            if (_progress != null)
                StopCoroutine(_progress);

            _progress = value;
        }
    }

    void StartSpawn()
    {
        Progress = StartCoroutine(SpawnProgress());
    }

    void StopSpawn()
    {
        StopCoroutine(Progress);
        pool.ReleaseAll();
    }

}
