using UnityEngine;

public interface ITrappable
{
    public bool TryDamage(int damageValue);

    public void Destroy(GameObject gameObject);
}
