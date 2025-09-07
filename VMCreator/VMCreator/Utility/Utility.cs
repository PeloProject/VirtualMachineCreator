using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMCreator.Utility
{
    internal class Utility
    {
        static public void AddContextMenuItem(ContextMenuStrip contextMenu, string itemName, EventHandler onClickEvent)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(itemName);
            menuItem.Click += onClickEvent;
            contextMenu.Items.Add(menuItem);
        }
    }
}
