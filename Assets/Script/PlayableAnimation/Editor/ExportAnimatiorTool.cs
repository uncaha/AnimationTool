using UnityEditor;
using UnityEngine;
using UnityEditor.Animations;

namespace AniPlayable
{
    public class ExportAnimatiorTool : EditorWindow
    {
        private AnimatorController exportObject;
        private string exportPath = "";
        private string selectPath = "";

        [MenuItem("AnimatorTool/AnimatorToAsset")]
        static void CreateWindow()
        {
            Rect rect = new Rect(0, 0, 300, 300);
            ExportAnimatiorTool window = GetWindowWithRect<ExportAnimatiorTool>(rect, true, "ExportAnimatiorTool");
            Selection.activeObject = null;
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("AnimatorController", EditorStyles.boldLabel);
            exportObject = EditorGUILayout.ObjectField("", exportObject, typeof(AnimatorController), true) as AnimatorController;

            DrawPath();

            if (GUILayout.Button("Export"))
            {
                if (exportObject)
                {
                    if (!string.IsNullOrEmpty(exportPath))
                    {
                        PlayableAnimatorUtil.GetInstance().ExportToAsset(exportPath, exportObject);
                        this.Close();
                    }
                }
                else
                {
                    Debug.LogError("必须选择要导出的AnimatorController.");
                }
            }
        }

        void DrawPath()
        {
            GUILayout.Label("ExportPath", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.TextField("", selectPath, EditorStyles.textField);
            if (GUILayout.Button("...", GUILayout.Width(25)))
            {

                string tpath = EditorUtility.OpenFolderPanel("Path select", selectPath, "");

                if (!string.IsNullOrEmpty(tpath))
                {
                    if (!tpath.Contains(Application.dataPath))
                    {
                        Debug.LogError("必须选择Assets下的目录。");
                    }
                    else
                    {
                        exportPath = tpath.Replace(Application.dataPath, "Assets");
                        selectPath = tpath;
                    }

                }
            }
            EditorGUILayout.EndHorizontal();
        }

        private void OnInspectorUpdate()
        {
            this.Repaint();
        }

        private void OnFocus()
        {
            
        }

        private void OnLostFocus()
        {
            
        }
    }
}
