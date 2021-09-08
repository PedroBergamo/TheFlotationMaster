using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class InstructionsButton : MonoBehaviour
    {
        public InstructionsManager Instructions;
        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);
        public void ButtonClicked()
        {
            InstructionsManager.GivenAnswer = gameObject.transform.GetSiblingIndex();
            Instructions.CheckIfRightAnswer();
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

        void Start()
        {
            var button = transform.GetComponent<Button>();
            button.onClick.AddListener(delegate () { ButtonClicked(); });
        }
    }
}