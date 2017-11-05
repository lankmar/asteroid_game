using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstroGame
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// обработка нажатия кнопки Старт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// обработка нажатия клопки Выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitGame_Click(object sender, EventArgs e)
        {
            Program.flag = false;
            Close();
        }

        /// <summary>
        /// обработка нажатия кнопки Информация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtrInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show( $"Автор: Розанова Надежда \nВерсия: 1.0");
        }
    }
}
