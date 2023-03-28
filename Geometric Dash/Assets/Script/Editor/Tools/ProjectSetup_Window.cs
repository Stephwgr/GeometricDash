using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace MyTools
{
    public class ProjectSetup_Window : EditorWindow
    {
        #region variable
        static ProjectSetup_Window win;
        #endregion 

        #region Main Method
        public static void InitWindow()
        {
            win = EditorWindow.GetWindow<ProjectSetup_Window>("Project Setup");
            win.Show();
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("Generate Object");
        }
        #endregion

    }



}
