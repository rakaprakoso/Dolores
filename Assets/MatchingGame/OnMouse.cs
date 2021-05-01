// GENERATED AUTOMATICALLY FROM 'Assets/MatchingGame/OnMouse.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @OnMouse : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @OnMouse()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""OnMouse"",
    ""maps"": [
        {
            ""name"": ""Click"",
            ""id"": ""14a561a7-d220-4f4c-8be6-9ac721ce3fd6"",
            ""actions"": [
                {
                    ""name"": ""Clicked"",
                    ""type"": ""Value"",
                    ""id"": ""134137c2-9204-431d-b160-ff8f1001047b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d42e4d8d-f7cf-4a6e-bdf4-2b13cc9689f6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c00e2afd-37a3-419a-8ce0-5521764d489e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clicked"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58bf05de-68da-49ba-b8ac-f48f3b548684"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
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
        m_Click_Position = m_Click.FindAction("Position", throwIfNotFound: true);
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
    private readonly InputAction m_Click_Position;
    public struct ClickActions
    {
        private @OnMouse m_Wrapper;
        public ClickActions(@OnMouse wrapper) { m_Wrapper = wrapper; }
        public InputAction @Clicked => m_Wrapper.m_Click_Clicked;
        public InputAction @Position => m_Wrapper.m_Click_Position;
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
                @Position.started -= m_Wrapper.m_ClickActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_ClickActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_ClickActionsCallbackInterface.OnPosition;
            }
            m_Wrapper.m_ClickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Clicked.started += instance.OnClicked;
                @Clicked.performed += instance.OnClicked;
                @Clicked.canceled += instance.OnClicked;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
            }
        }
    }
    public ClickActions @Click => new ClickActions(this);
    public interface IClickActions
    {
        void OnClicked(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
    }
}
