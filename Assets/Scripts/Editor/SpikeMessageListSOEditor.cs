#if UNITY_EDITOR
using Game.Traps;
using UnityEditor;
using UnityEngine;
namespace Game.InspectEditor
{
    [CustomEditor(typeof(SpikeMessageSO), true)]
    public class SpikeMessageListSOEditor : Editor
    {
        //重写OnInspectorGUI类(刷新Inspector面板)
        public override void OnInspectorGUI()
        {
            // 更新序列化对象
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Name"), new GUIContent("行为描述"));
            ShowAllBoolProperties();
            if (GetBoolValue("IsMove"))
            {
                ShowVectorProperty(serializedObject.FindProperty("Vector"));
            }
            if (GetBoolValue("IsRotate"))
            {
                ShowRotationProperty(serializedObject.FindProperty("Rotation"));
            }
            if (GetBoolValue("IsScale"))
            {
                ShowScaleProperty(serializedObject.FindProperty("Scale"));
            }
            if (GetBoolValue("IsFlash"))
            {
                ShowFlashProperty(serializedObject.FindProperty("Flash"));
            }
            // 应用对序列化对象的修改
            serializedObject.ApplyModifiedProperties();
        }
        private void ShowVectorProperty(SerializedProperty property)
        {
            if (property == null) return;
            EditorGUILayout.LabelField("位移", GUI.skin.horizontalSlider);
            EditorGUILayout.LabelField("位移信息:", GUI.skin.label);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Vector"), new GUIContent("位移"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Duration"), new GUIContent("持续时间"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("PercentageHandler"), new GUIContent("轨迹方程"));

        }

        private void ShowRotationProperty(SerializedProperty property)
        {
            if (property == null) return;
            EditorGUILayout.LabelField("旋转", GUI.skin.horizontalSlider);
            EditorGUILayout.LabelField("旋转信息:", GUI.skin.label);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Rotation"), new GUIContent("旋转角度"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Duration"), new GUIContent("持续时间"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("PercentageHandler"), new GUIContent("轨迹方程"));
        }
        private void ShowScaleProperty(SerializedProperty property)
        {
            if (property == null) return;
            EditorGUILayout.LabelField("放大缩小", GUI.skin.horizontalSlider);
            EditorGUILayout.LabelField("缩放信息:", GUI.skin.label);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Scale"), new GUIContent("目标大小"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Duration"), new GUIContent("持续时间"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("PercentageHandler"), new GUIContent("轨迹方程"));
        }
        private void ShowFlashProperty(SerializedProperty property)
        {
            if (property == null) return;
            EditorGUILayout.LabelField("闪现", GUI.skin.horizontalSlider);
            EditorGUILayout.LabelField("闪现信息:", GUI.skin.label);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Position"), new GUIContent("闪现位置"));
        }
        private void ShowAllBoolProperties()
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("IsMove"), new GUIContent("是否位移"));
            if (EditorGUI.EndChangeCheck() && GetBoolValue("IsMove"))
            {
                // 如果 IsMove 被设置为 true，则将 IsFlash 设置为 false
                SetBoolProperties("IsFlash", false);
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("IsRotate"), new GUIContent("是否旋转"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("IsScale"), new GUIContent("是否缩放"));
            EditorGUI.BeginChangeCheck();
            // 监听 IsFlash 属性的变化
            EditorGUILayout.PropertyField(serializedObject.FindProperty("IsFlash"), new GUIContent("是否闪现"));
            if (EditorGUI.EndChangeCheck() && GetBoolValue("IsFlash"))
            {
                // 如果 IsFlash 被设置为 true，则将 IsMove 设置为 false
                SetBoolProperties("IsMove", false);
            }
        }
        private void SetBoolProperties(string name, bool value)
        {
            SerializedProperty property = serializedObject.FindProperty(name);
            if (property != null && property.propertyType == SerializedPropertyType.Boolean)
            {
                property.boolValue = value;
            }
            else
            {
                Debug.LogWarning($"Property '{name}' not found or is not a boolean.");
            }
        }
        private bool GetBoolValue(string name)
        {
            SerializedProperty property = serializedObject.FindProperty(name);
            if (property != null && property.propertyType == SerializedPropertyType.Boolean)
            {
                return property.boolValue;
            }
            else
            {
                Debug.LogWarning($"Property '{name}' not found or is not a boolean.");
                return false;
            }
        }
    }
}

#endif