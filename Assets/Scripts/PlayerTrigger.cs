using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public PlayerController player;

    private const string THROATS = "Throats";
    private const string FINISH = "Finish";

    private const string GROW = "Grow";
    private const string SHRINK = "Shrink";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GROW))
        {
            Destroy(other.gameObject);
            GrowthManager.instance.GrowUp();
        }
        else if (other.CompareTag(SHRINK))
        {
            Destroy(other.gameObject);
            GrowthManager.instance.GrowDown();
        }
        if (other.CompareTag(FINISH))
        {
            player.moveSpeed = 0;
            GameObject.Find(THROATS).GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
