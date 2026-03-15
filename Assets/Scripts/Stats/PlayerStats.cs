using UnityEngine;

public class PlayerStats
{
    public int currentMoveSpeed { get; private set; } = 1;
    public int maxMoveSpeed { get; private set; } = 5;
    public int Suction { get; private set; } = 1;
    public int suctionRadius { get; private set; } = 5;
    public int maxSize { get; private set; } = 10;
    public int currentSize { get; private set; } = 1;
    public int sizeMultiplier { get; private set; } = 1;
    public int Gold { get; private set; } = 0;
    public int goldMultiplier { get; private set; } = 1;

    public void IncreaseCurrentSize(int amount)
    {
        if(currentSize < maxSize)
        {
            currentSize += amount;
            Debug.Log("Current Size after increase: " + currentSize);
            if(currentSize > maxSize)
            {
                currentSize = maxSize;
            }
        }
        else
            Debug.Log("Player is already at max size.");
    }
}
