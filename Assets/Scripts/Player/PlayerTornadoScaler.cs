using UnityEngine;
using UnityEngine.UI;

public class PlayerTornadoScaler : MonoBehaviour
{
    [SerializeField] ParticleSystem TornadoEffect;
    [SerializeField] private float minScale = 1f;
    [SerializeField] private float maxScale = 1.2f;
    [SerializeField] private PlayerManager playerManager;
    private void Awake()
    {
        if (TornadoEffect == null)
        {
            TornadoEffect = transform.Find("Tornado").GetComponent<ParticleSystem>();
        }

        if (playerManager == null)
        {
            playerManager = transform.parent.GetComponent<PlayerManager>();
        }
    }

    private void OnEnable()
    {
        GameEvent.OnUpdateMaxScale += OnLevelUP;
        GameEvent.OnUpdateFill += UpdateScale;
        GameEvent.OnResetFill += ResetScale;
    }

    private void OnDisable()
    {
        GameEvent.OnUpdateMaxScale -= OnLevelUP;
        GameEvent.OnUpdateFill -= UpdateScale;
        GameEvent.OnResetFill -= ResetScale;
    }

    private void UpdateScale()
    {
        float fillRatio = Mathf.Clamp01(
            (float)playerManager.Stats.currentSizeStore /
            (float)playerManager.Stats.maxSize);

        var main = TornadoEffect.main;
        main.startSize = Mathf.Lerp(minScale, maxScale, fillRatio);
        playerManager.Stats.SetCurrentSize(main.startSize.constant);
    }

    private void ResetScale()
    {
        var main = TornadoEffect.main;
        main.startSize = minScale;
        playerManager.Stats.SetCurrentSize(main.startSize.constant);
    }

    private void OnLevelUP()
    {
        maxScale += 0.3f;
    }
}
