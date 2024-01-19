using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest Scriptable Object")]
public class QuestScriptableObject : ScriptableObject
{
    public string questName;
    public string questDescription;
    public SceneAsset questLevel;
}
