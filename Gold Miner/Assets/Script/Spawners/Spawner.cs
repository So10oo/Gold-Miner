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
    //float diameter;

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
        //diameter = 2 * x;
        StartSpawnX = -ScreenSize.width / 2 + x;
        EndSpawnX = ScreenSize.width / 2 - x;
        SpawnY = (Camera.main.orthographicSize + 1);
    }

    IEnumerator SpawnRandom()
    {
        while (true)
        {
            WaitForSeconds time = new(Random.Range(_settings.spawnTime.min, _settings.spawnTime.max));
            yield return time;
            var element = pool.Get(RandomSpawnPosition);
            if (element is FallElement fall)
                fall.speed = Random.Range(_settings.speed.min, _settings.speed.max);
            
        }
    }

    //IEnumerator Spawn1()
    //{
    //    var c = Mathf.FloorToInt(ScreenSize.width / diameter);
    //    var delta = (ScreenSize.width - c * diameter) / 2;
    //    var startSpawn = StartSpawnX + delta;
    //    var endSpawn = EndSpawnX - delta;

    //    while (true)
    //    {
    //        var time = new WaitForSeconds(2);
    //        yield return time;

    //        var bn = Random.Range(2, c - 2);
    //        for (int i = 0; i < c; i++)
    //        {
    //            if (i > bn + 2 || i < bn - 2) 
    //            {
    //                var fall = pool.Get(new Vector2(startSpawn + diameter * i, SpawnY));
    //                (fall as FallElement).speed = 4;
    //            }
                 
    //        }
             

    //    }
    //}

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
        Progress = StartCoroutine(SpawnRandom());
    }

    void StopSpawn()
    {
        StopCoroutine(Progress);
        pool.ReleaseAll();
    }

}
