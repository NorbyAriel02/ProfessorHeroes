//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/TirikaToolbox/InputSystemTirika/Controlles.inputactions
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

public partial class @Controlles: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controlles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controlles"",
    ""maps"": [
        {
            ""name"": ""Base"",
            ""id"": ""d258883f-0a93-48ae-98aa-f6a65cc4f7e6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""463889ab-b4d4-4dec-803d-632e09974d3e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""16df6ffa-0c27-44b1-9db1-9ecd124f88af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack1"",
                    ""type"": ""Button"",
                    ""id"": ""ccdae38e-5be8-4b9d-bcc3-99f8e6f6fa64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""bd85851f-e319-4daa-996c-7671e5dc1dad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon1"",
                    ""type"": ""Button"",
                    ""id"": ""431ec7be-92fd-43bf-8af4-46cbafa096fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon2"",
                    ""type"": ""Button"",
                    ""id"": ""f70f686a-75a3-4d5a-a312-27ee44984f9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon3"",
                    ""type"": ""Button"",
                    ""id"": ""f9bc1cfb-e0ee-4252-8b87-b8f40c3276bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon4"",
                    ""type"": ""Button"",
                    ""id"": ""ba091e22-3616-46d6-8a52-5f96f7270b18"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Button"",
                    ""id"": ""7a2d8700-5601-43d4-b155-b058795a6d7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Takeit"",
                    ""type"": ""Button"",
                    ""id"": ""4082ad2a-b618-46f8-a9d0-c19b442e76d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CancelAttack"",
                    ""type"": ""Button"",
                    ""id"": ""e0874216-acf7-47a8-849d-3d5c8cc3d0dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Stats"",
                    ""type"": ""Button"",
                    ""id"": ""d493c4a1-baee-414a-b34a-9a661522a226"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""2520febb-b6f6-4074-b70a-0cb43fa383c9"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""34794251-8836-4b4d-abb5-31bfcd0da24f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3d76d80d-a828-4745-9c4b-58803f0a1a7f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""00f22d3e-760d-4507-9eef-8b6144ae3d86"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e893264b-a6e8-4c52-958a-ac208adde0f0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Flechas"",
                    ""id"": ""9d526ff1-4004-4188-b393-804c926407c8"",
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
                    ""id"": ""41dff278-b9e7-4f44-b636-a38a17f359dc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""69a2f6d8-bda5-4599-a749-70bc9eb6288e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bce9e159-f3ad-404f-9b67-677df59915bd"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8e81160d-b6cf-4a8f-92ab-ac7f10f2310e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7a90a1c1-db27-46d9-8580-5c0c38b8f3e1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddbfeb5a-e9d5-47be-944e-8cfd16d02132"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bceb2e9-9e29-46b1-9018-b94fb6b358da"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Hold(duration=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d126258a-0bd1-4ba7-9d6e-dd36cb6167a1"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""259b3eb8-38ca-4356-9928-3ab2dd42aad7"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23b871e0-0a49-435f-8d81-3e9bbdbc3fd0"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c404d94f-4054-4334-857e-638f6fcb0594"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee6e3047-adf7-46f6-bd7c-1da74536cd23"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""462592da-6ee1-46f0-9813-01ec92333b19"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Takeit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d15abce4-f082-46b6-bc9f-9df397580a7a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6c1d676-6c3d-45b3-94cc-87b7c6c02c84"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stats"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Base
        m_Base = asset.FindActionMap("Base", throwIfNotFound: true);
        m_Base_Move = m_Base.FindAction("Move", throwIfNotFound: true);
        m_Base_Jump = m_Base.FindAction("Jump", throwIfNotFound: true);
        m_Base_Attack1 = m_Base.FindAction("Attack1", throwIfNotFound: true);
        m_Base_Sprint = m_Base.FindAction("Sprint", throwIfNotFound: true);
        m_Base_Weapon1 = m_Base.FindAction("Weapon1", throwIfNotFound: true);
        m_Base_Weapon2 = m_Base.FindAction("Weapon2", throwIfNotFound: true);
        m_Base_Weapon3 = m_Base.FindAction("Weapon3", throwIfNotFound: true);
        m_Base_Weapon4 = m_Base.FindAction("Weapon4", throwIfNotFound: true);
        m_Base_Pickup = m_Base.FindAction("Pickup", throwIfNotFound: true);
        m_Base_Takeit = m_Base.FindAction("Takeit", throwIfNotFound: true);
        m_Base_CancelAttack = m_Base.FindAction("CancelAttack", throwIfNotFound: true);
        m_Base_Stats = m_Base.FindAction("Stats", throwIfNotFound: true);
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

    // Base
    private readonly InputActionMap m_Base;
    private List<IBaseActions> m_BaseActionsCallbackInterfaces = new List<IBaseActions>();
    private readonly InputAction m_Base_Move;
    private readonly InputAction m_Base_Jump;
    private readonly InputAction m_Base_Attack1;
    private readonly InputAction m_Base_Sprint;
    private readonly InputAction m_Base_Weapon1;
    private readonly InputAction m_Base_Weapon2;
    private readonly InputAction m_Base_Weapon3;
    private readonly InputAction m_Base_Weapon4;
    private readonly InputAction m_Base_Pickup;
    private readonly InputAction m_Base_Takeit;
    private readonly InputAction m_Base_CancelAttack;
    private readonly InputAction m_Base_Stats;
    public struct BaseActions
    {
        private @Controlles m_Wrapper;
        public BaseActions(@Controlles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Base_Move;
        public InputAction @Jump => m_Wrapper.m_Base_Jump;
        public InputAction @Attack1 => m_Wrapper.m_Base_Attack1;
        public InputAction @Sprint => m_Wrapper.m_Base_Sprint;
        public InputAction @Weapon1 => m_Wrapper.m_Base_Weapon1;
        public InputAction @Weapon2 => m_Wrapper.m_Base_Weapon2;
        public InputAction @Weapon3 => m_Wrapper.m_Base_Weapon3;
        public InputAction @Weapon4 => m_Wrapper.m_Base_Weapon4;
        public InputAction @Pickup => m_Wrapper.m_Base_Pickup;
        public InputAction @Takeit => m_Wrapper.m_Base_Takeit;
        public InputAction @CancelAttack => m_Wrapper.m_Base_CancelAttack;
        public InputAction @Stats => m_Wrapper.m_Base_Stats;
        public InputActionMap Get() { return m_Wrapper.m_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActions set) { return set.Get(); }
        public void AddCallbacks(IBaseActions instance)
        {
            if (instance == null || m_Wrapper.m_BaseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BaseActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Attack1.started += instance.OnAttack1;
            @Attack1.performed += instance.OnAttack1;
            @Attack1.canceled += instance.OnAttack1;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @Weapon1.started += instance.OnWeapon1;
            @Weapon1.performed += instance.OnWeapon1;
            @Weapon1.canceled += instance.OnWeapon1;
            @Weapon2.started += instance.OnWeapon2;
            @Weapon2.performed += instance.OnWeapon2;
            @Weapon2.canceled += instance.OnWeapon2;
            @Weapon3.started += instance.OnWeapon3;
            @Weapon3.performed += instance.OnWeapon3;
            @Weapon3.canceled += instance.OnWeapon3;
            @Weapon4.started += instance.OnWeapon4;
            @Weapon4.performed += instance.OnWeapon4;
            @Weapon4.canceled += instance.OnWeapon4;
            @Pickup.started += instance.OnPickup;
            @Pickup.performed += instance.OnPickup;
            @Pickup.canceled += instance.OnPickup;
            @Takeit.started += instance.OnTakeit;
            @Takeit.performed += instance.OnTakeit;
            @Takeit.canceled += instance.OnTakeit;
            @CancelAttack.started += instance.OnCancelAttack;
            @CancelAttack.performed += instance.OnCancelAttack;
            @CancelAttack.canceled += instance.OnCancelAttack;
            @Stats.started += instance.OnStats;
            @Stats.performed += instance.OnStats;
            @Stats.canceled += instance.OnStats;
        }

        private void UnregisterCallbacks(IBaseActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Attack1.started -= instance.OnAttack1;
            @Attack1.performed -= instance.OnAttack1;
            @Attack1.canceled -= instance.OnAttack1;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @Weapon1.started -= instance.OnWeapon1;
            @Weapon1.performed -= instance.OnWeapon1;
            @Weapon1.canceled -= instance.OnWeapon1;
            @Weapon2.started -= instance.OnWeapon2;
            @Weapon2.performed -= instance.OnWeapon2;
            @Weapon2.canceled -= instance.OnWeapon2;
            @Weapon3.started -= instance.OnWeapon3;
            @Weapon3.performed -= instance.OnWeapon3;
            @Weapon3.canceled -= instance.OnWeapon3;
            @Weapon4.started -= instance.OnWeapon4;
            @Weapon4.performed -= instance.OnWeapon4;
            @Weapon4.canceled -= instance.OnWeapon4;
            @Pickup.started -= instance.OnPickup;
            @Pickup.performed -= instance.OnPickup;
            @Pickup.canceled -= instance.OnPickup;
            @Takeit.started -= instance.OnTakeit;
            @Takeit.performed -= instance.OnTakeit;
            @Takeit.canceled -= instance.OnTakeit;
            @CancelAttack.started -= instance.OnCancelAttack;
            @CancelAttack.performed -= instance.OnCancelAttack;
            @CancelAttack.canceled -= instance.OnCancelAttack;
            @Stats.started -= instance.OnStats;
            @Stats.performed -= instance.OnStats;
            @Stats.canceled -= instance.OnStats;
        }

        public void RemoveCallbacks(IBaseActions instance)
        {
            if (m_Wrapper.m_BaseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBaseActions instance)
        {
            foreach (var item in m_Wrapper.m_BaseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BaseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BaseActions @Base => new BaseActions(this);
    public interface IBaseActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack1(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnWeapon1(InputAction.CallbackContext context);
        void OnWeapon2(InputAction.CallbackContext context);
        void OnWeapon3(InputAction.CallbackContext context);
        void OnWeapon4(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
        void OnTakeit(InputAction.CallbackContext context);
        void OnCancelAttack(InputAction.CallbackContext context);
        void OnStats(InputAction.CallbackContext context);
    }
}
