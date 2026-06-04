using UnityEngine;

public class PlayerStats
{
    public float currentMoveSpeed { get; private set; } = 3f;
    public int Suction { get; private set; } = 20;
    public int suctionRadius { get; private set; } = 5;
    public int maxSize { get; private set; } = 10;
    public float currentSize { get; private set; } = 1;
    public float currentSizeStore { get; private set; } = 0;
    public float sizeMultiplier { get; private set; } = 0.1f;
    public float Gold { get; private set; } = 0;
    public float goldMultiplier { get; private set; } = 1;

    public void LoadFromPrefs()
    {
        Gold = PlayerPrefs.GetFloat("Gold", 0);
        maxSize = PlayerPrefs.GetInt("MaxSize", 10);
        currentSize = PlayerPrefs.GetFloat("CurrentSize", 1);
        currentSizeStore = PlayerPrefs.GetFloat("CurrentSizeStore", 0);
        currentMoveSpeed = PlayerPrefs.GetFloat("CurrentMoveSpeed", 3f);
        goldMultiplier = PlayerPrefs.GetFloat("GoldMultiplier", 1f);
        Debug.Log(this);
    }

    public void IncreaseCurrentSizeStore(float amount)
    {
        if (currentSizeStore < maxSize)
        {
            currentSizeStore += amount;
            if (currentSizeStore > maxSize)
            {
                currentSizeStore = maxSize;
            }
            PlayerPrefs.SetFloat("CurrentSizeStore", currentSizeStore);
        }
    }

    public void SetCurrentSize(float amount)
    {
        currentSize = amount;
        PlayerPrefs.SetFloat("CurrentSize", currentSize);
    }

    public void ResetCurrentSizeStore()
    {
        currentSizeStore = 0;
        PlayerPrefs.SetFloat("CurrentSizeStore", currentSizeStore);
    }

    public void SetMaxSize(int newMaxSize)
    {
        maxSize = newMaxSize;
        PlayerPrefs.SetInt("MaxSize", maxSize);
    }

    public void SetMoveSpeed(float newMoveSpeed)
    {
        currentMoveSpeed = newMoveSpeed;
        PlayerPrefs.SetFloat("CurrentMoveSpeed", currentMoveSpeed);
    }

    public void SetGoldMultiplier(float newGoldMultiplier)
    {
        goldMultiplier = newGoldMultiplier;
        PlayerPrefs.SetFloat("GoldMultiplier", goldMultiplier);
    }

    public void AddGold(int amount)
    {
        Gold = Gold + amount * goldMultiplier;
        GameEvent.UpdateGoldText((int)Gold);
        PlayerPrefs.SetFloat("Gold", Gold);
    }

    public void SpendGold(int amount)
    {
        if (Gold >= amount)
        {
            Gold -= amount;
            PlayerPrefs.SetFloat("Gold", Gold);
        }
    }

    public float PlayerPower()
    {
        return Suction * Mathf.Pow(currentSize, 0.7f);
    }
}
