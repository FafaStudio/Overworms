using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(StatsStatus))]
public class StatsStatusInspector : StatusInspector
{
	StatsStatus statsStatus;

	[MenuItem("Assets/Create/Status/StatsStatus")]
	public static void CreateAsset ()
	{
        StatsStatus asset = ScriptableObject.CreateInstance<StatsStatus>();

        AssetDatabase.CreateAsset(asset, "Assets/Prefabs/Status/newStatsStatus.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
	}
	void onEnable(){
	}

	public override void OnInspectorGUI(){
		statsStatus = (StatsStatus)target;	       
		EditorGUI.BeginChangeCheck();

		base.status = (StatsStatus)target;
		base.OnInspectorGUI();
		statsStatus.value = EditorGUILayout.IntField("Value :", statsStatus.value);
		statsStatus.statType = (StatsStatus.listStatType)EditorGUILayout.EnumPopup("Stat ciblé:", statsStatus.statType);
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(base.status);
            EditorUtility.SetDirty(statsStatus);
        }
		//StatusInspector.OnInspectorGUI(statsStatus);
	}
}