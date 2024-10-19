using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingPanel : MonoBehaviour
{
    [SerializeField] private GameObject PrefabUIItem;
    [SerializeField] private InventorySlot outputSlot;

    [SerializeField] private List<Recipe> RegisteredRecipes = new List<Recipe>();
    [SerializeField] private List<InventorySlot> craftingSlots = new List<InventorySlot>();

    private void Update()
    {
        foreach (Recipe recipe in RegisteredRecipes)
        {
            if(IsRecipeMatching(recipe))
            {
                ClearAllCraftingSlots();
                PutItemIntoOutputSlot(recipe.OutputItemType, recipe.OutputImageTexture, "EE");
            }
        }
    }

    private void PutItemIntoOutputSlot(ItemTypes itemType, Texture imageTexture,string Description)
    {
        GameObject itemObject = Instantiate(PrefabUIItem);
        UIItem UIItemComponent = itemObject.GetComponent<UIItem>();

        outputSlot.savedUIItem = UIItemComponent;

        itemObject.gameObject.transform.parent = outputSlot.transform.parent;
        itemObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        itemObject.GetComponent<RawImage>().texture = imageTexture;
        itemObject.GetComponent<RectTransform>().anchoredPosition = outputSlot.GetComponent<RectTransform>().anchoredPosition;

        UIItemComponent.parentInventorySlot = outputSlot;
        UIItemComponent.ItemType = itemType;
        UIItemComponent.Description = Description;
    }

    private void ClearAllCraftingSlots()
    {
        foreach(InventorySlot slot in craftingSlots)
        {
            if(slot.savedUIItem) Destroy(slot.savedUIItem.gameObject);
            slot.savedUIItem = null;
        }
    }

    private bool IsRecipeMatching(Recipe recipe)
    {
        int index = 0;

        foreach (InventorySlot slot in craftingSlots)
        {
            ItemTypes neededItemType = recipe.craftingInputItems[index];
            ItemTypes type1;

            if (slot.savedUIItem)
            {
                type1 = slot.savedUIItem.ItemType;
            }
            else
            {
                type1 = ItemTypes.None;
            }


            if (type1 != neededItemType)
            {
                return false;
            }

            index += 1;
        }

        return true;
    }
}
