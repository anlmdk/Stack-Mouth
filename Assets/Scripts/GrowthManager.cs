using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrowthManager : MonoBehaviour
{
    public static GrowthManager instance;

    [SerializeField]
    private float growthAmount = 1f;

    [SerializeField]
    private float shrinkAmount = 1f;

    [SerializeField]
    private float growthSpeed = 0.3f;

    [SerializeField]
    private float shrinkSpeed = 0.3f;

    [SerializeField]
    private GameObject growingObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void GrowUp()
    {
        // When character hit pie or donut
        float totalGrowthAmount = growingObject.transform.localScale.y + growthAmount;

        growingObject.transform.DOScaleY(totalGrowthAmount, growthSpeed);

        GameObject.Find("Top").GetComponent<Transform>().transform.DOMoveY(totalGrowthAmount - transform.localPosition.y, growthSpeed);

    }
    public void GrowDown()
    {
        // When character hit cactus
        float totalShrinkAmount = growingObject.transform.localScale.y - shrinkAmount;

        if (totalShrinkAmount <= 1)
        {
            // Game Over
            growingObject.transform.localScale = Vector3.one;
        }
        else
        {
            growingObject.transform.DOScaleY(totalShrinkAmount, shrinkSpeed);

            GameObject.Find("Top").GetComponent<Transform>().transform.DOMoveY(totalShrinkAmount, shrinkSpeed);
        }
    }
}
