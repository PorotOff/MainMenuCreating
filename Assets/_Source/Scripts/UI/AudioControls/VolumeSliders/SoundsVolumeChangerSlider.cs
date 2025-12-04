public class SoundsVolumeChangerSlider : VolumeChangerSlider
{
    protected override string AudioMixerParameter => AudioMixerExposedParameters.SoundsVolume;
}