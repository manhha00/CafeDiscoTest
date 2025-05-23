﻿#if UNITY_EDITOR
namespace GameFoundation.CustomTimeline {
	using UnityEditor;

	[CustomEditor(typeof(TimeMachineClip))]
	public class TimeMachineClipInspector : UnityEditor.Editor {
		private SerializedProperty actionProp, conditionProp;

		private void OnEnable() {
			this.actionProp    = this.serializedObject.FindProperty("action");
			this.conditionProp = this.serializedObject.FindProperty("condition");
		}

		public override void OnInspectorGUI() {
			bool isMarker = false; //if it's a marker we don't need to draw any Condition or parameters

			//Action
			EditorGUILayout.PropertyField(this.actionProp);

			//change the int into an enum
			int                                    index      = this.actionProp.enumValueIndex;
			TimeMachineBehaviour.TimeMachineAction actionType = (TimeMachineBehaviour.TimeMachineAction) index;

			//Draws only the appropriate information based on the Action Type
			switch (actionType) {
				case TimeMachineBehaviour.TimeMachineAction.Marker:
					isMarker = true;
					EditorGUILayout.PropertyField(this.serializedObject.FindProperty("markerLabel"));
					break;

				case TimeMachineBehaviour.TimeMachineAction.JumpToMarker:
					EditorGUILayout.PropertyField(this.serializedObject.FindProperty("markerToJumpTo"));
					break;

				case TimeMachineBehaviour.TimeMachineAction.JumpToTime:
					EditorGUILayout.PropertyField(this.serializedObject.FindProperty("timeToJumpTo"));
					break;
			}


			if (!isMarker) {
				//Condition
				EditorGUILayout.Space();
				EditorGUILayout.LabelField("Logic", EditorStyles.boldLabel);

				//change the int into an enum
				index = this.conditionProp.enumValueIndex;
				TimeMachineBehaviour.Condition conditionType = (TimeMachineBehaviour.Condition) index;

				//Draws only the appropriate information based on the Condition type
				switch (conditionType) {
					case TimeMachineBehaviour.Condition.Always:
						EditorGUILayout.HelpBox("The above action will always be executed.", MessageType.Warning);
						EditorGUILayout.PropertyField(this.conditionProp);
						break;

					case TimeMachineBehaviour.Condition.Never:
						EditorGUILayout.HelpBox("The above action will never be executed. Practically, it's as if clip was disabled.", MessageType.Warning);
						EditorGUILayout.PropertyField(this.conditionProp);
						break;

//				case TimeMachineBehaviour.Condition.PlatoonIsAlive:
//					EditorGUILayout.HelpBox("The above action will be executed if any Unit in the Platoon connected below is alive when the playhead reaches this clip.", MessageType.Info);
//					EditorGUILayout.Space();
//					EditorGUILayout.PropertyField(conditionProp);
//					EditorGUILayout.PropertyField(serializedObject.FindProperty("platoon"));
//					break;

				}
			}

			this.serializedObject.ApplyModifiedProperties();
		}
	}
}
#endif