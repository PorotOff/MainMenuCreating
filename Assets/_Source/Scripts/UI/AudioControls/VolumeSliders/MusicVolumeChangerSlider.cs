public class MusicVolumeChangerSlider : VolumeChangerSlider
{
    protected override string AudioMixerParameter => AudioMixerExposedParameters.MusicVolume;
}