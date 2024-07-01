using UnityEngine;
using YG;
using Zenject;

public class CheckRecord : MonoBehaviour
{
    Wallet _wallet;
    [Inject]
    void Construct(HealthPoints hp)
    {
        hp.onDie += CheckRecordHandler;
        _wallet = hp.GetComponent<Wallet>();
    }



    private void CheckRecordHandler( )
    {
        if (!YandexGame.SDKEnabled)
            return;
        int newScope = _wallet.Coins;
        if (newScope > YandexGame.savesData.record)
        {
            YandexGame.savesData.record = newScope;
            YandexGame.NewLeaderboardScores("AmountGold", newScope);
            YandexGame.SaveProgress();
        }
    }
}
