using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using static U50_UWPSoundBoard.Model.Sound;

namespace U50_UWPSoundBoard.Model
{
    public class MenuItem
    {
        public string IconFile { get; set; }
        public SoundCategory Category { get; set; }
    }

}
