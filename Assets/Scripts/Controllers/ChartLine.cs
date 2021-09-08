using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class ChartLine      
    {
        public Color LineColor;
        public float Value = 0;
        public GameObject lastCircleGameObject = null;
        public GameObject CurrentCircleGameObject = null;
        private float xProgression = 1;
        public float xInterval = 10f;
        public float MaximumValue = 100;
        Vector2 dotPositionA;
        Vector2 dotPositionB;
        public float GraphHeight;

        public ChartLine(float graphHeight) {
            GraphHeight = graphHeight;
        }

        public GameObject CreateGraphPoint()
        {
            GameObject gameObject = new GameObject("Circle", typeof(Image));
            gameObject.GetComponent<Image>().color = LineColor;
            SetRectTransform(gameObject);
            lastCircleGameObject = gameObject;
            return gameObject;
        }

        private void SetRectTransform(GameObject gameObject)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = AnchoredPosition();
            rectTransform.sizeDelta = new Vector2(.6f, .1f);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
        }

        private void SetAnchorLimits(RectTransform rt) {
            rt.anchorMin = new Vector2(0, 0);
            rt.anchorMax = new Vector2(0, 0);
        }

        private Vector2 AnchoredPosition()
        {
            
            float xPosition = xInterval + xProgression;
            xProgression += 1f;
            float yPosition = (Value / MaximumValue) * GraphHeight;            
            return new Vector2(xPosition, yPosition);            
        }   
    }
}
