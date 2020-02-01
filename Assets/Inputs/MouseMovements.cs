// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/MouseMovements.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MouseMovements : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MouseMovements()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MouseMovements"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""fe3f0ce8-261a-4bc8-824a-d738ad9ea603"",
            ""actions"": [
                {
                    ""name"": ""MouseScrollDelta"",
                    ""type"": ""Value"",
                    ""id"": ""c7a73927-8ed5-4b52-9a83-8d262a3eb6a8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePress"",
                    ""type"": ""Button"",
                    ""id"": ""7f893cb4-a5df-4789-96e2-c5262bffb5ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e7f1f53-e210-49f8-acc0-d1deeb4585bb"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseScrollDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd184947-b5df-4357-9f63-26bafdba214b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePress"",
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
        m_Movement_MouseScrollDelta = m_Movement.FindAction("MouseScrollDelta", throwIfNotFound: true);
        m_Movement_MousePress = m_Movement.FindAction("MousePress", throwIfNotFound: true);
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
    private readonly InputAction m_Movement_MouseScrollDelta;
    private readonly InputAction m_Movement_MousePress;
    public struct MovementActions
    {
        private @MouseMovements m_Wrapper;
        public MovementActions(@MouseMovements wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseScrollDelta => m_Wrapper.m_Movement_MouseScrollDelta;
        public InputAction @MousePress => m_Wrapper.m_Movement_MousePress;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @MouseScrollDelta.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseScrollDelta;
                @MouseScrollDelta.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseScrollDelta;
                @MouseScrollDelta.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseScrollDelta;
                @MousePress.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMousePress;
                @MousePress.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMousePress;
                @MousePress.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMousePress;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseScrollDelta.started += instance.OnMouseScrollDelta;
                @MouseScrollDelta.performed += instance.OnMouseScrollDelta;
                @MouseScrollDelta.canceled += instance.OnMouseScrollDelta;
                @MousePress.started += instance.OnMousePress;
                @MousePress.performed += instance.OnMousePress;
                @MousePress.canceled += instance.OnMousePress;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnMouseScrollDelta(InputAction.CallbackContext context);
        void OnMousePress(InputAction.CallbackContext context);
    }
}
