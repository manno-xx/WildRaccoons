using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Generic status bar. Could be used as a health bar, a stamina bar etc.
/// </summary>
public class StatusBar : MonoBehaviour
{
    // define the gradient
    [SerializeField] private Gradient barColor;
    
    // contains a reference to the image of the stats bar
    private Image statsBar;
    
    /// <summary>
    /// Make sure the statsBar contains a reference to the UI Image
    /// </summary>
    void Awake()
    {
        statsBar = GetComponent<Image>();
    }
    
    /// <summary>
    /// Update the width (fillAmount) and color of the image
    /// </summary>
    /// <param name="percentage">the percentage / fraction to use for the fillAmount and color evaluation</param>
    public void UpdateBar(float percentage)
    {
        // change the fillamount of the image
        statsBar.fillAmount = percentage;
        // change the color of the image
        statsBar.color = barColor.Evaluate(percentage);
    }
}
