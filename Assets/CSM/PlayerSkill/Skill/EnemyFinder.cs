using UnityEngine;

public static class EnemyFinder
{
    /// <summary>
    /// 가장 가까운 적을 찾습니다.
    /// </summary>
    /// <param name="origin">시작 위치</param>
    /// <param name="range">탐색 범위</param>
    /// <param name="enemyTag">적 태그</param>
    /// <returns>가장 가까운 적의 Transform, 없으면 null</returns>
    public static Transform FindNearestEnemy(Vector2 origin, float range, string enemyTag = "Enemy")
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(origin, range);
        Transform closest = null;
        float minDist = float.MaxValue;

        foreach (var hit in hits)
        {
            if (!hit.CompareTag(enemyTag)) continue;

            float dist = Vector2.SqrMagnitude((Vector2)hit.transform.position - origin);
            if (dist < minDist)
            {
                minDist = dist;
                closest = hit.transform;
            }
        }

        return closest;
    }
}
