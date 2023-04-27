// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Cursor/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Cursor"",
            ""id"": ""33105bc0-f219-4186-a287-bc5c1f5351c0"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""6b5fc6fc-7a92-4314-8fb1-45128c266444"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""PassThrough"",
                    ""id"": ""479f4b69-97a6-4cee-9378-1c9b24716752"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Restart Level"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f7952a94-346f-495f-833f-86af9e85c18d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""f0df8022-a6cb-461f-85f4-be51194c166d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2b5c8119-6d40-4e64-968a-ddf48e7a15d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""90dd9cc0-dae4-493e-a966-c991f8dc8fd1"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""972a4148-26f2-455d-abf0-67566bdaac63"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8677f021-316d-4697-9c68-8ebbb4a669d7"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart Level"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbe3d1d3-59c7-4168-9474-ea2c3143566b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""653dc498-e72b-474f-8968-fd6443f42242"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Cursor
        m_Cursor = asset.FindActionMap("Cursor", throwIfNotFound: true);
        m_Cursor_MousePosition = m_Cursor.FindAction("MousePosition", throwIfNotFound: true);
        m_Cursor_Drag = m_Cursor.FindAction("Drag", throwIfNotFound: true);
        m_Cursor_RestartLevel = m_Cursor.FindAction("Restart Level", throwIfNotFound: true);
        m_Cursor_Attack = m_Cursor.FindAction("Attack", throwIfNotFound: true);
        m_Cursor_Pause = m_Cursor.FindAction("Pause", throwIfNotFound: true);
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

    // Cursor
    private readonly InputActionMap m_Cursor;
    private ICursorActions m_CursorActionsCallbackInterface;
    private readonly InputAction m_Cursor_MousePosition;
    private readonly InputAction m_Cursor_Drag;
    private readonly InputAction m_Cursor_RestartLevel;
    private readonly InputAction m_Cursor_Attack;
    private readonly InputAction m_Cursor_Pause;
    public struct CursorActions
    {
        private @Controls m_Wrapper;
        public CursorActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Cursor_MousePosition;
        public InputAction @Drag => m_Wrapper.m_Cursor_Drag;
        public InputAction @RestartLevel => m_Wrapper.m_Cursor_RestartLevel;
        public InputAction @Attack => m_Wrapper.m_Cursor_Attack;
        public InputAction @Pause => m_Wrapper.m_Cursor_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Cursor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CursorActions set) { return set.Get(); }
        public void SetCallbacks(ICursorActions instance)
        {
            if (m_Wrapper.m_CursorActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnMousePosition;
                @Drag.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnDrag;
                @RestartLevel.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnRestartLevel;
                @RestartLevel.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnRestartLevel;
                @RestartLevel.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnRestartLevel;
                @Attack.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnAttack;
                @Pause.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_CursorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @RestartLevel.started += instance.OnRestartLevel;
                @RestartLevel.performed += instance.OnRestartLevel;
                @RestartLevel.canceled += instance.OnRestartLevel;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public CursorActions @Cursor => new CursorActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface ICursorActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnRestartLevel(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
