using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] SpawnSettings _settings;

    Pool pool;
    float StartSpawnX;
    float EndSpawnX;
    float SpawnY;

    Vector2 RandomSpawnPosition => new Vector2(Random.Range(StartSpawnX, EndSpawnX), SpawnY);

    private void Awake()
    {
        var x = _settings.prefab.gameObject.GetComponent<CircleCollider2D>().radius;
        StartSpawnX = -ScreenSize.width / 2 + x;
        EndSpawnX = ScreenSize.width / 2 - x;
        SpawnY = (Camera.main.orthographicSize + 1);
        pool = new(_settings.prefab);
    }

    IEnumerator SpawnProgress()
    {
        while (true)
        {
            WaitForSeconds time = new WaitForSeconds(Random.Range(_settings.minSpawnTime, _settings.maxSpawnTime));
            yield return time;
            var fall = pool.Instantiate(RandomSpawnPosition);
            (fall as GameElement).speed = Random.Range(_settings.minSpeed, _settings.maxSpeed);
        }
    }

    Coroutine progress;
    public void StartSpawn()
    {
        progress = StartCoroutine(SpawnProgress());
    }

    public void StopSpawn()
    {
        StopCoroutine(progress);
        pool.DestroyAll();
    }

}
