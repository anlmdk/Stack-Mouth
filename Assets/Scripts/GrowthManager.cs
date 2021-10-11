using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrowthManager : MonoBehaviour, ITransformable
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
    private GameObject growingObject, headObject;

    private float headGrowthTargetConstant, headShrinkTargetConstant;

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
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose);

        headGrowthTargetConstant = (headObject.transform.localPosition.y - growingObject.transform.localPosition.y) * growthAmount;
        headShrinkTargetConstant = (headObject.transform.localPosition.y - growingObject.transform.localPosition.y) * shrinkAmount;
    }
    public void Grow()
    {
        // When character hit pie or donut
        float totalGrowthAmount = growingObject.transform.localScale.y + growthAmount;
        float headTargetPosition = headObject.transform.localPosition.y + headGrowthTargetConstant;

        growingObject.transform.DOScaleY(totalGrowthAmount, growthSpeed);
        headObject.transform.DOLocalMoveY(headTargetPosition, growthSpeed);
    }
    public void Shrink()
    {
        // When character hit cactus
        float totalShrinkAmount = growingObject.transform.localScale.y - shrinkAmount;
        float headTargetPosition = headObject.transform.localPosition.y - headShrinkTargetConstant;

        if (totalShrinkAmount <= 1 && headTargetPosition <= 1)
        {
            // Game Over
            growingObject.transform.localScale = Vector3.one;
        }
        else
        {
            growingObject.transform.DOScaleY(totalShrinkAmount, shrinkSpeed);
            headObject.transform.DOLocalMoveY(headTargetPosition, shrinkSpeed);
        }
    }
}
