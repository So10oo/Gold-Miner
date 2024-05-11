using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSettings", menuName = "ScriptableObjects/SpawnSettings", order = 1)]
public class SpawnSettings : ScriptableObject
{
    [SerializeField] ElementPool _prefab;
    public ElementPool prefab => _prefab;

    public ValueRange<float> spawnTime;
    public ValueRange<float> speed;

    private void OnValidate()
    {
        spawnTime.OnValidate();
        speed.OnValidate();
    }

}

