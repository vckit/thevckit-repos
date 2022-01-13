using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.Context;
using WpfApp2.Model;

namespace WpfApp2.Views.Pages
{
    /// <summary>
    /// Interaction logic for ActionPage.xaml
    /// </summary>
    public partial class ActionPage : Page
    {
        public string Phone { get; set; }
        public ATC ATC { get; set; }
        public Abonent Abonent { get; set; }
        public Sim Sim { get; set; }
        public SimATCAbonent SimATCAbonent { get; set; }
        public List<City> Citys { get; set; }
        public List<CityDisctict> Disctricts { get; set; }
        public ActionPage(ATC atc, Abonent abonent, Sim sim, SimATCAbonent simatcabonent)
        {
            InitializeComponent(); ;
            Disctricts = AppData.db.CityDisctict.ToList();
            ATC = atc;
            Sim = sim;
            Abonent = abonent;
            SimATCAbonent = simatcabonent;
            this.DataContext = this;

        }
        
        // Ограничиваем ввод данных только цифрами и запятой
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "01234567890,".IndexOf(e.Text) < 0;
        }

        // Сохраняем данные в базу данных
        private void ButtonSaveData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Abonent.ID == 0 && Sim.ID == 0 && SimATCAbonent.ID == 0)
                {
                    if (AppData.db.ATC.Count(item => item.Code == ATC.Code) > 0)
                    {
                        MessageBox.Show($"АТС С КОДОМ {ATC.Code} УЖЕ СУЩЕСТВУЕТ В БАЗЕ ДАННЫХ!",
                            "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        AppData.db.ATC.Add(ATC);
                        Phone = cmbCode.Text + Abonent.Phone;
                        Abonent.Phone = Phone;
                        AppData.db.Abonent.Add(Abonent);
                        AppData.db.Sim.Add(Sim);
                        SimATCAbonent.IDATC = ATC.Code;
                        AppData.db.SimATCAbonent.Add(SimATCAbonent);
                    }
                }
                Abonent.Phone = Phone;
                AppData.db.SaveChanges();
                MessageBox.Show("ДАННЫЕ УСПЕШНО СОХРАНЕНЫ В БАЗЕ ДАННЫХ.", "СОХРАНЕНО", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так :(. Текст сообщения: '{ex.Message.ToLower()}'", "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
