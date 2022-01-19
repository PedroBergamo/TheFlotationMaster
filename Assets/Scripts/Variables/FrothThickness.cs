using UnityEngine;

public class FrothThickness : MonoBehaviour {
    ParticleSystem Froth;
    public float MultiplyingFactor;
    public float AddingFactor;

    public FlotationCalculation simulation;
    private void Start()
    {
        Froth = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = Froth.main;
        float FH = (float)simulation.Simulation.FrothHeight;
        main.startLifetime = ( FH * MultiplyingFactor) + AddingFactor ;
    }
}
