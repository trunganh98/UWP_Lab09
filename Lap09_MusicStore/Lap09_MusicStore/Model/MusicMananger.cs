using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lap09_MusicStore.Model.Music;

namespace Lap09_MusicStore.Model
{
    public class MusicMananger
    {
        public static void GetAllMusics(ObservableCollection<Music> musics)
        {
            var allMusics = getMusics();
            musics.Clear();
            allMusics.ForEach(p => musics.Add(p));
        }

        public static void GetMusicsByCategory(ObservableCollection<Music> musics, MusicCategory musicCategory)
        {
            var allMusics = getMusics();
            var filtereMusics = allMusics.Where(p => p.Category == musicCategory).ToList();
            musics.Clear();
            filtereMusics.ForEach(p => musics.Add(p));
        }

        public static void GetMusicsByName(ObservableCollection<Music> musics, string name)
        {
            var allMusics = getMusics();
            var filtereSounds = allMusics.Where(p => p.Name == name).ToList();
            musics.Clear();
            filtereSounds.ForEach(p => musics.Add(p));
        }

        private static List<Music> getMusics()
        {
            var sounds = new List<Music>();

            sounds.Add(new Music("Cow", MusicCategory.VietNam));
            sounds.Add(new Music("Cat", MusicCategory.VietNam));

            sounds.Add(new Music("Gun", MusicCategory.Japan));
            sounds.Add(new Music("Spring", MusicCategory.Japan));

            sounds.Add(new Music("Clock", MusicCategory.USUK));
            sounds.Add(new Music("LOL", MusicCategory.USUK));

            sounds.Add(new Music("Ship", MusicCategory.Korean));
            sounds.Add(new Music("Siren", MusicCategory.Korean));

            return sounds;
        }
    }
}
