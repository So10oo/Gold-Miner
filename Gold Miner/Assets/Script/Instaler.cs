using UnityEngine;
using Zenject;

public class Instaler : MonoInstaller
{
    [Header("Audio")]
    [SerializeField] SoundPlayer _soundPlayer;

    [Header("ProgressGame")]
    [SerializeField] ProgressGame _progressGame;


    [Header("Wallet")]
    [SerializeField] HealthPoints _hp;
    

    public override void InstallBindings()
    {
        Container.Bind<IFactoryPool>().To<FactoryPool>().FromInstance(new FactoryPool(Container)).AsSingle();

        Container.Bind<ProgressGame>().FromInstance(_progressGame).AsSingle();
        Container.Bind<HealthPoints>().FromInstance(_hp).AsSingle();
        Container.Bind<SoundPlayer>().FromInstance(_soundPlayer).AsSingle();

        //Character hero = Container.InstantiatePrefabForComponent<Character>(HeroPrefab, StartPoint.position, Quaternion.identity, null);
        //Container.Bind<Character>().FromInstance(hero).AsSingle();
        //Container.Bind<StateMachineEvents<Character>>().FromInstance(new StateMachineEvents<Character>()).AsSingle();
    }
}


 

 