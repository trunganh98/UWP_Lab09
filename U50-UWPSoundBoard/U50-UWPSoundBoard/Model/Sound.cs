using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Audio;
using Windows.UI.Xaml.Controls;

namespace U50_UWPSoundBoard.Model
{
    public class Sound
    {
        public String Name { get; set; }
        public SoundCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }       

        public Sound(string name, SoundCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = string.Format("/Assets/Audio/{0}/{1}.way", category, name);
            ImageFile = string.Format("/Assets/Images/{0}/{1}.png", category, name);
        }

    }

    public enum SoundCategory
    {
        Animals,
        Cartoons,
        Taunts,
        Warnings
    } 

}
