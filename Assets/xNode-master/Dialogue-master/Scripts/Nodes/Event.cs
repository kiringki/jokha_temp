using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
namespace Dialogue {
	[NodeTint("#FFFFAA")]
	public class Event : DialogueBaseNode {

		public SerializableEvent[] trigger; // Could use UnityEvent here, but UnityEvent has a bug that prevents it from serializing correctly on custom EditorWindows. So i implemented my own.

		public override void Trigger() {
			for (int i = 0; i < trigger.Length; i++) {
				trigger[i].Invoke();
			}

            NodePort port = GetOutputPort("output");
            if (!port.IsConnected) { Debug.Log("!port.isconnected event"); }
            if (port == null) return;

            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as DialogueBaseNode).Trigger();
            }
        }
	}
}