//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/InputSystem/PlayerInput.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""actions"",
            ""id"": ""dfa973ed-dfae-4114-ab79-27d42cd8981b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7708efa9-ac3c-4d18-9647-323c192b4bce"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f153d58a-c059-43dd-9119-42b913095369"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraXY"",
                    ""type"": ""Value"",
                    ""id"": ""ec2a9328-1a6b-494f-9ac2-4ed03422556c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Change"",
                    ""type"": ""Button"",
                    ""id"": ""25cfa733-2acf-46cc-9aa4-de3d13d63256"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""eb48640a-0bad-4056-8d9f-781d8580003e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""4de7eb21-faf1-4c46-9c8b-f9a759160a32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CharaChangeLeft"",
                    ""type"": ""Button"",
                    ""id"": ""98bac88f-9d43-48ed-ae1d-41db31cb3f2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CharaChangeRight"",
                    ""type"": ""Button"",
                    ""id"": ""63da5537-5624-40be-8db8-883cbbcfd665"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skill"",
                    ""type"": ""Button"",
                    ""id"": ""91108244-9ea3-4d7a-8965-d5ce940a7a54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3318a4a8-ae4e-4c77-89ba-4e5800e2c8ca"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""78b448e6-d369-4760-9861-4b9e65c7f3d3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8a4b6be2-2380-4990-9365-1ed700514466"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b8c3cdb9-d2c1-4bfa-8f13-2c81346e0279"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5878193e-c832-4c47-83e0-f6469d0e0d53"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""56873bb8-2ae3-4a5b-86e9-88754ac772f7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e660cd6a-5d7a-48d9-bb89-7d6a9391ee08"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""993149d2-17e1-474f-ba23-7c6c3b835747"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09e93873-8d18-47f0-94cf-b9557e02da21"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f11791f1-8848-4975-a489-192224f8ad64"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78ef9441-1574-454a-b153-5ff5ec436379"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f831dba9-3b64-4d4f-8817-0e3bf8ae60e8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca4f449e-d150-47c8-a529-5cf167e49da9"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9533dfb7-98ef-45b7-8148-b343397af658"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6727d94-7589-400a-bd9f-3e0d01ad881b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8a54984-8e20-4e41-b4e2-d09db8bf1592"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CharaChangeLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""057fb130-c9aa-465a-a1f3-37e0c9ceaeb4"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CharaChangeLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23c72aa8-3226-4789-a43c-05d668ea9523"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CharaChangeRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9281fcb-dc75-4fa6-99e8-859bd102f9c0"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CharaChangeRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""682941a1-5141-4193-82a5-7b241b09e5a0"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b8c9d8c-148b-4c28-ac80-98c3b19ede42"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6b57093-2321-4e7a-853b-f6321f99b5f9"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraXY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5104f3ee-29cb-48bb-a681-46f6c6c10fd8"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraXY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // actions
        m_actions = asset.FindActionMap("actions", throwIfNotFound: true);
        m_actions_Move = m_actions.FindAction("Move", throwIfNotFound: true);
        m_actions_Jump = m_actions.FindAction("Jump", throwIfNotFound: true);
        m_actions_CameraXY = m_actions.FindAction("CameraXY", throwIfNotFound: true);
        m_actions_Change = m_actions.FindAction("Change", throwIfNotFound: true);
        m_actions_Pause = m_actions.FindAction("Pause", throwIfNotFound: true);
        m_actions_Dash = m_actions.FindAction("Dash", throwIfNotFound: true);
        m_actions_CharaChangeLeft = m_actions.FindAction("CharaChangeLeft", throwIfNotFound: true);
        m_actions_CharaChangeRight = m_actions.FindAction("CharaChangeRight", throwIfNotFound: true);
        m_actions_Skill = m_actions.FindAction("Skill", throwIfNotFound: true);
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

    // actions
    private readonly InputActionMap m_actions;
    private List<IActionsActions> m_ActionsActionsCallbackInterfaces = new List<IActionsActions>();
    private readonly InputAction m_actions_Move;
    private readonly InputAction m_actions_Jump;
    private readonly InputAction m_actions_CameraXY;
    private readonly InputAction m_actions_Change;
    private readonly InputAction m_actions_Pause;
    private readonly InputAction m_actions_Dash;
    private readonly InputAction m_actions_CharaChangeLeft;
    private readonly InputAction m_actions_CharaChangeRight;
    private readonly InputAction m_actions_Skill;
    public struct ActionsActions
    {
        private @PlayerInput m_Wrapper;
        public ActionsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_actions_Move;
        public InputAction @Jump => m_Wrapper.m_actions_Jump;
        public InputAction @CameraXY => m_Wrapper.m_actions_CameraXY;
        public InputAction @Change => m_Wrapper.m_actions_Change;
        public InputAction @Pause => m_Wrapper.m_actions_Pause;
        public InputAction @Dash => m_Wrapper.m_actions_Dash;
        public InputAction @CharaChangeLeft => m_Wrapper.m_actions_CharaChangeLeft;
        public InputAction @CharaChangeRight => m_Wrapper.m_actions_CharaChangeRight;
        public InputAction @Skill => m_Wrapper.m_actions_Skill;
        public InputActionMap Get() { return m_Wrapper.m_actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void AddCallbacks(IActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_ActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ActionsActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @CameraXY.started += instance.OnCameraXY;
            @CameraXY.performed += instance.OnCameraXY;
            @CameraXY.canceled += instance.OnCameraXY;
            @Change.started += instance.OnChange;
            @Change.performed += instance.OnChange;
            @Change.canceled += instance.OnChange;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @CharaChangeLeft.started += instance.OnCharaChangeLeft;
            @CharaChangeLeft.performed += instance.OnCharaChangeLeft;
            @CharaChangeLeft.canceled += instance.OnCharaChangeLeft;
            @CharaChangeRight.started += instance.OnCharaChangeRight;
            @CharaChangeRight.performed += instance.OnCharaChangeRight;
            @CharaChangeRight.canceled += instance.OnCharaChangeRight;
            @Skill.started += instance.OnSkill;
            @Skill.performed += instance.OnSkill;
            @Skill.canceled += instance.OnSkill;
        }

        private void UnregisterCallbacks(IActionsActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @CameraXY.started -= instance.OnCameraXY;
            @CameraXY.performed -= instance.OnCameraXY;
            @CameraXY.canceled -= instance.OnCameraXY;
            @Change.started -= instance.OnChange;
            @Change.performed -= instance.OnChange;
            @Change.canceled -= instance.OnChange;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @CharaChangeLeft.started -= instance.OnCharaChangeLeft;
            @CharaChangeLeft.performed -= instance.OnCharaChangeLeft;
            @CharaChangeLeft.canceled -= instance.OnCharaChangeLeft;
            @CharaChangeRight.started -= instance.OnCharaChangeRight;
            @CharaChangeRight.performed -= instance.OnCharaChangeRight;
            @CharaChangeRight.canceled -= instance.OnCharaChangeRight;
            @Skill.started -= instance.OnSkill;
            @Skill.performed -= instance.OnSkill;
            @Skill.canceled -= instance.OnSkill;
        }

        public void RemoveCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_ActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ActionsActions @actions => new ActionsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCameraXY(InputAction.CallbackContext context);
        void OnChange(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnCharaChangeLeft(InputAction.CallbackContext context);
        void OnCharaChangeRight(InputAction.CallbackContext context);
        void OnSkill(InputAction.CallbackContext context);
    }
}
