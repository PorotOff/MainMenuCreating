public class MasterVolumeChangerSlider : VolumeChangerSlider
{
    protected override string AudioMixerParameter => AudioMixerExposedParameters.MasterVolume;
}