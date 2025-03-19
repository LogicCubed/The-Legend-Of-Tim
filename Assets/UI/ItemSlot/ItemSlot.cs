using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image SlotDisplay;
    public Item currentItem;

    void Start()
    {
        SlotDisplay.enabled = false;
    }

    void Update()
    {
        UseItem();
    }

    public void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.UseItem(GameObject.FindGameObjectWithTag("Player"));
            SlotDisplay.enabled = false;
        }
    }

    public void SetItem(Item newItem)
    {
        currentItem = newItem;

        SlotDisplay.sprite = newItem.itemIcon;
        SlotDisplay.enabled = true;
    }

}
