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
            UIMenuItem start_recording = new UIMenuItem(Strings.MenuItemStartRecording, Strings.MenuDescriptionStartRecording);
            UIMenuItem stop_recording = new UIMenuItem(Strings.MenuItemStopRecording, Strings.MenuDescriptionStopRecording);
            UIMenuItem discard_recording = new UIMenuItem(Strings.MenuItemDiscardRecording, Strings.MenuDescriptionDiscardRecording);
            recording.AddItem(start_recording);
            recording.AddItem(stop_recording);
            recording.AddItem(discard_recording);
            recording.OnItemSelect += RecordingHandler;
        }

        public void RecordingHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            switch (selectedItem.Text)
            {
                case Strings.MenuItemStartRecording:
                    Function.Call(Hash._START_RECORDING, 1);
                    break;
                case Strings.MenuItemStopRecording:
                    Function.Call(Hash._STOP_RECORDING_AND_SAVE_CLIP);
                    Screen.ShowNotification(Strings.NotificationSaveClip);
                    break;
                case Strings.MenuItemDiscardRecording:
                    Function.Call(Hash._STOP_RECORDING_AND_DISCARD_CLIP);
                    Screen.ShowNotification(Strings.NotificationDiscardClip);
                    break;
            }
        }
    }
}
