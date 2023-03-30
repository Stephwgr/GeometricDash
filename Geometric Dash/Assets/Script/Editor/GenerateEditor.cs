using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenerateObjects))]
public class GenerateEditor : Editor
{
    public override void OnInspectorGUI()
    {

        
        DrawDefaultInspector();

        GenerateObjects _obj = (GenerateObjects)target;


        #region  Design Button

        GUILayout.Space(30);
        
        GUIStyle _buttonStyle = new GUIStyle(GUI.skin.button);
        _buttonStyle.normal.background = MakeTex(2, 2, new Color(0.1f, 0.5f, 0.1f));

        GUIStyle _buttonStyle1 = new GUIStyle(GUI.skin.button);
        _buttonStyle1.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f));
        


        if (GUILayout.Button("Generate Object Random", _buttonStyle))
        {
            _obj.GenerateObject();
        }

        GUILayout.Space(10);

        if (GUILayout.Button("Destroy Object ", _buttonStyle1))
        {
            _obj.DestroyLastObj();
        }

        #endregion

        // if (GUILayout.Button("Generate Objects", _buttonStyle))
        // {
        //     _obj.GenerateObject();
        // }
    }

    private Texture2D MakeTex(int wight, int height, Color color)
    {
        Color[] pix = new Color[wight * height];
        for(int i =0; i < pix.Length; i++)
        {
            pix[i] = color;
        }
        Texture2D result = new Texture2D(wight, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

}
