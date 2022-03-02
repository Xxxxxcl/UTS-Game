using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController _instance;
    public Text rescued;
    public Text hellcopter;
    public int resCount = 0;
    public int hellcopterCount = 0;
    public List<GameObject> allCounts;
    public int batchCount = 0;

    public List<GameObject> allBoxCounts;

    public GameObject winPanel, losePanel;
    public Player player;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        batchCount = Random.Range(16, 32);
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (batchCount <= 0)
        {
            winPanel.gameObject.SetActive(true);
            player.enabled = false;
        }
    }

    public void Init()
    {
        rescued.text = "Solders Rescued: " + resCount;
        hellcopter.text = "Solders In Hellcopter: " + hellcopterCount;
    }

    public void RescueSoldier()
    {
        hellcopterCount++;
        Init();
    }

    public void DropSoldier()
    {
        resCount += hellcopterCount;
        hellcopterCount = 0;
        Init();
        for (int i = 0; i < allCounts.Count; i++)
        {
            allCounts[i].gameObject.SetActive(true);
        }
        batchCount--;
        for (int i = 0; i < allBoxCounts.Count; i++)
        {
            allBoxCounts[i].gameObject.SetActive(false);
        }
        ShowBox();
    }

    public void GameOver()
    {
        losePanel.gameObject.SetActive(true);
        player.enabled = false;
    }

    private void ShowBox()
    {
        int value = Random.Range(0, 100);
        if (value >= 50)
        {
            allBoxCounts[Random.Range(0,allBoxCounts.Count)].gameObject.SetActive(true);

        }
    }
}
