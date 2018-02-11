namespace Client
{
    using CitizenFX.Core.Native;
    using CitizenFX.Core.UI;
    using NativeUI;

    public class RecordingMenu
    {
        private MenuPool pool;
        private UIMenu parent;
        private UIMenu recording;

        public RecordingMenu(MenuPool pool, UIMenu parent)
        {
            this.pool = pool;
            this.parent = parent;
            this.AddRecordingMenu();
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
                    Screen.ShowNotification(Strings.Notification.SaveClip);
                    break;
                case Strings.MenuItem.DiscardRecording:
                    Function.Call(Hash._STOP_RECORDING_AND_DISCARD_CLIP);
                    Screen.ShowNotification(Strings.Notification.DiscardClip);
                    break;
            }
        }

        private void AddRecordingMenu()
        {
            this.recording = this.pool.AddSubMenu(this.parent, Strings.MenuTitle.Recording, Strings.MenuDescription.Recording);
            UIMenuItem start_recording = new UIMenuItem(Strings.MenuItem.StartRecording, Strings.MenuDescription.StartRecording);
            UIMenuItem stop_recording = new UIMenuItem(Strings.MenuItem.StopRecording, Strings.MenuDescription.StopRecording);
            UIMenuItem discard_recording = new UIMenuItem(Strings.MenuItem.DiscardRecording, Strings.MenuDescription.DiscardRecording);
            this.recording.AddItem(start_recording);
            this.recording.AddItem(stop_recording);
            this.recording.AddItem(discard_recording);
            this.recording.OnItemSelect += this.RecordingHandler;
        }
    }
}
