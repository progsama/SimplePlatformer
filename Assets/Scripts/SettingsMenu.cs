using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject mainSettingsPanel;
    [SerializeField] private Slider playerSpeedSlider;

    [Header("Player")]
    [SerializeField] private PlayerController player;

    private void Start()
    {
        // Show menu at start
        ShowMenu(true);

        // Initialize slider to current player speed
        if (playerSpeedSlider != null && player != null)
            playerSpeedSlider.value = player.speed;
    }

    private void Update()
    {
        // ESC toggles the menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isOpen = mainSettingsPanel != null && mainSettingsPanel.activeSelf;
            ShowMenu(!isOpen);
        }
    }

    public void OnPlayClicked()
    {
        ShowMenu(false);
    }

    public void OnExitClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // MUST be float to receive slider value
    public void OnSpeedChanged(float value)
    {
        if (player != null)
            player.SetSpeed(value);
    }

    public void ShowMenu(bool show)
    {
        if (mainSettingsPanel != null)
            mainSettingsPanel.SetActive(show);

        Time.timeScale = show ? 0f : 1f;
    }
}
