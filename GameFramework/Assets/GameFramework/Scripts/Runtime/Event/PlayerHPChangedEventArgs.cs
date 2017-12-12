/// <summary>
/// 玩家生命值改变事件。
/// </summary>

using GameFramework.Event;

namespace UnityGameFramework.Runtime
{
	public class PlayerHPChangedEventArgs : GameEventArgs
	{
		/// <summary>
		/// 初始化玩家生命值改变事件的新实例。
		/// </summary>
		/// <param name="newHP">玩家新的生命值。</param>
		public PlayerHPChangedEventArgs(int newHP)
		{
			NewHP = newHP;
		}

		/// <summary>
		/// 获取玩家生命值改变事件编号。
		/// </summary>
		public override int Id
		{
			get
			{
				return EventId;
			}
		}

		public static readonly int EventId = typeof(PlayerHPChangedEventArgs).GetHashCode();

		/// <summary>
		/// 玩家新的生命值。
		/// </summary>
		public int NewHP
		{
			get;
			private set;
		}

		/// <summary>
		/// 清理下载成功事件。
		/// </summary>
		public override void Clear()
		{
			NewHP = 0;
		}
	}
}