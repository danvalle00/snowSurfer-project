using UnityEngine;

public class CharSelection : MonoBehaviour
{

    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private GameObject dinoChar;
    [SerializeField] private GameObject frogChar;
    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void BeginGame()
    {
        scoreCanvas.SetActive(true);
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
        dinoChar.SetActive(true);
        BeginGame();
    }

    public void ChooseFrog()
    {
        frogChar.SetActive(true);
        BeginGame();
    }
}
