using UnityEditor;
using UnityEngine;

namespace SpaceSmuggler
{
	[CustomEditor(typeof(AudioEventSO), true)]
	public class AudioEventEditor : Editor
	{
		[SerializeField] AudioSource _previewer;

		public void OnEnable()
		{
			_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
			((AudioEventSO)target).Source = _previewer;
		}

		public void OnDisable()
		{
			DestroyImmediate(_previewer.gameObject);
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
			if (GUILayout.Button("Preview"))
				((AudioEventSO)target).Play();
			EditorGUI.EndDisabledGroup();
		}
	}
}
