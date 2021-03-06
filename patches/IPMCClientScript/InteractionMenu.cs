﻿namespace Client
{
    using System.Collections.Generic;
    using System.Linq;
    using CitizenFX.Core;
    using CitizenFX.Core.Native;
    using CitizenFX.Core.UI;
    using NativeUI;

    public class InteractionMenu
    {
        private Player player;
        private MenuPool menus;
        private UIMenu interactionMenu;

        public InteractionMenu(Player p)
        {
            this.menus = new MenuPool();
            this.AddInteractionMenu();
            this.player = p;
        }

        // Wrapper so it can easily be used in IPMCScript.cs
        public void ProcessMenus()
        {
            this.menus.ProcessMenus();
        }

        // TODO: A function which just does it for every menu will be created
        // eventually
        public void ToggleInteractionMenu()
        {
            this.interactionMenu.Visible = !this.interactionMenu.Visible;
        }

        public void ItemHandler(
            UIMenu sender, UIMenuItem selectedItem, int index)
        {
            switch (selectedItem.Text)
            {
                case Strings.MenuItem.DefaultClothes:
                    this.DefaultClothes();
                    break;
                case Strings.MenuItem.LeaveSession:
                    this.LeaveSession();
                    break;
                default:
                    break;
            }
        }

        public void DefaultClothes()
        {
            int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
            CitizenFX.Core.Ped ped = new CitizenFX.Core.Ped(player_ped_hash);
            ped.Style.SetDefaultClothes();
        }

        public void LeaveSession()
        {
            Function.Call(Hash.NETWORK_SESSION_LEAVE_SINGLE_PLAYER);
            Screen.ShowNotification(Strings.Notification.LeaveSession);
        }

        private void AddInteractionMenu()
        {
            this.interactionMenu = new UIMenu(
                Strings.MenuTitle.Interaction, 
                Strings.MenuSubtitle.Interaction);
            this.menus.Add(this.interactionMenu);
            this.AddInteractionMenuItems();

            this.interactionMenu.RefreshIndex();
            this.interactionMenu.MouseEdgeEnabled = false; // might be a fix for the rotating camera bug
        }

        private void AddInteractionMenuItems()
        {
            PatchesMenu patches_menu = new PatchesMenu(
                this.menus, this.interactionMenu);

            // default clothes menu is just for WIP
            UIMenuItem default_clothes =
                new UIMenuItem(Strings.MenuItem.DefaultClothes);
            this.interactionMenu.AddItem(default_clothes);

            UIMenu character_creator = this.menus.AddSubMenu(this.interactionMenu, "Character Creator");
            List<dynamic> shapes1 = new List<dynamic>();
            shapes1.AddRange(Enumerable.Range(1, 47).Cast<dynamic>().ToList());
            character_creator.AddItem(new UIMenuListItem("Shape 1",shapes1,0));
            character_creator.OnListChange += ListHandler;

            RecordingMenu recording_menu =
                new RecordingMenu(this.menus, this.interactionMenu);

            UIMenuItem leave_session =
                new UIMenuItem(Strings.MenuItem.LeaveSession);
            this.interactionMenu.AddItem(leave_session);

            this.interactionMenu.OnItemSelect += this.ItemHandler;
        }

        private void ListHandler(UIMenu sender, UIMenuListItem selectedItem, int index)
        {
            if(selectedItem.Text == "Shape 1")
            {
                int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
                Function.Call(Hash.SET_PED_HEAD_BLEND_DATA,player_ped_hash,index,0,0,0,0,0,0,0,0,0);
            }
        }
    }
}
