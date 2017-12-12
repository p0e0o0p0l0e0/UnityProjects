using GameFramework.DataTable;
using System.Collections.Generic;

namespace Game
{
	/// <summary>
	/// 场景配置表。
	/// </summary>
	public class DRScene : IDataRow
	{
		/// <summary>
		/// 场景编号。
		/// </summary>
		public int Id
		{
			get;
			protected set;
		}

		/// <summary>
		/// 场景名称。
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// 资源名称。
		/// </summary>
		public string AssetName
		{
			get;
			private set;
		}

		/// <summary>
		/// 背景音乐编号。
		/// </summary>
		public int BackgroundMusicId
		{
			get;
			private set;
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = dataRowText.Split('\t');
			int index = 0;
			index++; // 跳过注释列
			Id = int.Parse(text[index++]);
			index++; // 跳过备注列
			Name = text[index++];
			AssetName = text[index++];
			BackgroundMusicId = int.Parse(text[index++]);
		}

		private void AvoidJIT()
		{
			// 避免 iOS 系统产生 JIT 异常
			new Dictionary<int, DRScene>();
		}
	}
}