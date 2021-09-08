using UnityEngine;

public class FlowSoundVolume : MonoBehaviour {
    public float FlowRateContributor;
    public float VolumeFactor;
    AudioSource audioSource;

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
        float Flowrate = (FlotationCalculation.Controller.ConcentrateMassFlowInTPH() - FlowRateContributor) / FlowRateContributor;
        audioSource.volume = Flowrate + VolumeFactor;
    }
}

