using UnityEngine;
using UnityEngine.UI;
public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private GameObject previousPanel;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        if(exitButton == null)
        {
            exitButton = GetComponentInChildren<Button>();
        }
    }

    private void Start()
    {
        exitButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        currentPanel.SetActive(false);
        if(previousPanel != null)
        {
            previousPanel.SetActive(true);
        }
    }
}
