// GENERATED AUTOMATICALLY FROM 'Assets/ClickInvent.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ClickInvent : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ClickInvent()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ClickInvent"",
    ""maps"": [
        {
            ""name"": ""Click"",
            ""id"": ""3ab6e5ce-97e9-42a4-b9b8-28accfa05120"",
            ""actions"": [
                {
                    ""name"": ""Clicked"",
                    ""type"": ""Button"",
                    ""id"": ""72354ed4-a9e4-44c8-856e-c89ab68c0701"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8e6582ef-7050-4069-b87d-79b6f5beea5c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clicked"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Click
        m_Click = asset.FindActionMap("Click", throwIfNotFound: true);
        m_Click_Clicked = m_Click.FindAction("Clicked", throwIfNotFound: true);
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

    // Click
    private readonly InputActionMap m_Click;
    private IClickActions m_ClickActionsCallbackInterface;
    private readonly InputAction m_Click_Clicked;
    public struct ClickActions
    {
        private @ClickInvent m_Wrapper;
        public ClickActions(@ClickInvent wrapper) { m_Wrapper = wrapper; }
        public InputAction @Clicked => m_Wrapper.m_Click_Clicked;
        public InputActionMap Get() { return m_Wrapper.m_Click; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClickActions set) { return set.Get(); }
        public void SetCallbacks(IClickActions instance)
        {
            if (m_Wrapper.m_ClickActionsCallbackInterface != null)
            {
                @Clicked.started -= m_Wrapper.m_ClickActionsCallbackInterface.OnClicked;
                @Clicked.performed -= m_Wrapper.m_ClickActionsCallbackInterface.OnClicked;
                @Clicked.canceled -= m_Wrapper.m_ClickActionsCallbackInterface.OnClicked;
            }
            m_Wrapper.m_ClickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Clicked.started += instance.OnClicked;
                @Clicked.performed += instance.OnClicked;
                @Clicked.canceled += instance.OnClicked;
            }
        }
    }
    public ClickActions @Click => new ClickActions(this);
    public interface IClickActions
    {
        void OnClicked(InputAction.CallbackContext context);
    }
}
