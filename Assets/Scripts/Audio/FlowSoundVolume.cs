using UnityEngine;

public class FlowSoundVolume : MonoBehaviour {
    public float FlowRateContributor;
    public float VolumeFactor;
    AudioSource audioSource;
    public FlotationCalculation simulation;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update ()
    {
        AdjustFlowRateVolume();
    }

    private void AdjustFlowRateVolume()
    {
        float Flowrate = ((float)simulation.Simulation.feed.MassFlowRate - FlowRateContributor) / FlowRateContributor;
        audioSource.volume = Flowrate + VolumeFactor;
    }
}