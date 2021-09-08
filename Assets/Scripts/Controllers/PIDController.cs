
namespace Assets.Scripts.Controllers
{
    public class PIDController
    {

        public float Kp = 0.0001f;
        public float Ki = 0.00000005f;

        private float integral;
        public float ProcessValue;
        public float SetPoint;
        public string Unit;
        public float MaxValue;
        public float MinValue;

        public float NewValue()
        {
            float error = SetPoint - ProcessValue;
            integral += error;
            ProcessValue = ProcessValue + (Kp * error + Ki * integral);
            return ProcessValue;
        }
    }
}
