using System.Collections;
using UnityEngine.InputSystem;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{
    /// <summary>
    ///     Use this class to mediate the controllers and their associated interactors and input actions under different
    ///     interaction states.
    /// </summary>
    [AddComponentMenu("XR/Action Based Controller Manager")]
    [DefaultExecutionOrder(k_UpdateOrder)]
    public class ActionBasedControllerManager : MonoBehaviour
    {
        /// <summary>
        ///     Order when instances of type <see cref="ActionBasedControllerManager" /> are updated.
        /// </summary>
        /// <remarks>
        ///     Executes before controller components to ensure input processors can be attached
        ///     to input actions and/or bindings before the controller component reads the current
        ///     values of the input actions.
        /// </remarks>
        public const int k_UpdateOrder = XRInteractionUpdateOrder.k_Controllers - 1;

        [Space]
        [Header("Interactors")]
        [SerializeField]
        [Tooltip("The GameObject containing the interactor used for direct manipulation.")]
        private XRDirectInteractor m_DirectInteractor;

        [SerializeField] [Tooltip("The GameObject containing the interactor used for distant/ray manipulation.")]
        private XRRayInteractor m_RayInteractor;

        [SerializeField] [Tooltip("The GameObject containing the interactor used for teleportation.")]
        private XRRayInteractor m_TeleportInteractor;

        [Space]
        [Header("Controller Actions")]
        [SerializeField]
        [Tooltip("The reference to the action of selecting with this controller.")]
        private InputActionReference m_Select;

        [SerializeField]
        [Tooltip("The reference to the action of moving an object closer or further away with the ray interactor")]
        private InputActionReference m_AnchorTranslate;

        [SerializeField] [Tooltip("The reference to the action of rotating an object with the ray interactor")]
        private InputActionReference m_AnchorRotate;

        [SerializeField] [Tooltip("The reference to the action to start the teleport aiming mode for this controller.")]
        private InputActionReference m_TeleportModeActivate;

        [SerializeField]
        [Tooltip("The reference to the action to cancel the teleport aiming mode for this controller.")]
        private InputActionReference m_TeleportModeCancel;

        [SerializeField]
        [Tooltip("The reference to the action of continuous turning the XR Origin with this controller.")]
        private InputActionReference m_Turn;

        [SerializeField] [Tooltip("The reference to the action of snap turning the XR Origin with this controller.")]
        private InputActionReference m_SnapTurn;

        [SerializeField] [Tooltip("The reference to the action of moving the XR Origin with this controller.")]
        private InputActionReference m_Move;

        [Space]
        [Header("Locomotion Settings")]
        [SerializeField]
        [Tooltip("If true, continuous movement will be enabled. If false, teleport will enabled.")]
        private bool m_SmoothMotionEnabled;

        [SerializeField]
        [Tooltip(
            "If true, continuous turn will be enabled. If false, snap turn will be enabled. Note: If smooth motion is enabled and enable strafe is enabled on the continuous move provider, turn will be overriden in favor of strafe.")]
        private bool m_SmoothTurnEnabled;

        private bool m_DirectHover;
        private bool m_DirectSelect;
        private bool m_Teleporting;

        public bool smoothMotionEnabled
        {
            get => m_SmoothMotionEnabled;
            set
            {
                m_SmoothMotionEnabled = value;
                UpdateLocomotionActions();
            }
        }

        public bool smoothTurnEnabled
        {
            get => m_SmoothTurnEnabled;
            set
            {
                m_SmoothTurnEnabled = value;
                UpdateTurnActions();
            }
        }

        protected void Awake()
        {
            // Start the coroutine that executes code after the Update phase (during yield null).
            // This routine is started during Awake to ensure the code after
            // the first yield will execute after Update but still on the first frame.
            // If started in Start, Unity would not resume execution until the second frame.
            // See https://docs.unity3d.com/Manual/ExecutionOrder.html
            StartCoroutine(OnAfterInteractionEvents());
        }

        protected void Start()
        {
            // Ensure actions are properly setup
            UpdateLocomotionActions();
            UpdateTurnActions();
        }

        protected void OnEnable()
        {
            if (m_TeleportInteractor != null)
                m_TeleportInteractor.gameObject.SetActive(false);

            SetupInteractorEvents();
        }

        protected void OnDisable()
        {
            TeardownInteractorEvents();
        }

        // For our input mediation, we are enforcing a few rules between direct, ray, and teleportation interaction:
        // 1. If the Teleportation Ray is engaged, the Direct and Ray interactors are disabled
        // 2. If the Direct interactor is not idle (hovering or select), the ray interactor is disabled
        // 3. If the Ray interactor is selecting, all locomotion controls are disabled (teleport ray and snap controls) to prevent input collision
        private void SetupInteractorEvents()
        {
            UpdateLocomotionActions();
            UpdateTurnActions();

            if (m_DirectInteractor != null)
            {
                m_DirectInteractor.hoverEntered.AddListener(DirectHoverEntered);
                m_DirectInteractor.hoverExited.AddListener(DirectHoverExited);
                m_DirectInteractor.selectEntered.AddListener(DirectSelectEntered);
                m_DirectInteractor.selectExited.AddListener(DirectSelectExited);
            }

            if (m_RayInteractor != null)
            {
                m_RayInteractor.selectEntered.AddListener(RaySelectEntered);
                m_RayInteractor.selectExited.AddListener(RaySelectExited);
            }

            if (m_TeleportModeActivate != null && m_TeleportModeCancel != null)
            {
                var teleportModeAction = GetInputAction(m_TeleportModeActivate);
                var cancelTeleportModeAction = GetInputAction(m_TeleportModeCancel);
                teleportModeAction.performed += StartTeleport;
                teleportModeAction.canceled += CancelTeleport;
                cancelTeleportModeAction.performed += CancelTeleport;
            }
        }

        private void TeardownInteractorEvents()
        {
            if (m_DirectInteractor != null)
            {
                m_DirectInteractor.hoverEntered.RemoveListener(DirectHoverEntered);
                m_DirectInteractor.hoverExited.RemoveListener(DirectHoverExited);
                m_DirectInteractor.selectEntered.RemoveListener(DirectSelectEntered);
                m_DirectInteractor.selectExited.RemoveListener(DirectSelectExited);
            }

            if (m_RayInteractor != null)
            {
                m_RayInteractor.selectEntered.RemoveListener(RaySelectEntered);
                m_RayInteractor.selectExited.RemoveListener(RaySelectExited);
            }

            if (m_TeleportModeActivate != null && m_TeleportModeCancel != null)
            {
                var teleportModeAction = GetInputAction(m_TeleportModeActivate);
                var cancelTeleportModeAction = GetInputAction(m_TeleportModeCancel);
                teleportModeAction.performed -= StartTeleport;
                teleportModeAction.canceled -= CancelTeleport;
                cancelTeleportModeAction.performed -= CancelTeleport;
            }
        }

        private void StartTeleport(InputAction.CallbackContext obj)
        {
            m_Teleporting = true;
            if (m_TeleportInteractor != null)
                m_TeleportInteractor.gameObject.SetActive(true);
            RayInteractorUpdate();
        }

        private void CancelTeleport(InputAction.CallbackContext obj)
        {
            m_Teleporting = false;
            // Do not deactivate the teleport interactor in this callback.
            // We delay turning off the teleport interactor in this callback so that
            // the teleport interactor has a chance to complete the teleport if needed.
            // OnAfterInteractionEvents will handle deactivating its GameObject.
            RayInteractorUpdate();
        }

        private void DirectHoverEntered(HoverEnterEventArgs args)
        {
            m_DirectHover = true;
            DirectInteractorUpdate();
        }

        private void DirectHoverExited(HoverExitEventArgs args)
        {
            m_DirectHover = false;
            DirectInteractorUpdate();
        }

        private void DirectSelectEntered(SelectEnterEventArgs args)
        {
            m_DirectSelect = true;
            DirectInteractorUpdate();
        }

        private void DirectSelectExited(SelectExitEventArgs args)
        {
            m_DirectSelect = false;
            DirectInteractorUpdate();
        }

        private void DirectInteractorUpdate()
        {
            RayInteractorUpdate();
        }

        private void RayInteractorUpdate()
        {
            if (m_RayInteractor != null)
                m_RayInteractor.gameObject.SetActive(!(m_DirectHover || m_DirectSelect || m_Teleporting));
        }

        private void RaySelectEntered(SelectEnterEventArgs args)
        {
            // Disable direct selection
            if (m_DirectInteractor != null)
                m_DirectInteractor.gameObject.SetActive(false);

            // Disable locomotion and turn actions
            DisableLocomotionAndTurnActions();
        }

        private void RaySelectExited(SelectExitEventArgs args)
        {
            // Enable direct selection
            if (m_DirectInteractor != null)
                m_DirectInteractor.gameObject.SetActive(true);

            // Re-enable the locomotion and turn actions
            UpdateLocomotionActions();
            UpdateTurnActions();
        }

        private IEnumerator OnAfterInteractionEvents()
        {
            // Avoid comparison to null each frame since that operation is somewhat expensive
            if (m_TeleportInteractor == null)
                yield break;

            while (true)
            {
                // Yield so this coroutine is resumed after the teleport interactor
                // has a chance to process its select interaction event.
                yield return null;

                if (!m_Teleporting && m_TeleportInteractor.gameObject.activeSelf)
                    m_TeleportInteractor.gameObject.SetActive(false);
            }
        }

        private void UpdateLocomotionActions()
        {
            if (m_SmoothMotionEnabled)
            {
                EnableAction(m_Move);

                // Disable Teleport and Turn when Move is enabled.
                DisableAction(m_TeleportModeActivate);
                DisableAction(m_TeleportModeCancel);
                DisableAction(m_SnapTurn);
                DisableAction(m_Turn);
            }
            else
            {
                DisableAction(m_Move);

                // Enable Teleport and Turn when Move is disabled.
                EnableAction(m_TeleportModeActivate);
                EnableAction(m_TeleportModeCancel);
                UpdateTurnActions();
            }
        }

        private void UpdateTurnActions()
        {
            if (m_SmoothMotionEnabled)
            {
                DisableAction(m_Turn);
                DisableAction(m_SnapTurn);
                return;
            }

            if (m_SmoothTurnEnabled)
            {
                EnableAction(m_Turn);
                DisableAction(m_SnapTurn);
            }
            else
            {
                DisableAction(m_Turn);
                EnableAction(m_SnapTurn);
            }
        }

        private void DisableLocomotionAndTurnActions()
        {
            DisableAction(m_TeleportModeActivate);
            DisableAction(m_TeleportModeCancel);
            DisableAction(m_Move);
            DisableAction(m_SnapTurn);
            DisableAction(m_Turn);
        }

        private static void EnableAction(InputActionReference actionReference)
        {
            var action = GetInputAction(actionReference);
            if (action != null && !action.enabled)
                action.Enable();
        }

        private static void DisableAction(InputActionReference actionReference)
        {
            var action = GetInputAction(actionReference);
            if (action != null && action.enabled)
                action.Disable();
        }

        private static InputAction GetInputAction(InputActionReference actionReference)
        {
#pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
            return actionReference != null ? actionReference.action : null;
#pragma warning restore IDE0031
        }
    }
}