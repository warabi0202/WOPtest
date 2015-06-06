using UnityEngine;
using System.Collections;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T instance;
	/**
    Returns the instance of this singleton.
    */
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = (T)FindObjectOfType(typeof(T));
				if (instance == null)
				{
					Debug.Log("An instance of " + typeof(T) +
					          " is needed in the scene, but there is none.");
				}
			}
			return instance;
		}
	}
	//シングルトンオブジェクトはAwakeでonAwakeを呼ぶ
	//もし継承先でAwakeを使いたい場合はonAwake()をオーバーライドしbase.onAwake()する
	void Awake()
	{
		onAwake();
	}
	public virtual void onAwake()
	{
		if (this != Instance)
		{
			Destroy(this.gameObject);
			return;
		}
		DontDestroyOnLoad(this.gameObject);
		
	}
} 
