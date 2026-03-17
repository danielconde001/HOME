using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats current;

    [SerializeField] private int totalFuel = 3;
    [SerializeField] private float deathDelay = 3.0f;

    private int currentFuel = 0;
    public int GetCurrentFuel() {return currentFuel;}
    public void UseFuel() 
    {
        currentFuel--;

        if(currentFuel <= 0)
            StartCoroutine(DeathTimer());
    }

    private void Awake()
    {
        current = this;
        currentFuel = totalFuel;
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(deathDelay);
        PlayerHealth.current.Die();
    }
}
