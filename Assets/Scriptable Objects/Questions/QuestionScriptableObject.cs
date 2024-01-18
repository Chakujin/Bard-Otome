using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName ="Question Scriptable Object")]
public class QuestionScriptableObject : ScriptableObject
{
    public string QuestionsDescription;
    public AnswersScriptableObject[] Answers;
}
