using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Gameplay/InputReader")]
public class InputReaderSO
	: ScriptableObject,
	  InputActions.IPlayerActions,
	  InputActions.IPauseActions
{
	public event Action<Vector2> MoveEvent;
	public event Action<Vector2> LookEvent;
	public event System.Action AttackEvent;
	public event System.Action AttackCanceledEvent;
	public event System.Action PauseEvent;
	public event System.Action ResumeEvent;
	InputActions _input;

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

	public void OnMove(InputAction.CallbackContext context)
	{
		MoveEvent.Invoke(context.ReadValue<Vector2>());
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		LookEvent.Invoke(context.ReadValue<Vector2>());
	}

	public void OnAttack(InputAction.CallbackContext context)
	{
		switch (context.phase)
		{
			case InputActionPhase.Performed:
				AttackEvent.Invoke();
				break;
			case InputActionPhase.Canceled:
				AttackCanceledEvent.Invoke();
				break;
		}
	}

	public void OnPause(InputAction.CallbackContext context)
	{
		PauseEvent.Invoke();
	}

	public void OnResume(InputAction.CallbackContext context)
	{
		ResumeEvent.Invoke();
	}

	public void EnablePlayInput()
	{
		_input.Player.Enable();
		_input.Pause.Disable();
	}

	public void EnablePauseInput()
	{
		_input.Player.Disable();
		_input.Pause.Enable();
	}

	public void DisableInput()
	{
		_input.Player.Disable();
		_input.Pause.Disable();
	}
}
