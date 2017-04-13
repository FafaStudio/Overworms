using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Status))]
public class StatusInspector : Editor
{
	public Status status;

    public override void OnInspectorGUI(){
		status.statusName = EditorGUILayout.TextField("Nom du status :", status.statusName);
		status.duration = EditorGUILayout.IntField("Duration :", status.duration);
	}
}
