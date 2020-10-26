using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Lap09_MusicStore.Model;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lap09_MusicStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<Music> Musics;
        //private List<String> Suggestions;
        private List<MenuItem> MenuItems;

        public MainPage()
        {
            this.InitializeComponent();
            Musics = new ObservableCollection<Music>();
            MusicMananger.GetAllMusics(Musics);
            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/animals.png", Category = Music.MusicCategory.VietNam });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/cartoon.png", Category = Music.MusicCategory.Japan });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/taunt.png", Category = Music.MusicCategory.USUK });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/warning.png", Category = Music.MusicCategory.Japan });
        }

        private void goBack()
        {
            MusicMananger.GetAllMusics(Musics);
            CategoryTextBlock.Text = "All  Music";
            MenuItemListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (String.IsNullOrEmpty(sender.Text)) goBack();
        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            MusicMananger.GetMusicsByName(Musics, sender.Text);
            CategoryTextBlock.Text = sender.Text;
            MenuItemListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Visible;
        }

        private void MenuItemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;

            CategoryTextBlock.Text = menuItem.Category.ToString();
            MusicMananger.GetMusicsByCategory(Musics, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;
        }

        private async void SoundGridView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();

                if (items.Any())
                {
                    var stoageFile = items[0] as StorageFile;
                    var contentType = stoageFile.ContentType;

                    StorageFolder folder = ApplicationData.Current.LocalFolder;

                    if (contentType == "audio/mp3" || contentType == "audio/mpeg")
                    {
                        StorageFile newFile = await stoageFile.CopyAsync(folder, stoageFile.Name,
                            NameCollisionOption.GenerateUniqueName);
                        MyMediaElement.SetSource(await stoageFile.OpenAsync(FileAccessMode.Read), contentType);
                        MyMediaElement.Play();
                    }
                }
            }
        }

        private void SoundGridView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;

            e.DragUIOverride.Caption = "drop to create a custom sound and title";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var music = (Music)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, music.AudioFile);
        }
    }
}
