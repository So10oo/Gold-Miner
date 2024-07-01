using System;
using YG;


public class MusicSwitch : AudioSwitch
{
    public override bool Mute 
    { 
        get
        {
            return YandexGame.savesData.isMuteMusic;
        }
        set
        {
            YandexGame.savesData.isMuteMusic = value;
            _checkBoxView.ViewData(value);
            _audioSource.mute = value;
        }
    }

    protected override void Load()
    {
        Mute = YandexGame.savesData.isMuteMusic;
    }
}

