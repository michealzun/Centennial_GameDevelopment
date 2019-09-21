using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SelectableItem", menuName = "Selectable/SelectableItem")]
public class SelectableItem : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public int itemId;
    [TextArea]
    public string description;
}
