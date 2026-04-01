using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/UpgradeData")]
public class UpgradeSO : ScriptableObject
{
    [Header("MaxSize")]
    public int baseMaxSize = 100;
    public float maxSizeCoefficient = 1.22f;
    public int baseMaxSizeCost = 100;
    public float maxSizeCoefficientCost = 1.2f;

    [Header("GoldMultiplier")]
    public int baseGoldMultiplierCost = 100;
    public float goldMultiplierCoefficientCost = 1.45f;
    public float goldMultiplier = 1.3f;

    public int baseGoldMultiplier = 1;
    public float goldMultiplierAmplitude = 0.3f;
    public float goldMultiplierCurve = 0.95f;

    [Header("MoveSpeed)")]
    public int baseMoveSpeedCost = 100;
    public float moveSpeedCoefficientCost = 1.38f;
    public float moveSpeedMultiplier = 1.1f;
    public int baseMoveSpeed = 1;

    public int baseMoveSpeedMultiplier = 1;
    public float moveSpeedAmplitude = 0.06f;
    public int maxMoveSpeed = 5;

    [Header("SizeMultiplier")]
    public int baseSizeMultiplierCost = 100;
    public float sizeMultiplierCoefficientCost = 1.45f;
    public float sizeMultiplier = 1.25f;

    public int baseSizeMultiplier = 1;
    public float sizeMultiplierAmplitude = 0.15f;
    public float sizeMultiplierCoefficient = 0.8f;

    public int GetMaxSizeCost(int level)
    {
        return Mathf.RoundToInt(baseMaxSizeCost * Mathf.Pow(maxSizeCoefficientCost, level));
    }

    public int GetMaxSizeValue(int level)
    {
        return Mathf.RoundToInt(baseMaxSize * Mathf.Pow(maxSizeCoefficient, level));
    }

    public int GetGoldMultiplierCost(int level)
    {
        return Mathf.RoundToInt(baseGoldMultiplierCost * goldMultiplier * Mathf.Pow(goldMultiplierCoefficientCost, level));
    }

    public float GetGoldMultiplierValue(int level)
    {
        return baseGoldMultiplier + goldMultiplierAmplitude * Mathf.Pow(level, goldMultiplierCurve);
    }

    public int GetMoveSpeedCost(int level)
    {
        return Mathf.RoundToInt(baseMoveSpeedCost * moveSpeedMultiplier * Mathf.Pow(moveSpeedCoefficientCost, level));
    }

    public float GetMoveSpeedValue(int level)
    {
        return Mathf.Min(maxMoveSpeed, baseMoveSpeed * (1 + moveSpeedAmplitude * level));
    }

    public int GetSizeMultiplierCost(int level)
    {
        return Mathf.RoundToInt(baseSizeMultiplierCost * sizeMultiplier * Mathf.Pow(sizeMultiplierCoefficientCost, level));
    }

    public float GetSizeMultiplierValue(int level)
    {
        return 1 + sizeMultiplierAmplitude * Mathf.Pow(level, sizeMultiplierCoefficient);
    }
}

public enum UpgradeType
{
    MaxSize,
    GoldMultiplier,
    MoveSpeed
}