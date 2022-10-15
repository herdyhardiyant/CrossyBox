using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManipulator : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Player player;

    // Update is called once per frame
    void Update()
    {
        if (player.IsDie)
        {
            musicSource.Stop();
        }
    }
}
