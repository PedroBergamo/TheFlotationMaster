using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class OnButtonInteraction : MonoBehaviour {


        private GameObject Water;
        private GameObject PushButtonLight;
        //private GameObject PID;
        //private TextMesh textMesh;
        bool waterOn;
        //bool PidOn;
        private Animator anim;

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
                    if (waterOn == true)
                    {
                        //textMesh.text = "Off";
                        Water.SetActive(false);
                        waterOn = false;
                        anim.Play("ButtonLight");
                        PushButtonLight.SetActive(false);
                    }

                    else
                    {
                        //textMesh.text = "On";
                        Water.SetActive(true);
                        waterOn = true;
                        anim.Play("ButtonLight_on");
                        PushButtonLight.SetActive(true);
                    }
                   
                }


            }

        }

        private void Awake()
        {
         
        }
        // Use this for initialization
        void Start()
        {
            Water = GameObject.Find("Water");
            PushButtonLight = GameObject.Find("PushButtonLight");
            //PID = GameObject.Find("PID");

            Water.SetActive(false);
            PushButtonLight.SetActive(false);
            //PID.SetActive(false);

            //textMesh = GetComponentInChildren<TextMesh>();
            //textMesh.text = "Off";
            waterOn = false;
            //PidOn = false;

            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("5"))
            {
                if (waterOn == true)
                {
                    //textMesh.text = "Off";
                    Water.SetActive(false);
                    waterOn = false;
                    anim.Play("ButtonLight");
                    PushButtonLight.SetActive(false);
                }

                else
                {
                    //textMesh.text = "On";
                    Water.SetActive(true);
                    waterOn = true;
                    anim.Play("ButtonLight_on");
                    PushButtonLight.SetActive(true);
                }
            }

            //if (Input.GetKeyDown("0"))
            //{
            //    if (PidOn == true)
            //    {
                  
            //        PID.SetActive(false);
            //        PidOn = false;
                 
            //    }

            //    else
            //    {
                    
            //        PID.SetActive(true);
            //        PidOn = true;
                  
            //    }
            //}
        }

    }
}

