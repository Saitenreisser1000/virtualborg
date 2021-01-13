using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class PlayerMovement : FirstPersonController
    {
        private CharacterController _controller;
        private RectTransform cam;
        public float simpleSpeed = 1;
        public float simpleRotationspeed = 1;
        bool proControl;
        public float watchAngleY = 5;

        private Vector3 rotation;

        public void Start()
        {
            m_CharacterController = GetComponent<CharacterController>();
            m_Camera = Camera.main;
            m_OriginalCameraPosition = m_Camera.transform.localPosition;
            m_FovKick.Setup(m_Camera);
            m_HeadBob.Setup(m_Camera, m_StepInterval);
            m_StepCycle = 0f;
            m_NextStep = m_StepCycle / 2f;
            m_Jumping = false;
            m_AudioSource = GetComponent<AudioSource>();
            m_MouseLook.Init(transform, m_Camera.transform);

            float turn = m_MouseLook.XSensitivity;
            gameObject.SendMessage("GetMovementSpeed", m_WalkSpeed);
            gameObject.SendMessage("GetTurnSpeed", m_MouseLook.XSensitivity);

            proControl = true;
            //CrossPlatformInputManager.SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod.Touch);
            //SetToProMode();
        }

        private void Update()
        {
            if (proControl)
            {
                ProControllerUpdate();
            }
            else
            {
                SimpleControllerUpdate();
            }
        }

        private void FixedUpdate()
        {
            if (proControl)
            {
                ProControllerFixedUpdate();
            }
        }

        private void ProControllerUpdate()
        {
            RotateView();
            // the jump state needs to read here to make sure it is not missed
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
            {
                //StartCoroutine(m_JumpBob.DoBobCycle());
                //PlayLandingSound();
                m_MoveDir.y = 0f;
                m_Jumping = false;
            }
            if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
            {
                m_MoveDir.y = 0f;
            }

            m_PreviouslyGrounded = m_CharacterController.isGrounded;
        }

        private void ProControllerFixedUpdate()
        {
            float speed;
            GetInput(out speed);
            // always move along the camera forward as it is the direction that it being aimed at
            Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

            // get a normal for the surface that is being touched to move along it
            RaycastHit hitInfo;
            Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                               m_CharacterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            m_MoveDir.x = desiredMove.x * speed;
            m_MoveDir.z = desiredMove.z * speed;


            if (m_CharacterController.isGrounded)
            {
                m_MoveDir.y = -m_StickToGroundForce;

                if (m_Jump)
                {
                    m_MoveDir.y = m_JumpSpeed;
                    //PlayJumpSound();
                    m_Jump = false;
                    m_Jumping = true;
                }
            }
            else
            {
                m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
            }
            m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);

            ProgressStepCycle(speed);
            UpdateCameraPosition(speed);

            m_MouseLook.UpdateCursorLock();
        }

        private void SimpleControllerUpdate()
        {
            m_Camera.GetComponent<RectTransform>().localRotation = Quaternion.Euler(watchAngleY, 0, 0);
            this.rotation = new Vector3(0, CrossPlatformInputManager.GetAxisRaw("Horizontal") * simpleRotationspeed * 30 * Time.deltaTime, 0);

            Vector3 move = new Vector3(0, -9.81f, CrossPlatformInputManager.GetAxisRaw("Vertical") * Time.deltaTime);
            move = this.transform.TransformDirection(move);
            m_CharacterController.Move(move * simpleSpeed);
            this.transform.Rotate(this.rotation);
        }

        public void SetToTouchMode()
        {
            CrossPlatformInputManager.SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod.Touch);
            proControl = false;
        }

        public void SetToSimpleMode()
        {
            CrossPlatformInputManager.SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod.Hardware);
            proControl = false;
        }

        public void SetToProMode()
        {
            CrossPlatformInputManager.SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod.Hardware);
            proControl = true;
        }
    }
}
