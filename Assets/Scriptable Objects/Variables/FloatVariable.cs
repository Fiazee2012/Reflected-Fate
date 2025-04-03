using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Scriptable Objects/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    public float Value;

    //To add adescription box in the editor
    [TextAreaAttribute]
    public string Description = "Description";
}
