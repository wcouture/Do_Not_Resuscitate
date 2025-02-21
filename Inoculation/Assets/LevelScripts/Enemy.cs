using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int strength = 10;

    private int currentWaypointIndex = 0;

    public float getSpeed() { return speed / 10; }
    public int getHealth() { return health; }
    public int getStrength() { return strength; }
    
    public Renderer renderer;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public void damage(int damagetaken)
    {
        audioManager.PlaySFX(audioManager.EnemyHit);
        health -= damagetaken;
    }

    public void destroyEnemy()
    {
        audioManager.PlaySFX(audioManager.EnemyDeath);
        GameObject.Destroy(this.gameObject);
    }

    public int getWaypointIndex() { return currentWaypointIndex; }
    public void nextWaypointIndex() { currentWaypointIndex += 1; }
    public void move(Vector2 newPosition)
    {
        this.transform.position = newPosition;
        renderer.sortingOrder = renderer.sortingOrder++;
    }


}