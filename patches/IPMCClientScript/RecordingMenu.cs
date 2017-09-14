using NativeUI;
using CitizenFX.Core.UI;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace Client
{
    class RecordingMenu
    {
        private MenuPool pool;
        private UIMenu parent;
        private UIMenu recording;

        public RecordingMenu(MenuPool pool, UIMenu parent)
        {
            this.pool = pool;
            this.parent = parent;
            AddRecordingMenu();
        }

        private void AddRecordingMenu()
        {
            recording = pool.AddSubMenu(parent, Strings.MenuTitle.Recording, Strings.MenuDescriptionRecording);
            UIMenuItem start_recording = new UIMenuItem(Strings.MenuItem.StartRecording, Strings.MenuDescriptionStartRecording);
            UIMenuItem stop_recording = new UIMenuItem(Strings.MenuItem.StopRecording, Strings.MenuDescriptionStopRecording);
            UIMenuItem discard_recording = new UIMenuItem(Strings.MenuItem.DiscardRecording, Strings.MenuDescriptionDiscardRecording);
            recording.AddItem(start_recording);
            recording.AddItem(stop_recording);
            recording.AddItem(discard_recording);
            recording.OnItemSelect += RecordingHandler;
        }

        public void RecordingHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            switch (selectedItem.Text)
            {
                case Strings.MenuItem.StartRecording:
                    Function.Call(Hash._START_RECORDING, 1);
                    break;
                case Strings.MenuItem.StopRecording:
                    Function.Call(Hash._STOP_RECORDING_AND_SAVE_CLIP);
                    Screen.ShowNotification(Strings.NotificationSaveClip);
                    break;
                case Strings.MenuItem.DiscardRecording:
                    Function.Call(Hash._STOP_RECORDING_AND_DISCARD_CLIP);
                    Screen.ShowNotification(Strings.NotificationDiscardClip);
                    break;
            }
        }
    }
}
