
using UnityEngine;
using UnityEditor;

public class ObjectSpawner : EditorWindow
{
    string _objectBaseName = "";
    int _objectID;
    GameObject _objectToSpawn;
    float _objectScale;
    float _spawnRadius;

    [MenuItem("My Tools/Object Spawner")]

    public static void ShowWindow()
    {
        GetWindow(typeof(ObjectSpawner));
    }

    private void OnGUI()
    {
        GUILayout.Label("Generate New Object", EditorStyles.boldLabel);

        _objectBaseName = EditorGUILayout.TextField("Base Name", _objectBaseName);
        _objectID = EditorGUILayout.IntField("Object ID", _objectID);
        _objectScale = EditorGUILayout.Slider("Object Scale", _objectScale, 0.5f, 10f);
        _spawnRadius = EditorGUILayout.Slider("Spawn Radius", _spawnRadius, 0f, 100f);
        _objectToSpawn = EditorGUILayout.ObjectField("Prefab To Spawn", _objectToSpawn, typeof(GameObject), false) as GameObject;

        GUILayout.Space(20);

        GUIStyle _buttonStyle = new GUIStyle(GUI.skin.button);
        //Color Button
        _buttonStyle.active.background = MakeTex(1, 1, Color.green);
        // _buttonStyle.normal.background = MakeTex(1, 1, Color.gray);

        //Size Button && font
        _buttonStyle.fontSize = 12;
        _buttonStyle.fixedHeight = 30;
        _buttonStyle.fixedWidth = 400;

        //Center Button in Window
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();


        if (GUILayout.Button("Spawn Object", _buttonStyle))
        {
            SpawnObject();

        }

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

    public void SpawnObject()
    {
        if (_objectToSpawn == null)
        {
            Debug.Log("Error: Please assign an object to be spawned.");
            return;
        }

        if (_objectBaseName == string.Empty)
        {
            Debug.Log("Error: Please enter a base name for the object.");
            return;
        }



        Vector2 _spawnCircle = Random.insideUnitCircle * _spawnRadius;
        Vector3 _spawnPos = new Vector3(_spawnCircle.x, 0f, _spawnCircle.y);

        GameObject newObject = Instantiate(_objectToSpawn, _spawnPos, Quaternion.identity);
        newObject.name = _objectBaseName + _objectID;
        newObject.transform.localScale = Vector3.one * _objectScale;

        _objectID++;
    }

    private Texture2D MakeTex(int wight, int height, Color color)
    {
        Color[] pix = new Color[wight * height];
        for (int i = 0; i < pix.Length; i++)
        {
            pix[i] = color;
        }
        Texture2D result = new Texture2D(wight, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }


}
