// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Movement/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement_p1"",
            ""id"": ""a80aade1-e1e1-49e9-a017-d1393d738c46"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""ebef53f0-6733-4c76-bc8c-d069be6906f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""681d3446-4c47-49df-905b-62b35f5ece17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bc5882b0-a533-429f-9cf9-9ea7cf45187a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn"",
                    ""type"": ""Button"",
                    ""id"": ""c5f3ad9f-0f81-47d4-b643-dbf4721dd483"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""a4d756f6-6985-450b-be82-7aa3d264379a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""9a71a508-a1f1-4235-942d-f1f122685f69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""62798196-12b5-465a-b923-3feea5d4228d"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""457b9d0f-041d-4969-b8ea-ff6f3f2bc5b1"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa7c3cdf-c6d2-4e70-a092-25559fa0623f"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f7bfb90-69bb-4f58-8ba4-4036bf90dfc1"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94fe4a54-da51-4a99-86f7-a54907b598b3"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0b7e004-7c1a-4803-82f8-942e7749a6ef"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Movement_p2"",
            ""id"": ""6f09d50c-d534-4afa-aadd-794ff4f89da4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""431e008f-c39a-4cdf-abd3-5a119c3bdd23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""514f5e43-9eac-4d9e-8d20-b2c96c7d2bc5"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a7f560dd-b280-473c-aebc-ba32b1ef5785"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn"",
                    ""type"": ""Button"",
                    ""id"": ""e643907d-79dc-4544-b092-dca80b576578"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""9b413cd0-ab57-4362-95d3-9843b8cc224f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""9934b976-fedc-431d-a5ab-35cad88e3058"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d75ce641-ffe1-4996-bd22-e858fc5a1cfd"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29028f8c-b162-4970-8f48-f4e06e8375be"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa9cc9fc-156e-4232-85b3-ec9aa7a19c27"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec080568-b994-48f2-a9e4-87fdffe1a825"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""117b0870-f201-4733-ad25-c7743887c4a8"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8613a46b-b367-45b0-a0f4-1ca7d37013f7"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement_p1
        m_Movement_p1 = asset.FindActionMap("Movement_p1", throwIfNotFound: true);
        m_Movement_p1_Move = m_Movement_p1.FindAction("Move", throwIfNotFound: true);
        m_Movement_p1_Aim = m_Movement_p1.FindAction("Aim", throwIfNotFound: true);
        m_Movement_p1_Jump = m_Movement_p1.FindAction("Jump", throwIfNotFound: true);
        m_Movement_p1_Turn = m_Movement_p1.FindAction("Turn", throwIfNotFound: true);
        m_Movement_p1_Boost = m_Movement_p1.FindAction("Boost", throwIfNotFound: true);
        m_Movement_p1_Shoot = m_Movement_p1.FindAction("Shoot", throwIfNotFound: true);
        // Movement_p2
        m_Movement_p2 = asset.FindActionMap("Movement_p2", throwIfNotFound: true);
        m_Movement_p2_Move = m_Movement_p2.FindAction("Move", throwIfNotFound: true);
        m_Movement_p2_Aim = m_Movement_p2.FindAction("Aim", throwIfNotFound: true);
        m_Movement_p2_Jump = m_Movement_p2.FindAction("Jump", throwIfNotFound: true);
        m_Movement_p2_Turn = m_Movement_p2.FindAction("Turn", throwIfNotFound: true);
        m_Movement_p2_Boost = m_Movement_p2.FindAction("Boost", throwIfNotFound: true);
        m_Movement_p2_Shoot = m_Movement_p2.FindAction("Shoot", throwIfNotFound: true);
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

    // Movement_p1
    private readonly InputActionMap m_Movement_p1;
    private IMovement_p1Actions m_Movement_p1ActionsCallbackInterface;
    private readonly InputAction m_Movement_p1_Move;
    private readonly InputAction m_Movement_p1_Aim;
    private readonly InputAction m_Movement_p1_Jump;
    private readonly InputAction m_Movement_p1_Turn;
    private readonly InputAction m_Movement_p1_Boost;
    private readonly InputAction m_Movement_p1_Shoot;
    public struct Movement_p1Actions
    {
        private @PlayerControls m_Wrapper;
        public Movement_p1Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_p1_Move;
        public InputAction @Aim => m_Wrapper.m_Movement_p1_Aim;
        public InputAction @Jump => m_Wrapper.m_Movement_p1_Jump;
        public InputAction @Turn => m_Wrapper.m_Movement_p1_Turn;
        public InputAction @Boost => m_Wrapper.m_Movement_p1_Boost;
        public InputAction @Shoot => m_Wrapper.m_Movement_p1_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Movement_p1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Movement_p1Actions set) { return set.Get(); }
        public void SetCallbacks(IMovement_p1Actions instance)
        {
            if (m_Wrapper.m_Movement_p1ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnAim;
                @Jump.started -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnJump;
                @Turn.started -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnTurn;
                @Boost.started -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnBoost;
                @Boost.performed -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnBoost;
                @Boost.canceled -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnBoost;
                @Shoot.started -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_Movement_p1ActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_Movement_p1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @Boost.started += instance.OnBoost;
                @Boost.performed += instance.OnBoost;
                @Boost.canceled += instance.OnBoost;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public Movement_p1Actions @Movement_p1 => new Movement_p1Actions(this);

    // Movement_p2
    private readonly InputActionMap m_Movement_p2;
    private IMovement_p2Actions m_Movement_p2ActionsCallbackInterface;
    private readonly InputAction m_Movement_p2_Move;
    private readonly InputAction m_Movement_p2_Aim;
    private readonly InputAction m_Movement_p2_Jump;
    private readonly InputAction m_Movement_p2_Turn;
    private readonly InputAction m_Movement_p2_Boost;
    private readonly InputAction m_Movement_p2_Shoot;
    public struct Movement_p2Actions
    {
        private @PlayerControls m_Wrapper;
        public Movement_p2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_p2_Move;
        public InputAction @Aim => m_Wrapper.m_Movement_p2_Aim;
        public InputAction @Jump => m_Wrapper.m_Movement_p2_Jump;
        public InputAction @Turn => m_Wrapper.m_Movement_p2_Turn;
        public InputAction @Boost => m_Wrapper.m_Movement_p2_Boost;
        public InputAction @Shoot => m_Wrapper.m_Movement_p2_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Movement_p2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Movement_p2Actions set) { return set.Get(); }
        public void SetCallbacks(IMovement_p2Actions instance)
        {
            if (m_Wrapper.m_Movement_p2ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnAim;
                @Jump.started -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnJump;
                @Turn.started -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnTurn;
                @Boost.started -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnBoost;
                @Boost.performed -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnBoost;
                @Boost.canceled -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnBoost;
                @Shoot.started -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_Movement_p2ActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_Movement_p2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @Boost.started += instance.OnBoost;
                @Boost.performed += instance.OnBoost;
                @Boost.canceled += instance.OnBoost;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public Movement_p2Actions @Movement_p2 => new Movement_p2Actions(this);
    public interface IMovement_p1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IMovement_p2Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
