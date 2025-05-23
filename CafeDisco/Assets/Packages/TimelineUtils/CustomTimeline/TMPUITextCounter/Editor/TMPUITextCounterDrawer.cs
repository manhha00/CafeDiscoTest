#if UNITY_EDITOR
namespace GameFoundation.CustomTimeline {
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(TMPUITextCounterBehaviour))]
    public class TMPUITextCounterDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            const int fieldCount = 5;
            return fieldCount * EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var startValueProp = property.FindPropertyRelative("startValue");
            var endValueProp = property.FindPropertyRelative("endValue");
            var curveTypeProp = property.FindPropertyRelative("curveType");
            var formatProp = property.FindPropertyRelative("format");
            var onUpdateProp = property.FindPropertyRelative("onUpdate");

            var singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(singleFieldRect, startValueProp);

            singleFieldRect.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(singleFieldRect, endValueProp);
            
            singleFieldRect.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(singleFieldRect, curveTypeProp);

            if (curveTypeProp.enumValueIndex == (int) TimelineCurve.Custom) {
                var curveProp = property.FindPropertyRelative("curve");
                singleFieldRect.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(singleFieldRect, curveProp);
            }

            singleFieldRect.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(singleFieldRect, formatProp);
            
            singleFieldRect.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(singleFieldRect, onUpdateProp, true);
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
