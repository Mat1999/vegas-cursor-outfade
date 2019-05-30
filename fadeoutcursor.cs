using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

using ScriptPortal.Vegas;

//Made using Tea lover's tutorials and sharpdevelop

namespace fadeoutcursor
{
	public class EntryPoint{
		
		public void FromVegas(Vegas myVegas){//the main method
			try{
				TrackEvent[] selEvent = GetSelectedEvents(myVegas.Project);//gets the currently selected events
				Timecode cursorpos = myVegas.Transport.CursorPosition;//gets the cursor's position
				foreach (TrackEvent selected in selEvent) {//for every selected event
					selected.FadeOut.Length = selected.End - cursorpos;//sets the right(out) fade's start to the cursor's position
				}
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message);//if there is an error a message pops up
			}
		}
		
		TrackEvent[] GetSelectedEvents(Project myProject){//gets the selected events and gives them back in an array (for deeper explanation check out the vegas-cursor-infade repo or Tea lover's tutorials)
			List<TrackEvent> selected = new List<TrackEvent>();
			foreach (Track tracks in myProject.Tracks) {
				foreach (TrackEvent myEvent in tracks.Events) {
					if (myEvent.Selected){
						selected.Add(myEvent);
					}
				}
			}
			return selected.ToArray();
		}
	}
}