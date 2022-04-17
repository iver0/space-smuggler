//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/SpaceSmuggler/Scripts/Input/InputActions.inputactions
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

namespace SpaceSmuggler
{
	public partial class @InputActions : IInputActionCollection2, IDisposable
	{
		public InputActionAsset asset { get; }
		public @InputActions()
		{
			asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""228b0cf8-8a40-487c-9c83-1ea518fb612d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""01a7cd9c-62b9-4d54-9676-676a464b84b0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""0f75d0e8-850a-4d9c-bd33-e2227048c5e0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""08c79ac1-a29c-4518-9f95-3938ce107f57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""0f5a3067-c01c-4a77-b2a1-0d110e6455da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""4692a9a3-7b69-4d48-b31d-205910c11486"",
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
                    ""id"": ""392ae67b-302d-41e8-84c2-573361734825"",
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
                    ""id"": ""030e2b47-692c-4a43-9125-57c0a56a1a25"",
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
                    ""id"": ""0486bcfb-7001-4453-8a63-3c2cda90c4ae"",
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
                    ""id"": ""10bd5522-d8a2-4814-b599-15172bea61c6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9aaf734a-f87b-4eac-bd9b-67e4bec60b14"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d396b6a5-5f50-4e6d-b47a-a0ad41b425bc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58d92202-a33c-4cc8-b8c0-6759a9dde745"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45b08568-b68a-4d2b-816f-4de99e33f9c6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ab440df-8f06-4bc9-a28d-b82cc2363853"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7337d56-828e-4455-b604-3911fdc681f6"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause"",
            ""id"": ""4e7ba99d-5134-43e4-97b2-564deb4e31ac"",
            ""actions"": [
                {
                    ""name"": ""Resume"",
                    ""type"": ""Button"",
                    ""id"": ""e0c216b4-5287-4870-9c2b-6eb54724d3f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0564d731-13de-4c7c-892c-c051717238a6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4e9717a-af4e-4e4e-b739-db3338696743"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
			// Player
			m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
			m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
			m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
			m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
			m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
			// Pause
			m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
			m_Pause_Resume = m_Pause.FindAction("Resume", throwIfNotFound: true);
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

		// Player
		private readonly InputActionMap m_Player;
		private IPlayerActions m_PlayerActionsCallbackInterface;
		private readonly InputAction m_Player_Move;
		private readonly InputAction m_Player_Look;
		private readonly InputAction m_Player_Attack;
		private readonly InputAction m_Player_Pause;
		public struct PlayerActions
		{
			private @InputActions m_Wrapper;
			public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
			public InputAction @Move => m_Wrapper.m_Player_Move;
			public InputAction @Look => m_Wrapper.m_Player_Look;
			public InputAction @Attack => m_Wrapper.m_Player_Attack;
			public InputAction @Pause => m_Wrapper.m_Player_Pause;
			public InputActionMap Get() { return m_Wrapper.m_Player; }
			public void Enable() { Get().Enable(); }
			public void Disable() { Get().Disable(); }
			public bool enabled => Get().enabled;
			public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
			public void SetCallbacks(IPlayerActions instance)
			{
				if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
				{
					@Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
					@Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
					@Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
					@Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
					@Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
					@Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
					@Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
					@Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
					@Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
					@Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
					@Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
					@Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
				}
				m_Wrapper.m_PlayerActionsCallbackInterface = instance;
				if (instance != null)
				{
					@Move.started += instance.OnMove;
					@Move.performed += instance.OnMove;
					@Move.canceled += instance.OnMove;
					@Look.started += instance.OnLook;
					@Look.performed += instance.OnLook;
					@Look.canceled += instance.OnLook;
					@Attack.started += instance.OnAttack;
					@Attack.performed += instance.OnAttack;
					@Attack.canceled += instance.OnAttack;
					@Pause.started += instance.OnPause;
					@Pause.performed += instance.OnPause;
					@Pause.canceled += instance.OnPause;
				}
			}
		}
		public PlayerActions @Player => new PlayerActions(this);

		// Pause
		private readonly InputActionMap m_Pause;
		private IPauseActions m_PauseActionsCallbackInterface;
		private readonly InputAction m_Pause_Resume;
		public struct PauseActions
		{
			private @InputActions m_Wrapper;
			public PauseActions(@InputActions wrapper) { m_Wrapper = wrapper; }
			public InputAction @Resume => m_Wrapper.m_Pause_Resume;
			public InputActionMap Get() { return m_Wrapper.m_Pause; }
			public void Enable() { Get().Enable(); }
			public void Disable() { Get().Disable(); }
			public bool enabled => Get().enabled;
			public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
			public void SetCallbacks(IPauseActions instance)
			{
				if (m_Wrapper.m_PauseActionsCallbackInterface != null)
				{
					@Resume.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnResume;
					@Resume.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnResume;
					@Resume.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnResume;
				}
				m_Wrapper.m_PauseActionsCallbackInterface = instance;
				if (instance != null)
				{
					@Resume.started += instance.OnResume;
					@Resume.performed += instance.OnResume;
					@Resume.canceled += instance.OnResume;
				}
			}
		}
		public PauseActions @Pause => new PauseActions(this);
		public interface IPlayerActions
		{
			void OnMove(InputAction.CallbackContext context);
			void OnLook(InputAction.CallbackContext context);
			void OnAttack(InputAction.CallbackContext context);
			void OnPause(InputAction.CallbackContext context);
		}
		public interface IPauseActions
		{
			void OnResume(InputAction.CallbackContext context);
		}
	}
}
