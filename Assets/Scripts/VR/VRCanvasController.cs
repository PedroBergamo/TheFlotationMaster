using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class VRCanvasController : MonoBehaviour
    {
        public Canvas OpeningCanvas;
        public Canvas ClosingCanvas;
        private RectTransform OpeningRT;
        private RectTransform ClosingRT;


        private void Start()
        {
            OpeningRT = OpeningCanvas.gameObject.GetComponent<RectTransform>();
            ClosingRT = ClosingCanvas.gameObject.GetComponent<RectTransform>();
        }

        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
            {
                if (hand.currentAttachedObject != gameObject)
                {
                    ButtonClicked();
                }
            }
        }

        public void ButtonClicked()
        {
            OpeningCanvas.enabled = true;
            OpeningRT.localPosition = Vector3.zero;
            ClosingCanvas.enabled = false;
            ClosingRT.localPosition = new Vector3(1000, OpeningRT.localPosition.y);
        }
    }
}


