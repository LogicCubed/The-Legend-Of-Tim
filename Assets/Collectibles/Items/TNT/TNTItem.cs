using UnityEngine;

[CreateAssetMenu(fileName = "New TNT", menuName = "Items/TNT")]
public class TestTNTItem : Item
{
    public GameObject TNT;

    public override void UseItem(GameObject player)
    {
            Vector3 spawnPosition = player.transform.position;
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(TNT, spawnPosition, spawnRotation);
    }
}