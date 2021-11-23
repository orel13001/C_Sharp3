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
        #region ����������� ������� �����������

        public static readonly DependencyProperty PrevBtnNameProperty = DependencyProperty.Register("PrevBtnName", typeof(string), typeof(PrevNextButton));
        public static readonly DependencyProperty NextBtnNameProperty = DependencyProperty.Register("NextBtnName", typeof(string), typeof(PrevNextButton));
        #endregion

        #region ����������� ���������������� �������
        public static readonly RoutedEvent PrevBtnClickEvent = EventManager.RegisterRoutedEvent("PrevBtnClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PrevNextButton));
        public static readonly RoutedEvent NextBtnClickEvent = EventManager.RegisterRoutedEvent("NextBtnClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PrevNextButton));
        #endregion

        #region �������� ��������
        /// <summary>
        /// �������� ������������ ������ �����
        /// </summary>
        public string PrevBtnName
        {
            get => GetValue(PrevBtnNameProperty).ToString();
            set => SetValue(PrevBtnNameProperty, value);
        }
        /// <summary>
        /// �������� ������������ ������ �����
        /// </summary>
        public string NextBtnName
        {
            get => GetValue(NextBtnNameProperty).ToString();
            set => SetValue(NextBtnNameProperty, value);
        }

        #endregion

        #region ������������
        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        public PrevNextButton()
        {
            InitializeComponent();
        }

        #endregion

        #region ���������������� �������

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
        /// ��������� ���������� ��� ������� �������� ������� ��������
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



        #region ������ ������������ �������
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            //e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(PrevBtnClickEvent);
            RaiseEvent(args);// ������������� ������� � "��������" ��������
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