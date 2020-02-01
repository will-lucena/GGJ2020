// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
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
        },
        {
            ""name"": ""Pinch"",
            ""id"": ""644f9d3f-7e40-4442-ae85-ae3353926b34"",
            ""actions"": [
                {
                    ""name"": ""Touch1"",
                    ""type"": ""Value"",
                    ""id"": ""d8cd1ceb-7d25-47ff-ad70-92bdc7998ef8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Touch2"",
                    ""type"": ""Value"",
                    ""id"": ""6850d5ce-c2b6-4555-8bb3-75688c8da8bd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tap2"",
                    ""type"": ""Button"",
                    ""id"": ""1739bf50-318a-4375-9cb2-bf8b26bd9507"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""040769d3-97e4-42c8-ac62-587b19c6cea4"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a74ea0e2-441d-4163-8f01-9101b2e1faa5"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4da3a88-11e2-412e-b161-94f5b8e0dd0e"",
                    ""path"": ""<Touchscreen>/touch1/startPosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Click"",
            ""id"": ""cf098297-83e9-4a01-9f08-0e3f24694d9c"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""95267f5b-f284-42f3-9f23-99ee18b769d4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""456127dd-a7d2-4331-a988-204eeb2247c7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd7c3563-1320-49e4-beb0-db6e68f9d682"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MouseMovement"",
            ""id"": ""4f270a2d-7ce5-425c-aad9-d971c931c673"",
            ""actions"": [
                {
                    ""name"": ""MouseScrollDelta"",
                    ""type"": ""Value"",
                    ""id"": ""248d857e-923b-4078-b631-b4f0fb43c3f4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePress"",
                    ""type"": ""Button"",
                    ""id"": ""bdcde478-f452-45be-821b-9304ab213faf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1c2c4f81-eb25-48a5-9b82-4e630a03e19d"",
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
                    ""id"": ""6bcd32d0-b42e-444b-b3e3-7c3f1ac1228c"",
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
        m_Movement_Scroll = m_Movement.FindAction("Scroll", throwIfNotFound: true);
        m_Movement_Newaction = m_Movement.FindAction("New action", throwIfNotFound: true);
        // Pinch
        m_Pinch = asset.FindActionMap("Pinch", throwIfNotFound: true);
        m_Pinch_Touch1 = m_Pinch.FindAction("Touch1", throwIfNotFound: true);
        m_Pinch_Touch2 = m_Pinch.FindAction("Touch2", throwIfNotFound: true);
        m_Pinch_Tap2 = m_Pinch.FindAction("Tap2", throwIfNotFound: true);
        // Click
        m_Click = asset.FindActionMap("Click", throwIfNotFound: true);
        m_Click_Newaction = m_Click.FindAction("New action", throwIfNotFound: true);
        // MouseMovement
        m_MouseMovement = asset.FindActionMap("MouseMovement", throwIfNotFound: true);
        m_MouseMovement_MouseScrollDelta = m_MouseMovement.FindAction("MouseScrollDelta", throwIfNotFound: true);
        m_MouseMovement_MousePress = m_MouseMovement.FindAction("MousePress", throwIfNotFound: true);
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
        private @Inputs m_Wrapper;
        public MovementActions(@Inputs wrapper) { m_Wrapper = wrapper; }
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

    // Pinch
    private readonly InputActionMap m_Pinch;
    private IPinchActions m_PinchActionsCallbackInterface;
    private readonly InputAction m_Pinch_Touch1;
    private readonly InputAction m_Pinch_Touch2;
    private readonly InputAction m_Pinch_Tap2;
    public struct PinchActions
    {
        private @Inputs m_Wrapper;
        public PinchActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch1 => m_Wrapper.m_Pinch_Touch1;
        public InputAction @Touch2 => m_Wrapper.m_Pinch_Touch2;
        public InputAction @Tap2 => m_Wrapper.m_Pinch_Tap2;
        public InputActionMap Get() { return m_Wrapper.m_Pinch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PinchActions set) { return set.Get(); }
        public void SetCallbacks(IPinchActions instance)
        {
            if (m_Wrapper.m_PinchActionsCallbackInterface != null)
            {
                @Touch1.started -= m_Wrapper.m_PinchActionsCallbackInterface.OnTouch1;
                @Touch1.performed -= m_Wrapper.m_PinchActionsCallbackInterface.OnTouch1;
                @Touch1.canceled -= m_Wrapper.m_PinchActionsCallbackInterface.OnTouch1;
                @Touch2.started -= m_Wrapper.m_PinchActionsCallbackInterface.OnTouch2;
                @Touch2.performed -= m_Wrapper.m_PinchActionsCallbackInterface.OnTouch2;
                @Touch2.canceled -= m_Wrapper.m_PinchActionsCallbackInterface.OnTouch2;
                @Tap2.started -= m_Wrapper.m_PinchActionsCallbackInterface.OnTap2;
                @Tap2.performed -= m_Wrapper.m_PinchActionsCallbackInterface.OnTap2;
                @Tap2.canceled -= m_Wrapper.m_PinchActionsCallbackInterface.OnTap2;
            }
            m_Wrapper.m_PinchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch1.started += instance.OnTouch1;
                @Touch1.performed += instance.OnTouch1;
                @Touch1.canceled += instance.OnTouch1;
                @Touch2.started += instance.OnTouch2;
                @Touch2.performed += instance.OnTouch2;
                @Touch2.canceled += instance.OnTouch2;
                @Tap2.started += instance.OnTap2;
                @Tap2.performed += instance.OnTap2;
                @Tap2.canceled += instance.OnTap2;
            }
        }
    }
    public PinchActions @Pinch => new PinchActions(this);

    // Click
    private readonly InputActionMap m_Click;
    private IClickActions m_ClickActionsCallbackInterface;
    private readonly InputAction m_Click_Newaction;
    public struct ClickActions
    {
        private @Inputs m_Wrapper;
        public ClickActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Click_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Click; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClickActions set) { return set.Get(); }
        public void SetCallbacks(IClickActions instance)
        {
            if (m_Wrapper.m_ClickActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_ClickActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_ClickActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_ClickActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_ClickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public ClickActions @Click => new ClickActions(this);

    // MouseMovement
    private readonly InputActionMap m_MouseMovement;
    private IMouseMovementActions m_MouseMovementActionsCallbackInterface;
    private readonly InputAction m_MouseMovement_MouseScrollDelta;
    private readonly InputAction m_MouseMovement_MousePress;
    public struct MouseMovementActions
    {
        private @Inputs m_Wrapper;
        public MouseMovementActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseScrollDelta => m_Wrapper.m_MouseMovement_MouseScrollDelta;
        public InputAction @MousePress => m_Wrapper.m_MouseMovement_MousePress;
        public InputActionMap Get() { return m_Wrapper.m_MouseMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseMovementActions set) { return set.Get(); }
        public void SetCallbacks(IMouseMovementActions instance)
        {
            if (m_Wrapper.m_MouseMovementActionsCallbackInterface != null)
            {
                @MouseScrollDelta.started -= m_Wrapper.m_MouseMovementActionsCallbackInterface.OnMouseScrollDelta;
                @MouseScrollDelta.performed -= m_Wrapper.m_MouseMovementActionsCallbackInterface.OnMouseScrollDelta;
                @MouseScrollDelta.canceled -= m_Wrapper.m_MouseMovementActionsCallbackInterface.OnMouseScrollDelta;
                @MousePress.started -= m_Wrapper.m_MouseMovementActionsCallbackInterface.OnMousePress;
                @MousePress.performed -= m_Wrapper.m_MouseMovementActionsCallbackInterface.OnMousePress;
                @MousePress.canceled -= m_Wrapper.m_MouseMovementActionsCallbackInterface.OnMousePress;
            }
            m_Wrapper.m_MouseMovementActionsCallbackInterface = instance;
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
    public MouseMovementActions @MouseMovement => new MouseMovementActions(this);
    public interface IMovementActions
    {
        void OnScroll(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IPinchActions
    {
        void OnTouch1(InputAction.CallbackContext context);
        void OnTouch2(InputAction.CallbackContext context);
        void OnTap2(InputAction.CallbackContext context);
    }
    public interface IClickActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IMouseMovementActions
    {
        void OnMouseScrollDelta(InputAction.CallbackContext context);
        void OnMousePress(InputAction.CallbackContext context);
    }
}
