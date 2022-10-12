using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    public static readonly int HalfRoadWidth = 6;
    public int Score => _score;
    private int _score;

    // Update is called once per frame
    void Update()
    {
        _score = player.MaxZReached;

    }
}
