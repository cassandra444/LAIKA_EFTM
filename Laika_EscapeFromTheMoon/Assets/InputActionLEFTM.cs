//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputActionLEFTM.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActionLEFTM : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActionLEFTM()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActionLEFTM"",
    ""maps"": [
        {
            ""name"": ""LaikaMovements"",
            ""id"": ""8d13e3ed-db4e-4ccc-ac09-108dd8dc77e3"",
            ""actions"": [
                {
                    ""name"": ""Mouvements"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a447668a-41c3-44c1-903b-a82880f58174"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attaque"",
                    ""type"": ""Button"",
                    ""id"": ""8507ef0c-625e-4b46-9615-3305b0758b41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8ab66a39-7ab9-43cc-97c9-17944bd9c0fd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""24003216-c94c-4196-aec1-955a12bd38b6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""3327ff72-e615-459d-b6cc-97331ff0e2fa"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvements"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8f9969b2-16e5-49c3-98e9-0504e8c39450"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7bede225-66b9-433d-8b84-4cf41e2605fd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c95de0b9-48d0-45e9-9f9b-2eb5d7739de1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f8db735a-3aaa-44b3-91da-77be32d3f409"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7eb1642e-1b51-4f7a-9d0b-5ea9c4b73d05"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attaque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1d1d56d-5d71-47cf-ae36-76e67441731f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attaque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca626e11-146b-4705-a9ed-1d379f1ef546"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ff1498db-d598-4248-812b-eb3013ff1fcf"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e34b6121-5b34-4773-8258-005da82fcc96"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""86606b24-6cd6-4d51-baa4-28b595ea9c70"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6265bc72-cb99-4a0e-8d74-12a722f16e49"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""423922b2-2a6e-4f61-ab15-72817308a8a5"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""LaikaActions"",
            ""id"": ""7d7469b4-b2a3-4f42-b5f6-283bf7dddec9"",
            ""actions"": [
                {
                    ""name"": ""SprintButton"",
                    ""type"": ""Button"",
                    ""id"": ""c35a8c8e-4997-4df5-9da8-1c73d728836b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""216d1612-68f8-4f44-aae5-65f27917db96"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2cd5e1c3-eb3b-4f3f-a537-f12594e4e46a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // LaikaMovements
        m_LaikaMovements = asset.FindActionMap("LaikaMovements", throwIfNotFound: true);
        m_LaikaMovements_Mouvements = m_LaikaMovements.FindAction("Mouvements", throwIfNotFound: true);
        m_LaikaMovements_Attaque = m_LaikaMovements.FindAction("Attaque", throwIfNotFound: true);
        m_LaikaMovements_Camera = m_LaikaMovements.FindAction("Camera", throwIfNotFound: true);
        // LaikaActions
        m_LaikaActions = asset.FindActionMap("LaikaActions", throwIfNotFound: true);
        m_LaikaActions_SprintButton = m_LaikaActions.FindAction("SprintButton", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // LaikaMovements
    private readonly InputActionMap m_LaikaMovements;
    private ILaikaMovementsActions m_LaikaMovementsActionsCallbackInterface;
    private readonly InputAction m_LaikaMovements_Mouvements;
    private readonly InputAction m_LaikaMovements_Attaque;
    private readonly InputAction m_LaikaMovements_Camera;
    public struct LaikaMovementsActions
    {
        private @InputActionLEFTM m_Wrapper;
        public LaikaMovementsActions(@InputActionLEFTM wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouvements => m_Wrapper.m_LaikaMovements_Mouvements;
        public InputAction @Attaque => m_Wrapper.m_LaikaMovements_Attaque;
        public InputAction @Camera => m_Wrapper.m_LaikaMovements_Camera;
        public InputActionMap Get() { return m_Wrapper.m_LaikaMovements; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LaikaMovementsActions set) { return set.Get(); }
        public void SetCallbacks(ILaikaMovementsActions instance)
        {
            if (m_Wrapper.m_LaikaMovementsActionsCallbackInterface != null)
            {
                @Mouvements.started -= m_Wrapper.m_LaikaMovementsActionsCallbackInterface.OnMouvements;
                @Mouvements.performed -= m_Wrapper.m_LaikaMovementsActionsCallbackInterface.OnMouvements;
                @Mouvements.canceled -= m_Wrapper.m_LaikaMovementsActionsCallbackInterface.OnMouvements;
                @Attaque.started -= m_Wrapper.m_LaikaMovementsActionsCallbackInterface.OnAttaque;
                @Attaque.performed -= m_Wrapper.m_LaikaMovementsActionsCallbackInterface.OnAttaque;
                @Attaque.canceled -= m_Wrapper.m_LaikaMovementsActionsCallbackInterface.OnAttaque;
                @Camera.started -= m_Wrapper.m_LaikaMovementsActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_LaikaMovementsActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_LaikaMovementsActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_LaikaMovementsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouvements.started += instance.OnMouvements;
                @Mouvements.performed += instance.OnMouvements;
                @Mouvements.canceled += instance.OnMouvements;
                @Attaque.started += instance.OnAttaque;
                @Attaque.performed += instance.OnAttaque;
                @Attaque.canceled += instance.OnAttaque;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public LaikaMovementsActions @LaikaMovements => new LaikaMovementsActions(this);

    // LaikaActions
    private readonly InputActionMap m_LaikaActions;
    private ILaikaActionsActions m_LaikaActionsActionsCallbackInterface;
    private readonly InputAction m_LaikaActions_SprintButton;
    public struct LaikaActionsActions
    {
        private @InputActionLEFTM m_Wrapper;
        public LaikaActionsActions(@InputActionLEFTM wrapper) { m_Wrapper = wrapper; }
        public InputAction @SprintButton => m_Wrapper.m_LaikaActions_SprintButton;
        public InputActionMap Get() { return m_Wrapper.m_LaikaActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LaikaActionsActions set) { return set.Get(); }
        public void SetCallbacks(ILaikaActionsActions instance)
        {
            if (m_Wrapper.m_LaikaActionsActionsCallbackInterface != null)
            {
                @SprintButton.started -= m_Wrapper.m_LaikaActionsActionsCallbackInterface.OnSprintButton;
                @SprintButton.performed -= m_Wrapper.m_LaikaActionsActionsCallbackInterface.OnSprintButton;
                @SprintButton.canceled -= m_Wrapper.m_LaikaActionsActionsCallbackInterface.OnSprintButton;
            }
            m_Wrapper.m_LaikaActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SprintButton.started += instance.OnSprintButton;
                @SprintButton.performed += instance.OnSprintButton;
                @SprintButton.canceled += instance.OnSprintButton;
            }
        }
    }
    public LaikaActionsActions @LaikaActions => new LaikaActionsActions(this);
    public interface ILaikaMovementsActions
    {
        void OnMouvements(InputAction.CallbackContext context);
        void OnAttaque(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface ILaikaActionsActions
    {
        void OnSprintButton(InputAction.CallbackContext context);
    }
}
