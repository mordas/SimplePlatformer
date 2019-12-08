using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
other.GetComponent<Player>().CountScore(1);
Destroy(gameObject);
        }
    }
}
