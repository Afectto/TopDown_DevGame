using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnStatBuff : MonoBehaviour
{
    [SerializeField] private StatsBuffPickup statsBuffPickupPrefab;
    private List<BuffStats> _buffStates;

    private void Awake()
    {
        _buffStates = Resources.LoadAll<BuffStats>("ScriptableObject/Buff").ToList();
        StartCoroutine(SpawnBuffStats());
    }

    private IEnumerator SpawnBuffStats()
    {
        while (true)
        {
            yield return new WaitForSeconds(27);

            int randomIndex = Random.Range(0, _buffStates.Count);
                
            var position = Utils.GetRandomPositionInCamera();
            var pickup = Instantiate(statsBuffPickupPrefab, position, Quaternion.identity);
            pickup.Initialize(_buffStates[randomIndex]);
        }
        // ReSharper disable once IteratorNeverReturns
    }
}
