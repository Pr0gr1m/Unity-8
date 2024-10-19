using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    public Texture OutputImageTexture;
    public ItemTypes OutputItemType;
    public List<ItemTypes> craftingInputItems;
}
