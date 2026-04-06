using UnityEngine;

public class PlayerStats
{
    public float currentMoveSpeed { get; private set; } = 1;
    public int maxMoveSpeed { get; private set; } = 5;
    public int Suction { get; private set; } = 5;
    public int suctionRadius { get; private set; } = 5;
    public int maxSize { get; private set; } = 10;
    public int currentSize { get; private set; } = 1;
    public int currentSizeStore { get; private set; } = 0;
    public float sizeMultiplier { get; private set; } = 0.1f;
    public int Gold { get; private set; } = 1000000;
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

    public void SetMaxSize(int newMaxSize)
    {
        maxSize = newMaxSize;
    }   

    public void SetMoveSpeed(float newMoveSpeed)
    {
        currentMoveSpeed = newMoveSpeed;
    }

    public void SetGoldMultiplier(int newGoldMultiplier)
    {
        goldMultiplier = newGoldMultiplier;
    }   

    public void AddGold(int amount)
    {
        Gold = Gold + amount * goldMultiplier;
        Debug.Log("Added " + amount * goldMultiplier + " gold. Total gold: " + Gold);
        Debug.Log("Current gold multiplier: " + goldMultiplier);

        GameEvent.UpdateGoldText(Gold);
    }

    public void SpendGold(int amount)
    {
        if (Gold >= amount)
        {
            Gold -= amount;
        }
        else
        {
            Debug.Log("Not enough gold to spend.");
        }
    }
}
