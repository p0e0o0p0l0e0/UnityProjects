using UnityEngine;
using System.Collections;
using GameFramework.Event;
using UnityGameFramework.Runtime;
using GameFramework;

namespace UnityGameFramework
{
	public class EventExample : MonoBehaviour
	{
		void Start()
		{
			RunEventExample ();
		}

		private void RunEventExample()
		{
			EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
			eventComponent.Subscribe(PlayerHPChangedEventArgs.EventId, OnPlayerHPChanged);
			eventComponent.Fire(this, new PlayerHPChangedEventArgs(1000));
		}

		private void OnPlayerHPChanged(object sender, GameEventArgs e)
		{
			PlayerHPChangedEventArgs ne = e as PlayerHPChangedEventArgs;
			Log.Info("New HP is '{0}'.", ne.NewHP.ToString());
		}
	}
}