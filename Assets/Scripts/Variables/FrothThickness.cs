using UnityEngine;

public class FrothThickness : MonoBehaviour {
    ParticleSystem Froth;
    public float MultiplyingFactor;
    public float AddingFactor;
    private void Start()
    {
        Froth = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = Froth.main;
        float FH = (float)FlotationCalculation.Simulation.FrothHeight;
        main.startLifetime = ( FH * MultiplyingFactor) + AddingFactor ;
    }
}
