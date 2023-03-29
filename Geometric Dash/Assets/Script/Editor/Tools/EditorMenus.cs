using UnityEngine;
using UnityEditor;

namespace MyTools
{
    public class EditorMenus
    {
        [MenuItem("MyTools/Project/ Generate Obj")]
        public static void InitProjectSetupTool()
        {
            ProjectSetup_Window.InitWindow();
        }

    }
}