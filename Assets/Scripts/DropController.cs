using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    [SerializeField] private PoolItemType[] dropItems;

    private float dropPeriod = 2f; // Drop aralığı
    private float startWaiting = 1f;
    private bool isGameplayState;
    private Coroutine dropCoroutine;

    float xBoundary = 2.5f;
    float yBoundary = 7f; // Dropun düşme yüksekliği

    private void OnEnable()
    {
        isGameplayState = true;
        dropCoroutine = StartCoroutine(createDrop(dropPeriod));
    }

    private void OnDisable()
    {
        isGameplayState = false;
        StopCoroutine(dropCoroutine);
    }

    private IEnumerator createDrop(float creationWaiting)
    {
        yield return new WaitForSeconds(startWaiting);

        WaitForSeconds wait = new WaitForSeconds(creationWaiting);

        while (true)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-xBoundary, xBoundary), yBoundary, 0);
            ObjectPooler.Instance.getFromPool(dropItems[Random.Range(0, dropItems.Length)], randomPosition, Quaternion.identity);

            yield return wait;
        }

    }
}
