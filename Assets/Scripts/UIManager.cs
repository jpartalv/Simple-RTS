using TMPro;
using UnityEngine;

/// <summary>
/// Class that will define the in-game UI behavior
/// </summary>
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;

    // Start is called before the first frame update
    void Start()
    {
        PlayerName.text = GlobalVariables.PLAYER_NAME;        
    }
}
