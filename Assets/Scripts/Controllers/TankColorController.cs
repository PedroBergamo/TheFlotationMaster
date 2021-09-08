using UnityEngine;

namespace Assets.Scripts.Controllers
{

    public class TankColorController
    {
        float Value;
        float Alpha;

        public TankColorController(float Variable, float alpha) {
            Value = Variable;
            Alpha = alpha;
        }

        public Color NewColor()
        {
            float GreenFactor = (0.08f * (Value - 16) / 6);
            return new Color(0.25f, 0.15f - GreenFactor, 0.08f, Alpha);
        }
    }

}
