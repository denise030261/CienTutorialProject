namespace BGMu
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

public class OptionsScene : MonoBehaviour
{
    public Slider bgmVolumeSlider;

    private void Start()
    {
        bgmVolumeSlider.value = BGMManager.Instance.GetBGMVolume();
    }

    public void OnBGMVolumeChanged(float volume)
    {
        BGMManager.Instance.SetBGMVolume(volume);
    }
}


}