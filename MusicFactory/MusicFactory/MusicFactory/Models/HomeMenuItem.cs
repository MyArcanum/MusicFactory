using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFactory.Models
{
    public enum MenuItemType
    {
        //Browse,
        Drums,
        Piano,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
