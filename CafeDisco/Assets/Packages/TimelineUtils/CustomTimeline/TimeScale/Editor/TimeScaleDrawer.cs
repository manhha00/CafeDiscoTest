#if UNITY_EDITOR
namespace GameFoundation.CustomTimeline {
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(TimeScaleBehaviour))]
    public class TimeScaleDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            int fieldCount = 0;
            return fieldCount * EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            SerializedProperty timeScaleProp = property.FindPropertyRelative("timeScale");
            Rect singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(singleFieldRect, timeScaleProp);
        }
    }
}
#endif
