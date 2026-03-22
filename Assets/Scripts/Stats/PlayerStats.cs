using UnityEngine;

public class PlayerStats
{
    public int currentMoveSpeed { get; private set; } = 1;
    public int maxMoveSpeed { get; private set; } = 5;
    public int Suction { get; private set; } = 5;
    public int suctionRadius { get; private set; } = 5;
    public int maxSize { get; private set; } = 10;
    public int currentSize { get; private set; } = 1;
    public int currentSizeStore { get; private set; } = 0;
    public float sizeMultiplier { get; private set; } = 0.1f;
    public int Gold { get; private set; } = 0;
    public int goldMultiplier { get; private set; } = 1;

    public void IncreaseCurrentSizeStore(int amount)
    {
        if(currentSizeStore < maxSize)
        {
            currentSizeStore += amount;
            if (currentSizeStore > maxSize)
            {
                currentSizeStore = maxSize;
            }
        }
        else
            Debug.Log("Player is already at max size.");
    }

    public void ResetCurrentSizeStore()
    {
        currentSizeStore = 0;
    }

    public void AddGold(int amount)
    {
        Gold = (Gold + amount) * goldMultiplier;
    }
}
