using YG;


public class SoundSwitch : AudioSwitch
{
    public override bool Mute
    {
        get
        {
            return YandexGame.savesData.isMuteSound;
        }
        set
        {
            YandexGame.savesData.isMuteSound = value;
            _checkBoxView.ViewData(value);
            _audioSource.mute = value;
        }
    }

    protected override void Load()
    {
        Mute = YandexGame.savesData.isMuteSound;
    }
}
