using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;
using UnityEditor.SceneManagement;
using System.Linq;
using System.IO;

[CustomEditor(typeof(StatusController))]
public class StatusControllerInspector : Editor 
{
    Dictionary<Type, Action<Status>> connector;
    /*
	  	Dictionary<Type, Action<Status>> connector = new Dictionary<Type, Action<Status>> {
    { typeof(StatsStatus), (Status status) => StatsStatusInspector.OnInspectorGUI(status as StatsStatus)} 
};*/
StatusController statusController;

List<bool> foldouts;
    void OnEnable() {
        statusController = (StatusController)target;
        foldouts = new List<bool>();
        foldouts.AddRange(Enumerable.Repeat(false, statusController.statusList.Count));


    }
    public override void OnInspectorGUI()
    {
        //statusController.statusList = new List<Status>();
        DirectoryInfo info = new DirectoryInfo("Assets/Prefabs/Status");
        FileInfo[] fileInfo = info.GetFiles("*.asset");

        EditorGUI.BeginChangeCheck();
        
		for(var i = 0; i < statusController.statusList.Count; i++){

            EditorGUILayout.BeginVertical(new GUIStyle("box"));
            EditorGUILayout.TextField("Nom du status :", statusController.statusList[i].statusName);

            /*

            if (GUILayout.Button(statusController.statusList[i].statusName))
            {
                foldouts[i] = !foldouts[i];
            }

            if(foldouts[i]){
                connector[statusController.statusList[i].GetType()](statusController.statusList[i]);
            }   else    {
                
            }*/

            EditorGUILayout.EndVertical();
		}
        foreach (var file in fileInfo)
        {
            String filename = file.ToString().Substring(file.ToString().LastIndexOf("\\")+1);
            filename = filename.Substring(0, filename.LastIndexOf("."));
            if (GUILayout.Button("Add " + filename))
            {
                //EditorGUILayout.TextField("Nom du status :", fileInfo[i].ToString());

                statusController.statusList.Add((Status)AssetDatabase.LoadAssetAtPath(file.ToString().Substring(file.ToString().LastIndexOf("\\Overworms\\Overworms\\") + 21), typeof(Status)));
            }
        }


        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(statusController);
        }
    }
}