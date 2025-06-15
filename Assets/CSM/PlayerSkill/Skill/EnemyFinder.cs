using UnityEngine;

public static class EnemyFinder
{
    /// <summary>
    /// ���� ����� ���� ã���ϴ�.
    /// </summary>
    /// <param name="origin">���� ��ġ</param>
    /// <param name="range">Ž�� ����</param>
    /// <param name="enemyTag">�� �±�</param>
    /// <returns>���� ����� ���� Transform, ������ null</returns>
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
