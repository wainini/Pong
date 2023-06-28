using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform ballSpawnPointUp;
    [SerializeField] private Transform ballSpawnPointDown;
    [SerializeField] private Goal goalLeft;
    [SerializeField] private Goal goalRight;
    [SerializeField] private TextMeshProUGUI scoreTextLeft;
    [SerializeField] private TextMeshProUGUI scoreTextRight;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI pressSpace;
    [SerializeField] private Menu menu;

    [SerializeField] private float spawnBallDelay = 1.5f;

    public bool IsGameOver { get; private set; }

    private Transform[] ballSpawnPoints;
    private Vector2[] ballInitialDirections;
    private Dictionary<Transform, Vector2[]> spawnPointToInitialDirections;

    private Dictionary<int, int> goalScore;
    private Dictionary<int, TextMeshProUGUI> goalScoreText;

    private void Awake()
    {
        ballSpawnPoints = new Transform[]
        {
            ballSpawnPointUp,
            ballSpawnPointDown
        };
        ballInitialDirections = new Vector2[]
        {
            new Vector2(1,-1),
            new Vector2(-1,-1),
            new Vector2(1,1),
            new Vector2(-1,1)
        };
        spawnPointToInitialDirections = new Dictionary<Transform, Vector2[]>()
        {
            {ballSpawnPointUp,  new Vector2[] {ballInitialDirections[0], ballInitialDirections[1]}},
            {ballSpawnPointDown, new Vector2[] {ballInitialDirections[2], ballInitialDirections[3]}}
        };
        InitializeGame();
    }

    private void OnEnable()
    {
        goalLeft.OnGoal += IncreaseScore;
        goalRight.OnGoal += IncreaseScore;
        menu.OnStartGame += WaitForSpace;
    }

    private void OnDisable()
    {
        goalLeft.OnGoal -= IncreaseScore;
        goalRight.OnGoal -= IncreaseScore;
        menu.OnStartGame -= WaitForSpace;
    }

    private void Update()
    {
        if(pressSpace.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            IsGameOver = false;
            StartCoroutine(SpawnBall());
            pressSpace.gameObject.SetActive(false);
        }
    }

    private void InitializeGame()
    {
        IsGameOver = true;

        goalScore = new Dictionary<int, int>()
        {
            {0, 0},
            {1, 0}
        };
        goalScoreText = new()
        {
            {0, scoreTextLeft},
            {1, scoreTextRight}
        };
    }

    private void WaitForSpace()
    {
        pressSpace.gameObject.SetActive(true);
        InitializeGame();
    }

    private IEnumerator SpawnBall()
    {
        int randomSpawnPoint = Random.Range(0, 2);
        int randomInitialDirection = Random.Range(0, 2);
        yield return new WaitForSeconds(spawnBallDelay);

        Transform ballSpawnPoint = ballSpawnPoints[randomSpawnPoint];
        Vector2 ballInitialDirection = spawnPointToInitialDirections[ballSpawnPoint][randomInitialDirection];

        Ball ball = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
        ball.MoveDirection = ballInitialDirection;
    }

    private void IncreaseScore(int goal)
    {
        goalScore[goal] += 1;
        goalScoreText[goal].text = goalScore[goal].ToString();
        if (goalScore[goal] >= 11)
        {
            GameOver(goal);
        }
        else
        {
            StartCoroutine(SpawnBall());
        }
    }

    private void GameOver(int player)
    {
        IsGameOver = true;
        winMenu.SetActive(true);
        winText.text = $"Player {player + 1} Win!";
    }
}

