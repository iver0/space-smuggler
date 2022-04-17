using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceSmuggler
{
	/// <summary>
	/// Player input handling.
	/// </summary>
	[CreateAssetMenu(menuName = "Gameplay/Input Reader")]
	public class InputReaderSO
		: ScriptableObject,
		  InputActions.IPlayerActions,
		  InputActions.IPauseActions
	{
		#region Fields
		public event Action<Vector2> MoveEvent;
		public event Action<Vector2> LookEvent;
		public event Action AttackEvent;
		public event Action AttackCanceledEvent;
		public event Action PauseEvent;
		public event Action ResumeEvent;
		InputActions _input;
		#endregion

		#region LifeCycle
		void OnEnable()
		{
			if (_input == null)
			{
				_input = new InputActions();

				_input.Player.SetCallbacks(this);
				_input.Pause.SetCallbacks(this);
			}
			EnablePlayInput();
		}

		void OnDisable()
		{
			DisableInput();
		}
		#endregion

		#region EventListeners
		public void OnMove(InputAction.CallbackContext context)
		{
			MoveEvent?.Invoke(context.ReadValue<Vector2>());
		}

		public void OnLook(InputAction.CallbackContext context)
		{
			LookEvent?.Invoke(context.ReadValue<Vector2>());
		}

		public void OnAttack(InputAction.CallbackContext context)
		{
			switch (context.phase)
			{
				case InputActionPhase.Performed:
					AttackEvent?.Invoke();
					break;
				case InputActionPhase.Canceled:
					AttackCanceledEvent?.Invoke();
					break;
			}
		}

		public void OnPause(InputAction.CallbackContext context)
		{
			PauseEvent?.Invoke();
		}

		public void OnResume(InputAction.CallbackContext context)
		{
			ResumeEvent?.Invoke();
		}
		#endregion

		#region PublicMethods
		/// <summary>
		/// Switch to player input scheme.
		/// </summary>
		public void EnablePlayInput()
		{
			_input.Player.Enable();
			_input.Pause.Disable();
		}

		/// <summary>
		/// Switch to pause input scheme.
		/// </summary>
		public void EnablePauseInput()
		{
			_input.Player.Disable();
			_input.Pause.Enable();
		}

		/// <summary>
		/// Turn off all input schemes.
		/// </summary>
		public void DisableInput()
		{
			_input.Player.Disable();
			_input.Pause.Disable();
		}
		#endregion
	}
}
