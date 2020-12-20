using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC
{
    public partial class ucPayslips : UserControl
    {
        UsersRepository _usersRepository = new UsersRepository();
        public ucPayslips()
        {
            InitializeComponent();
        }

        public async Task LoadUserComboboxAsync()
        {
            List<Users> listUser = await _usersRepository.GetList();
            foreach (Users item in listUser)
            {
                cbbUser.Items.Add(item.id + "." + item.fullName);
            }
        }

        private void ucPayslips_Load(object sender, EventArgs e)
        {
            LoadUserComboboxAsync();
        }
    }
}
