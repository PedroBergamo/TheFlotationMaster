using UnityEngine;

namespace Assets.Scripts.Controllers
{

    public class FeedColorController
    {
        public float FeedVariable;

        public Color NewColor()
        {
            float BlueFactor = (0.2f * (FeedVariable - 16) / 6);
            return new Color(0.5f, 0.5f, 0.3f + BlueFactor);
        }
    }
}
