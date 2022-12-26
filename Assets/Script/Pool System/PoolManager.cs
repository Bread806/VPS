using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] playerWeaponPools;

    static Dictionary<GameObject, Pool> dictionary;

    void Awake(){
        dictionary = new Dictionary<GameObject, Pool>();

        Initialize(playerWeaponPools);
    }

     #if UNITY_EDITOR
    void OnDestroy(){
        CheckPoolSize(playerWeaponPools);
    }
    #endif

    void CheckPoolSize(Pool[] pools){
        foreach(var pool in pools){
            if(pool.RuntimeSize > pool.Size){
                 Debug.LogWarning(
                    string.Format("Pool: {0} has a runtime size {1} bigger than its initial size {2}!",
                    pool.Prefab.name,
                    pool.RuntimeSize,
                    pool.Size));
            }
        }
    }

    void Initialize(Pool[] pools){
        foreach (var pool in pools){
        #if UNITY_ESITOR
            if(dictionary.ContainsKey(pool.Prefab)){
                Debug.Debug.LogError("Same prefab in multiple pools! Prefab: " + pool.Prefab.name);

                continue;
            }
        #endif

            dictionary.Add(pool.Prefab, pool);
        
            Transform poolParent = new GameObject("Pool: " + pool.Prefab.name).transform;

            poolParent.parent = transform;
            pool.Initialize(poolParent);
        }
    }

    public static GameObject Release(GameObject prefab){
        #if UNITY_ESITOR
        if(!dictionary.ContainsKey(prefab)){
            Debug.LogError("Pool Manager could NOT find prefab: " + prefab.name);

            return null;
        }
        #endif
        return dictionary[prefab].prepareObject();
    }

    public static GameObject Release(GameObject prefab, Vector3 position){
        #if UNITY_ESITOR
        if(!dictionary.ContainsKey(prefab)){
            Debug.LogError("Pool Manager could NOT find prefab: " + prefab.name);

            return null;
        }
        #endif
        return dictionary[prefab].prepareObject(position);
    }

    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation){
        #if UNITY_ESITOR
        if(!dictionary.ContainsKey(prefab)){
            Debug.LogError("Pool Manager could NOT find prefab: " + prefab.name);

            return null;
        }
        #endif
        return dictionary[prefab].prepareObject(position, rotation);
    }

    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 localScale){
        #if UNITY_ESITOR
        if(!dictionary.ContainsKey(prefab)){
            Debug.LogError("Pool Manager could NOT find prefab: " + prefab.name);

            return null;
        }
        #endif
        return dictionary[prefab].prepareObject(position, rotation, localScale);
    }
}
