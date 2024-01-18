using UnityEngine;

[CreateAssetMenu(fileName = "New Answer", menuName ="Answer Scriptable Object")]
public class AnswersScriptableObject : ScriptableObject
{
    public  string description;

    public int Wisdom;
    public int Inteligence;
    public int Constitution;
    public int Charisma;
    public int Dexterity;
    public int Strength;

    public void AddStats(GameManager gameManager)
    {
        gameManager.Wisdom += Wisdom;
        gameManager.Inteligence += Inteligence;
        gameManager.Constitution += Constitution;
        gameManager.Charisma += Charisma;
        gameManager.Dexterity += Dexterity;
        gameManager.Strength += Strength;
    }
}
