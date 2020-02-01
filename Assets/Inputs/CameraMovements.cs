// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/CameraMovements.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CameraMovements : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CameraMovements()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraMovements"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""e5e67b38-4d0e-4a0e-a6f2-7e4bbe40a18a"",
            ""actions"": [
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""8bea9be1-5b79-4de6-8abb-917cf3961061"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""99bec640-460c-4dd1-8544-08eb46e15cdf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""909411d8-3a34-4258-9b22-c880d3a8b98e"",
                    ""path"": ""<Touchscreen>/touch0/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ada9487c-266e-40b0-9815-f0618b8bc8bc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7051b88-54ed-481e-9aa2-b182a9485788"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Scroll = m_Movement.FindAction("Scroll", throwIfNotFound: true);
        m_Movement_Newaction = m_Movement.FindAction("New action", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Scroll;
    private readonly InputAction m_Movement_Newaction;
    public struct MovementActions
    {
        private @CameraMovements m_Wrapper;
        public MovementActions(@CameraMovements wrapper) { m_Wrapper = wrapper; }
        public InputAction @Scroll => m_Wrapper.m_Movement_Scroll;
        public InputAction @Newaction => m_Wrapper.m_Movement_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Scroll.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnScroll;
                @Newaction.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnScroll(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
    }
}
