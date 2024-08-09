using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    private static Managers Instance { get { Init(); return s_instance; } }

	#region Contents
	private GameManager _game = new GameManager();
	public static GameManager Game { get { return Instance?._game; } }
    #endregion

    #region Core
    private SoundManager _sound = new SoundManager();
	private ResourceManager _resource = new ResourceManager();
	//private UIManager _uiManager = new UIManager;
	//private DataManager _dataManager = new DataManager;
	public static ResourceManager Resource { get { return Instance?._resource; } }
	public static SoundManager Sound { get { return Instance?._sound; } }
	#endregion
	public static void Init()
	{
		if (s_instance == null)
		{
			GameObject go = GameObject.Find("@Managers");
			if (go == null)
			{
				go = new GameObject { name = "@Managers" };
				go.AddComponent<Managers>();
			}

			DontDestroyOnLoad(go);

			// √ ±‚»≠
			s_instance = go.GetComponent<Managers>();
		}
	}
}
