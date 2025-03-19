using UnityEngine;

[CreateAssetMenu(fileName = "New Generic Item", menuName = "Items/Generic Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    public virtual void UseItem(GameObject player)
    {
        Debug.Log("Used Item");
    }
}
