using UnityEngine;
using UnityEditor;

namespace UTJ.Alembic
{
    [CustomPropertyDrawer(typeof(Bool))]
    class BoolDrawer : PropertyDrawer
    {
        private BoolDrawer() { }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if(property == null)
            {
                return;
            }

            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var p = property.FindPropertyRelative("v");
            bool value = p.intValue != 0;

            EditorGUI.BeginChangeCheck();
            value = EditorGUI.Toggle(position, value);
            if (EditorGUI.EndChangeCheck())
            {
                p.intValue = value ? 1 : 0;
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}