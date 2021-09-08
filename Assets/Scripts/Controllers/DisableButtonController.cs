using UnityEngine;

namespace Assets.Scripts.Controllers
{

    public class DisableButtonController
    {
        public PIDController variable;
        public bool DontCheckForMax;
        public bool DontCheckForMin;

        public bool IsOutOfLimits()
        {
            if (variable.SetPoint >= variable.MaxValue)
            {
                return DontCheckForMax;
            }
            if (variable.SetPoint <= variable.MinValue)
            {
                return DontCheckForMin;
            }
            return true;
        }
    }
}
