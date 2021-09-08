using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem

{
    [RequireComponent(typeof(Interactable))]
    public class ManholeInteraction : MonoBehaviour {

        private Animator anim;

        bool manholeOpen;

        private float attachTime;

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
                    if (manholeOpen == false)
                    {
                        anim.Play("Manhole_open");
                        manholeOpen = true;
                    }
                    else
                    {
                        anim.Play("Manhole_close");
                        manholeOpen = false;
                    }
                }


            }

        }


        // Use this for initialization
        void Start()
        {
            GameObject DripTrayObj;
            DripTrayObj = GameObject.Find("OU600956055:2");
            anim = DripTrayObj.GetComponent<Animator>();
            manholeOpen = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("4"))
            {
                if (manholeOpen == false)
                {
                    anim.Play("Manhole_open");
                    manholeOpen = true;
                }
                else
                {
                    anim.Play("Manhole_close");
                    manholeOpen = false;
                }
            }
        }

    }

}