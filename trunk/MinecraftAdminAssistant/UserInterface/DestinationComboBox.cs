using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MinecraftAssistant.Data;
using System.Drawing;

namespace MinecraftAssistant.UserInterface {
    public class DestinationComboBox: ComboBox {
        public DestinationComboBox() {
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += new DrawItemEventHandler(Draw);
        }

        private void Draw(object sender, DrawItemEventArgs e) {
            if (!DroppedDown) {
                e.Graphics.DrawRectangle(Pens.White, e.Bounds);
            }
            else {
                e.DrawBackground();

                if (e.Index >= 0 && e.Index + 1 < Items.Count && Items[e.Index] is Player && Items[e.Index + 1] is Location) {
                    e.Graphics.DrawLine(Pens.DarkGray, new Point(e.Bounds.Left, e.Bounds.Bottom - 1),
                                        new Point(e.Bounds.Right, e.Bounds.Bottom - 1));
                }
            }

            if (e.Index >= 0) TextRenderer.DrawText(e.Graphics, Items[e.Index].ToString(), Font, e.Bounds, ForeColor, TextFormatFlags.Left);

            e.DrawFocusRectangle();
        }
    }
}
