using UnityEngine;
using System.Collections;
using UnityGameFramework.Runtime;
using Game;
using GameFramework;
using GameFramework.Event;
using GameFramework.DataTable;

public class DataTableExample : MonoBehaviour
{

	void Start ()
	{
		StartCoroutine (GetDataTableComponent());
	}

	IEnumerator GetDataTableComponent ()
	{
		yield return null;
		if (GameEntry.GetComponent<DataTableComponent> () == null)
			yield return null;
		RunDataTableExample ();
	}

	private void RunDataTableExample()
	{
		EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
		// 订阅加载数据表相关的事件
		eventComponent.Subscribe(UnityGameFramework.Runtime.LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
		eventComponent.Subscribe(UnityGameFramework.Runtime.LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);

		DataTableComponent dataTableComponent = GameEntry.GetComponent<DataTableComponent>();
		dataTableComponent.LoadDataTable<DRScene>("Scene", "Assets/DataTables/Scene.txt");
		// 注意：不要在这里直接使用刚刚请求加载的数据表，由于资源加载是异步的，所以要在收到加载数据表成功事件后才能使用
	}

	private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
	{
		// 数据表加载成功事件
		UnityGameFramework.Runtime.LoadDataTableSuccessEventArgs ne = e as UnityGameFramework.Runtime.LoadDataTableSuccessEventArgs;
		Log.Info("Load data table '{0}' success.", ne.DataTableName);

		// 这里已经可以安全地使用数据表了
		DataTableComponent dataTableComponent = GameEntry.GetComponent<DataTableComponent>();
		// 获得数据表
		IDataTable<DRScene> dtScene = dataTableComponent.GetDataTable<DRScene>();
		// 获得所有行
		DRScene[] drScenes = dtScene.GetAllDataRows();
		// 根据行号获得某一行
		DRScene drScene = dtScene.GetDataRow(1); // 或直接使用 dtScene[1]
		if (drScene != null)
		{
			// 此行存在，可以获取内容了
			string name = drScene.Name;
			string assetName = drScene.AssetName;
			int backgroundMusicId = drScene.BackgroundMusicId;
		}
		else
		{
			// 此行不存在
		}

		// 获得满足条件的所有行
		DRScene[] drScenesWithCondition = dtScene.GetAllDataRows(x => x.BackgroundMusicId > 0);
		// 获得满足条件的第一行
		DRScene drSceneWithCondition = dtScene.GetDataRow(x => x.Name == "Main");
	}

	private void OnLoadDataTableFailure(object sender, GameEventArgs e)
	{
		// 数据表加载失败事件
		UnityGameFramework.Runtime.LoadDataTableFailureEventArgs ne = e as UnityGameFramework.Runtime.LoadDataTableFailureEventArgs;
		Log.Warning("Load data table '{0}' failure.", ne.DataTableName);
	}
}
