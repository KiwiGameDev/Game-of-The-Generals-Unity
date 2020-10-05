﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class EnemyAI : Actor
{
    [Header("Settings")]
    [SerializeField] private float thinkTime = 1.0f;

    private bool isThinking = false;

    public override void PerformSpawn()
    {
        if (isThinking)
            return;

        StartCoroutine(PerformSpawnLoop());
    }

    public override void PerformMove()
    {
        if (isThinking)
            return;

        StartCoroutine(PerformMoveLoop());
    }

    private IEnumerator PerformSpawnLoop()
    {
        isThinking = true;

        // TODO: Remove wait timer
        yield return new WaitForSeconds(thinkTime);
        // TODO: Smart spawning
        RandomizeSpawns();
        board.ConfirmSpawn();

        isThinking = false;
    }

    private IEnumerator PerformMoveLoop()
    {
        isThinking = true;

        // TODO: Remove wait timer
        yield return new WaitForSeconds(thinkTime);
        board.TryMove(GetMove());

        isThinking = false;
    }

    private MoveInfo GetMove()
    {
        // TODO: Enemy AI
        List<MoveInfo> allPossibleMoves = board.GetAllValidMoves(this);
        return allPossibleMoves[Random.Range(0, allPossibleMoves.Count)];
    }
}
