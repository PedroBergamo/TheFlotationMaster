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
        main.startLifetime = (FlotationCalculation.Controller.FrothThickness * MultiplyingFactor) + AddingFactor;
    }
}
