using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class DripTray3Interaction : MonoBehaviour
    {

        private Animator anim;

        bool pulledOut;

        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);

        //-------------------------------------------------


        //-------------------------------------------------
        // Called every Update() while a Hand is hovering over this object
        //-------------------------------------------------
        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
            {
                if (hand.currentAttachedObject != gameObject)
                {

                    //textMesh.text = "Interaction and key pressed";
                    if (pulledOut == false)
                    {
                        anim.Play("DripTray3_pull");
                        pulledOut = true;
                    }
                    else
                    {
                        anim.Play("DripTray3_push");
                        pulledOut = false;
                    }
                }


            }

        }


        // Use this for initialization
        void Start()
        {
            GameObject DripTrayObj;
            DripTrayObj = GameObject.Find("OU601082461:1 2");
            anim = DripTrayObj.GetComponent<Animator>();
            pulledOut = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("3"))
            {
                if (pulledOut == false)
                {
                    anim.Play("DripTray3_pull");
                    pulledOut = true;
                }
                else
                {
                    anim.Play("DripTray3_push");
                    pulledOut = false;
                }
            }
        }
    }
}