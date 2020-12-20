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
    public partial class ucAttendances : UserControl
    {
        UsersRepository _usersRepository = new UsersRepository();
        ShiftsRepository _shiftsRepository = new ShiftsRepository();

        public ucAttendances()
        {
            InitializeComponent();
        }

        private void ucAttendances_Load(object sender, EventArgs e)
        {
            LoadUserComboboxAsync();
            LoadShiftComboBoxAsysnc();
        }

        public async Task LoadShiftComboBoxAsysnc()
        {
            List<Shifts> listShift = await _shiftsRepository.GetList();
            foreach (Shifts item in listShift)
            {
                cbbShift.Items.Add(item.id+"."+item.shiftName);
            }
        }

        public async Task LoadUserComboboxAsync()
        {
            List<Users> listUser = await _usersRepository.GetList();
            foreach (Users item in listUser)
            {
                cbbUser.Items.Add(item.id+"."+item.fullName);
            }
        }
    }
}
