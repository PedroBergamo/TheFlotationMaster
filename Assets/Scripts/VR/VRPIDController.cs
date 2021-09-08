using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class VRPIDController : MonoBehaviour {
        public bool PIDIncrease;
        public PID pID;
        public AudioSource audio;
        private Animator animator;

        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);

        void Start()
        {
            animator = GetComponent<Animator>();
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
            audio.Play();
            animator.Play(0);
            if (PIDIncrease == true)
            {
                pID.AddValue();
            }
            else {
                pID.SubtractValue();
            }
        }
    }
}


