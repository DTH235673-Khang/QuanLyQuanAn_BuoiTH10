using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Forms
{
   
    public static class SystemSettings
    {
        public static System.Drawing.Font CurrentFont = new System.Drawing.Font("Segoe UI", 9); // Font mặc định
        public static System.Drawing.Color CurrentColor = System.Drawing.Color.Black;        // Màu mặc định

        // Sự kiện để thông báo cho các Form đang mở biết rằng Font đã đổi
        public static event Action OnSettingsChanged;

        public static void UpdateSettings(System.Drawing.Font newFont, System.Drawing.Color newColor)
        {
            CurrentFont = newFont;
            CurrentColor = newColor;
            // Kích hoạt sự kiện
            OnSettingsChanged?.Invoke();
        }
    }
    public static class FontHelper
    {
        public static void ApplyFont(System.Windows.Forms.Control parent, System.Drawing.Font font, System.Drawing.Color color)
        {
            parent.Font = font;
            parent.ForeColor = color;

            foreach (System.Windows.Forms.Control c in parent.Controls)
            {
                if (c is MenuStrip ms)
                {
                    ApplyMenuStripFont(ms, font, color);
                }
                ApplyFont(c, font, color);
            }
        }

        private static void ApplyMenuStripFont(MenuStrip ms, System.Drawing.Font font, System.Drawing.Color color)
        {
            ms.Font = font;
            ms.ForeColor = color;
            foreach (ToolStripItem item in ms.Items)
            {
                ApplyToolStripItem(item, font, color);
            }
        }

        private static void ApplyToolStripItem(ToolStripItem item, System.Drawing.Font font, System.Drawing.Color color)
        {
            item.Font = font;
            item.ForeColor = color;
            if (item is ToolStripMenuItem menuItem)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    ApplyToolStripItem(subItem, font, color);
                }
            }
        }
    }
    public class BaseForm : Form
    {
        public BaseForm()
        {
            // Khi Form được tạo, đăng ký nhận sự kiện đổi Font
            SystemSettings.OnSettingsChanged += UpdateUI;
            this.Load += (s, e) => UpdateUI();
        }

        private void UpdateUI()
        {
            FontHelper.ApplyFont(this, SystemSettings.CurrentFont, SystemSettings.CurrentColor);
        }

        // Quan trọng: Hủy đăng ký khi Form đóng để tránh rò rỉ bộ nhớ
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SystemSettings.OnSettingsChanged -= UpdateUI;
            base.OnFormClosed(e);
        }

    }

}
