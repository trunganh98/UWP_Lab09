using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lap09_MusicStore.Model.Music;

namespace Lap09_MusicStore.Model
{
    public class MenuItem
    {
        public string IconFile { get; set; }

        public MusicCategory Category { get; set; }
    }
}
