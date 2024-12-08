//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.10.0
//     from Assets/02-TankController/Input/02Tank.inputactions
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

public partial class @AM_02Tank: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @AM_02Tank()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""02Tank"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""1cf59470-13fa-4505-bb4b-e8b0168129ac"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""33f16d51-dff8-436a-a28d-69ea024d2efe"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Steer"",
                    ""type"": ""Button"",
                    ""id"": ""15d60fdb-2abe-47e0-8bfd-a4b142cce6fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""04d4d109-e500-44ed-8e0b-4704fbe16769"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""9035bdff-5bfa-4887-b652-5b60c643bfe8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""ec2cf550-148d-4e13-bf68-c5aedb3ab82d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""197e40c2-1c77-440a-8363-c32c96eec4ff"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de9b7b69-49c6-4cc6-a3d1-65d4055a4c81"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Invert,Clamp(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc7d9c93-12e0-4eb3-998c-ed77ad195f6e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""05b8df4a-7284-4e3a-a8dc-644c211cef01"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""072d09fa-9dec-40a4-ac83-ed5622e8f6dd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c687cf91-dafa-4bba-aef5-eecfdb61ac2d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ac216cd3-fc97-4880-9b2f-05a44bd326c8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0746e14a-25c5-4d6c-9f83-862c16c93d31"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""225a4aba-e9bd-4dd9-a389-14a1186c2965"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_Accelerate = m_Default.FindAction("Accelerate", throwIfNotFound: true);
        m_Default_Steer = m_Default.FindAction("Steer", throwIfNotFound: true);
        m_Default_Fire = m_Default.FindAction("Fire", throwIfNotFound: true);
        m_Default_Aim = m_Default.FindAction("Aim", throwIfNotFound: true);
        m_Default_Zoom = m_Default.FindAction("Zoom", throwIfNotFound: true);
    }

    ~@AM_02Tank()
    {
        UnityEngine.Debug.Assert(!m_Default.enabled, "This will cause a leak and performance issues, AM_02Tank.Default.Disable() has not been called.");
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

    // Default
    private readonly InputActionMap m_Default;
    private List<IDefaultActions> m_DefaultActionsCallbackInterfaces = new List<IDefaultActions>();
    private readonly InputAction m_Default_Accelerate;
    private readonly InputAction m_Default_Steer;
    private readonly InputAction m_Default_Fire;
    private readonly InputAction m_Default_Aim;
    private readonly InputAction m_Default_Zoom;
    public struct DefaultActions
    {
        private @AM_02Tank m_Wrapper;
        public DefaultActions(@AM_02Tank wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Default_Accelerate;
        public InputAction @Steer => m_Wrapper.m_Default_Steer;
        public InputAction @Fire => m_Wrapper.m_Default_Fire;
        public InputAction @Aim => m_Wrapper.m_Default_Aim;
        public InputAction @Zoom => m_Wrapper.m_Default_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void AddCallbacks(IDefaultActions instance)
        {
            if (instance == null || m_Wrapper.m_DefaultActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DefaultActionsCallbackInterfaces.Add(instance);
            @Accelerate.started += instance.OnAccelerate;
            @Accelerate.performed += instance.OnAccelerate;
            @Accelerate.canceled += instance.OnAccelerate;
            @Steer.started += instance.OnSteer;
            @Steer.performed += instance.OnSteer;
            @Steer.canceled += instance.OnSteer;
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
            @Aim.started += instance.OnAim;
            @Aim.performed += instance.OnAim;
            @Aim.canceled += instance.OnAim;
            @Zoom.started += instance.OnZoom;
            @Zoom.performed += instance.OnZoom;
            @Zoom.canceled += instance.OnZoom;
        }

        private void UnregisterCallbacks(IDefaultActions instance)
        {
            @Accelerate.started -= instance.OnAccelerate;
            @Accelerate.performed -= instance.OnAccelerate;
            @Accelerate.canceled -= instance.OnAccelerate;
            @Steer.started -= instance.OnSteer;
            @Steer.performed -= instance.OnSteer;
            @Steer.canceled -= instance.OnSteer;
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
            @Aim.started -= instance.OnAim;
            @Aim.performed -= instance.OnAim;
            @Aim.canceled -= instance.OnAim;
            @Zoom.started -= instance.OnZoom;
            @Zoom.performed -= instance.OnZoom;
            @Zoom.canceled -= instance.OnZoom;
        }

        public void RemoveCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDefaultActions instance)
        {
            foreach (var item in m_Wrapper.m_DefaultActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DefaultActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnSteer(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
}
