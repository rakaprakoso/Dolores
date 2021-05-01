// GENERATED AUTOMATICALLY FROM 'Assets/JigsawMinigame/DragDrop.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DragDrop : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DragDrop()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DragDrop"",
    ""maps"": [
        {
            ""name"": ""Drag"",
            ""id"": ""452c7b0e-9f9b-48f3-aa0a-6f611b18d094"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Value"",
                    ""id"": ""8c83b3de-2d8d-4461-9580-26773a82d4be"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""2d2c7455-ef6c-4114-a03c-74ff89e0095b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Posistion"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8a4c77e4-3359-4df3-8ea2-892824172529"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b8da149-5391-403d-b7b5-4c593ae29d1f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47d11a34-ba74-4f1c-879f-d5d8e4590c43"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Posistion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4ee0408-3e98-4d18-a95d-f3130832370c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Drag
        m_Drag = asset.FindActionMap("Drag", throwIfNotFound: true);
        m_Drag_Click = m_Drag.FindAction("Click", throwIfNotFound: true);
        m_Drag_RightClick = m_Drag.FindAction("RightClick", throwIfNotFound: true);
        m_Drag_Posistion = m_Drag.FindAction("Posistion", throwIfNotFound: true);
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

    // Drag
    private readonly InputActionMap m_Drag;
    private IDragActions m_DragActionsCallbackInterface;
    private readonly InputAction m_Drag_Click;
    private readonly InputAction m_Drag_RightClick;
    private readonly InputAction m_Drag_Posistion;
    public struct DragActions
    {
        private @DragDrop m_Wrapper;
        public DragActions(@DragDrop wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Drag_Click;
        public InputAction @RightClick => m_Wrapper.m_Drag_RightClick;
        public InputAction @Posistion => m_Wrapper.m_Drag_Posistion;
        public InputActionMap Get() { return m_Wrapper.m_Drag; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DragActions set) { return set.Get(); }
        public void SetCallbacks(IDragActions instance)
        {
            if (m_Wrapper.m_DragActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_DragActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_DragActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_DragActionsCallbackInterface.OnClick;
                @RightClick.started -= m_Wrapper.m_DragActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_DragActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_DragActionsCallbackInterface.OnRightClick;
                @Posistion.started -= m_Wrapper.m_DragActionsCallbackInterface.OnPosistion;
                @Posistion.performed -= m_Wrapper.m_DragActionsCallbackInterface.OnPosistion;
                @Posistion.canceled -= m_Wrapper.m_DragActionsCallbackInterface.OnPosistion;
            }
            m_Wrapper.m_DragActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @Posistion.started += instance.OnPosistion;
                @Posistion.performed += instance.OnPosistion;
                @Posistion.canceled += instance.OnPosistion;
            }
        }
    }
    public DragActions @Drag => new DragActions(this);
    public interface IDragActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnPosistion(InputAction.CallbackContext context);
    }
}
