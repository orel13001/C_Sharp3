using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;


namespace LibControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    [ContentProperty()]
    public partial class PrevNextButton : UserControl
    {
        #region Регистрация свойств зависимости

        public static readonly DependencyProperty PrevBtnNameProperty = DependencyProperty.Register("PrevBtnName", typeof(string), typeof(PrevNextButton));
        public static readonly DependencyProperty NextBtnNameProperty = DependencyProperty.Register("NextBtnName", typeof(string), typeof(PrevNextButton));
        #endregion

        #region Регистрация маршрутизируемых событий
        public static readonly RoutedEvent PrevBtnClickEvent = EventManager.RegisterRoutedEvent("PrevBtnClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PrevNextButton));
        public static readonly RoutedEvent NextBtnClickEvent = EventManager.RegisterRoutedEvent("NextBtnClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PrevNextButton));
        #endregion

        #region Свойства Контрола
        /// <summary>
        /// Свойство наименования кнопки Назад
        /// </summary>
        public string PrevBtnName
        {
            get => GetValue(PrevBtnNameProperty).ToString();
            set => SetValue(PrevBtnNameProperty, value);
        }
        /// <summary>
        /// Свойство наименования кнопки Вперёд
        /// </summary>
        public string NextBtnName
        {
            get => GetValue(NextBtnNameProperty).ToString();
            set => SetValue(NextBtnNameProperty, value);
        }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PrevNextButton()
        {
            InitializeComponent();
        }

        #endregion

        #region Маршрутизируемые события

        public event RoutedEventHandler PrevBtnClick
        {
            add { this.AddHandler(PrevBtnClickEvent, value); }
            remove { this.RemoveHandler(PrevBtnClickEvent, value); }
        }
        public event RoutedEventHandler NextBtnClick
        {
            add { this.AddHandler(NextBtnClickEvent, value); }
            remove { this.RemoveHandler(NextBtnClickEvent, value); }
        }
        #endregion

        /// <summary>
        /// Геренация исключения при попытке изменить контент контрола
        /// </summary>
        /// <param name="oldContent"></param>
        /// <param name="newContent"></param>
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (oldContent != null)
            {
                throw new InvalidOperationException("You can't change Content!");
            }
        }



        #region Методы обработчиков событий
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            //e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(PrevBtnClickEvent);
            RaiseEvent(args);// маршрутизация события к "верхнему" элементу
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(NextBtnClickEvent);
            RaiseEvent(args);
        } 
        #endregion
    }
}