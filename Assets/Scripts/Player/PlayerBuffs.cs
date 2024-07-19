using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffs : MonoBehaviour
{
    private List<IBuff> _activeBuffs = new List<IBuff>();
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        EventManager.Instance.OnPickupBuff += ApplyBuff;
    }
    
    private void ApplyBuff(BuffStats buff)
    {
        IBuff newBuff = buff.CreateBuff();
        newBuff.Apply(_player);
        _activeBuffs.Add(newBuff);
        StartCoroutine(BuffDuration(buff));
    }

    private void RemoveBuff(BuffStats buff)
    {
        IBuff buffToRemove = _activeBuffs.Find(b => b.GetType() == buff.CreateBuff().GetType());
        if (buffToRemove != null)
        {
            buffToRemove.Remove(_player);
            _activeBuffs.Remove(buffToRemove);
        }
    }

    private IEnumerator BuffDuration(BuffStats buff)
    {
        yield return new WaitForSeconds(buff.Duration);
        RemoveBuff(buff);
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnPickupBuff -= ApplyBuff;
    }
}
