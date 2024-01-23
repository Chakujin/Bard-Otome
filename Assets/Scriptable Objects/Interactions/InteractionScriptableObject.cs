using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewInteraction", menuName = "Interaction Scriptable Object")]
public class InteractionScriptableObject : ScriptableObject
{
    // Add last interaction text the question if can reply
    public string[] interactionTexts;
    public bool canReply = false;

    public Sprite characterInteraction;

    [Header ("IF CAN REPLY")]
    // If can reply
    public string[] replys;
    public InteractionScriptableObject nextInteraction;
}
