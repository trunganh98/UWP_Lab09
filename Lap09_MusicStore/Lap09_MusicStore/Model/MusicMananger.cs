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
            var musics = new List<Music>();

            musics.Add(new Music("BacPhan", MusicCategory.VietNam));
            musics.Add(new Music("YeuLaiTuDau", MusicCategory.VietNam));

            musics.Add(new Music("BeTheOne", MusicCategory.Japan));
            musics.Add(new Music("MasayumeChasing", MusicCategory.Japan));

            musics.Add(new Music("EverythingINeed", MusicCategory.USUK));
            musics.Add(new Music("Numb", MusicCategory.USUK));

            musics.Add(new Music("AsIfIt_sYourLast", MusicCategory.Korean));
            musics.Add(new Music("BecauseI'mStupid", MusicCategory.Korean));

            return musics;
        }
    }
}
