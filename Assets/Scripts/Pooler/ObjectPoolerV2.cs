using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerV2 : MonoBehaviour
{
    public static Dictionary<string, Component> poolLookup = new Dictionary<string, Component>();
    public static Dictionary<string, Queue<Component>> poolDictionary = new Dictionary<string, Queue<Component>>();

    public static void EnqueueObject<T>(T item, string name) where T : Component
    {
        if (!item.gameObject.activeSelf)
        {
            return;
        }

        item.transform.position = Vector2.zero;
        poolDictionary[name].Enqueue(item);
        item.gameObject.SetActive(false);
        PutInHierarchy(item, name);

    }

    private static void PutInHierarchy<T>(T item, string name) where T : Component
    {
        GameObject pool = GameObject.Find($"{name} - (Pool)");
        if (pool == null)
        {
            pool = new GameObject($"{name} - (Pool)");
            pool.transform.SetAsFirstSibling();
        }
        item.transform.SetParent(pool.transform);
    }

    public static List<T> DequeueObjects<T>(string key) where T : Component
    {
        List<T> result = new List<T>();
        if (poolDictionary.ContainsKey(key))
        {
            while (poolDictionary[key].Count > 0)
            {
                result.Add(DequeuObject<T>(key));
            }
        }
        return result;
    }
    public static T DequeuObject<T>(string key) where T : Component
    {
        if (poolDictionary[key].TryDequeue(out var item))
        {

            item.gameObject.SetActive(true);
            return (T)item;
        }
        T instance = (T)EnqueueNewInstance(poolLookup[key], key);
        instance.gameObject.SetActive(true);
        item.transform.SetParent(null);
        //return null;
        return instance;
    }

    public static T EnqueueNewInstance<T>(T instance, string key) where T : Component
    {
        if (poolDictionary.ContainsKey(key))
        {
            EnqueueObject<T>(instance, key);
        }
        else
        {
            SetupPool(instance, key);
        }
        return instance;
    }

    private static void SetupPool<T>(T pooledInstance, string dictionaryEntry) where T : Component
    {

        poolDictionary.Add(dictionaryEntry, new Queue<Component>());
        poolLookup.Add(dictionaryEntry, pooledInstance);
        EnqueueObject<T>(pooledInstance, dictionaryEntry);
    }
}
