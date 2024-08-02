using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Switch;

namespace UnityEditorInternal.Switch.VRKitEditorLibrary
{
    using TextureLayout = UnityEngine.Switch.VRKit.TextureLayout;

    [CustomEditor(typeof(VRKitSettings))]
    public class VRKitSettingsEditor : UnityEditor.Editor
    {
        private const string kStereoRenderingMode = "m_StereoRenderingMode";
        private const string kDefaultTextureLayout = "m_DefaultTextureLayout";
        private const string kImproveLegacyRenderingIssueOnHDR = "m_ImproveLegacyRenderingIssueOnHDR";
        static GUIContent s_StereoRenderingMode = EditorGUIUtility.TrTextContent("Stereo Rendering Mode");
        static GUIContent s_DefaultTextureLayout = EditorGUIUtility.TrTextContent("Default TextureLayout");
        static GUIContent s_ImproveLegacyRenderingIssueOnHDR = EditorGUIUtility.TrTextContent("Improve Legacy HDR");

        private SerializedProperty m_StereoRenderingMode;
        private SerializedProperty m_DefaultTextureLayout;
        private SerializedProperty m_ImproveLegacyRenderingIssueOnHDR;

        static bool s_ShouldBeRestarted;

        static string[] s_TextureLayoutNames;
        static System.Array s_TextureLayoutValues;
        static GUIContent s_warningIcon;

        public override void OnInspectorGUI()
        {
            if (serializedObject == null || serializedObject.targetObject == null)
                return;

            if (m_StereoRenderingMode == null) m_StereoRenderingMode = serializedObject.FindProperty(kStereoRenderingMode);
            if (m_DefaultTextureLayout == null) m_DefaultTextureLayout = serializedObject.FindProperty(kDefaultTextureLayout);
            if (m_ImproveLegacyRenderingIssueOnHDR == null) m_ImproveLegacyRenderingIssueOnHDR = serializedObject.FindProperty(kImproveLegacyRenderingIssueOnHDR);

            serializedObject.Update();

            BuildTargetGroup selectedBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                EditorGUILayout.HelpBox("VRKit settings cannnot be changed when the editor is in play mode.", MessageType.Info);
                EditorGUILayout.Space();
            }

            bool isRestartNow = false;

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            if (selectedBuildTargetGroup == BuildTargetGroup.Switch)
            {
                EditorGUI.BeginDisabledGroup(true); // Note: Now single pass redering is not supported yet.
                EditorGUI.BeginChangeCheck();
                var stereoRenderingMode = (VRKitSettings.StereoRenderingMode)m_StereoRenderingMode.intValue;
                stereoRenderingMode = (VRKitSettings.StereoRenderingMode)EditorGUILayout.EnumPopup("StereoRenderingMode", stereoRenderingMode);
                if (EditorGUI.EndChangeCheck())
                {
                    m_StereoRenderingMode.intValue = (int)stereoRenderingMode;
                }
                EditorGUI.EndDisabledGroup();

                if (m_DefaultTextureLayout.intValue == 0)
                {
                    m_DefaultTextureLayout.intValue = (int)TextureLayout.SeparateTexture2Ds;
                }

#if true
#pragma warning disable 618
                {
                    if (s_TextureLayoutNames == null || s_TextureLayoutNames.Length == 0)
                    {
                        s_TextureLayoutNames = System.Enum.GetNames(typeof(TextureLayout));
                        for (int i = 0; i < s_TextureLayoutNames.Length; ++i)
                        {
                            if (s_TextureLayoutNames[i] == TextureLayout.SingleTexture2D.ToString())
                            {
                                s_TextureLayoutNames[i] += "(Experimental)";
                                break;
                            }
                        }
                    }
                    if (s_TextureLayoutValues == null || s_TextureLayoutValues.Length == 0)
                    {
                        s_TextureLayoutValues = System.Enum.GetValues(typeof(TextureLayout));
                    }

                    var textureLayoutLabel = new GUIContent("TextureLayout", "TextureLayout for XR Eyes Back Buffers");

                    int textureLayoutSelectedIndex = System.Array.IndexOf(s_TextureLayoutValues, (TextureLayout)m_DefaultTextureLayout.intValue);
                    if (textureLayoutSelectedIndex < 0)
                    {
                        textureLayoutSelectedIndex = System.Array.IndexOf(s_TextureLayoutValues, TextureLayout.SeparateTexture2Ds);
                        if (textureLayoutSelectedIndex < 0)
                        {
                            textureLayoutSelectedIndex = 0;
                        }
                    }

                    EditorGUI.BeginChangeCheck();
                    textureLayoutSelectedIndex = EditorGUILayout.Popup(textureLayoutLabel, textureLayoutSelectedIndex, s_TextureLayoutNames);
                    if ((TextureLayout)s_TextureLayoutValues.GetValue(textureLayoutSelectedIndex) == TextureLayout.SingleTexture2D)
                    {
                        EditorGUILayout.BeginHorizontal();
                        if (s_warningIcon == null)
                        {
                            s_warningIcon = new GUIContent("This option will cause the performance issue.", (Texture)EditorGUIUtility.Load("Warning"));
                        }
                        EditorGUILayout.LabelField(s_warningIcon);
                        EditorGUILayout.EndHorizontal();
                    }
                    if (EditorGUI.EndChangeCheck())
                    {
                        if (textureLayoutSelectedIndex >= 0 && textureLayoutSelectedIndex < s_TextureLayoutValues.Length)
                        {
                            m_DefaultTextureLayout.intValue = (int)(s_TextureLayoutValues.GetValue(textureLayoutSelectedIndex));
                        }
                    }
                }
#pragma warning restore 618
#else
                EditorGUILayout.PropertyField(m_DefaultTextureLayout, s_DefaultTextureLayout);
#endif

                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(m_ImproveLegacyRenderingIssueOnHDR, s_ImproveLegacyRenderingIssueOnHDR);
                if (s_ShouldBeRestarted)
                {
                    EditorGUILayout.TextArea("Should restart to prevent a missing shader on editor.");
                }

                if (EditorGUI.EndChangeCheck())
                {
                    var isEnabled = m_ImproveLegacyRenderingIssueOnHDR.boolValue;
                    VRKitPreprocess.PrefixLegacyInternalBlitCopy(isEnabled);
                    if (!isEnabled)
                    {
                        isRestartNow = EditorUtility.DisplayDialog("Restart", "Should restart to prevent a missing shader on editor. Do you need to restart now?", "OK", "Cancel");
                        if (!isRestartNow)
                        {
                            s_ShouldBeRestarted = true;
                        }
                    }
                    else
                    {
                        s_ShouldBeRestarted = false;
                    }
                }
            }
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndBuildTargetSelectionGrouping();

            serializedObject.ApplyModifiedProperties();

            if (isRestartNow)
            {
                Restart();
            }
        }

        static void Restart()
        {
            System.Diagnostics.Process.Start(EditorApplication.applicationPath);
            EditorApplication.Exit(0);
        }
    }
}
