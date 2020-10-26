using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap09_MusicStore.Model
{
    public class Music
    {
        public string Name { get; set; }
        public MusicCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }

        public Music(string name, MusicCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = string.Format("/Assets/Audio/{0}/{1}.mp3", category, name);
            ImageFile = string.Format("/Assets/Images/{0}/{1}.jfif", category, name);
        }

        public enum MusicCategory
        {
            VietNam,
            Japan,
            USUK,
            Korean
        }
    }
}
