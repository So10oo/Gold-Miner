using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSettings", menuName = "ScriptableObjects/SpawnSettings", order = 1)]
public class SpawnSettings : ScriptableObject
{
    [SerializeField] ElementPool _prefab;

    [SerializeField][Range(0.1f, 1f)] float _minSpawnTime;

    [SerializeField][Range(1.1f, 3f)] float _maxSpawnTime;

    [SerializeField][Range(1f, 5f)] float _minSpeed;

    [SerializeField][Range(5.1f, 10f)] float _maxSpeed;

    public ElementPool prefab => _prefab;
    public float minSpawnTime => _minSpawnTime;
    public float maxSpawnTime => _maxSpawnTime;
    public float minSpeed => _minSpeed;
    public float maxSpeed => _maxSpeed;

}

