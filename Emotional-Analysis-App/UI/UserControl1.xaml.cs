﻿using System;
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

namespace UI
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        //listbox使用参考https://blog.csdn.net/qq_35320456/article/details/137355906
        //将listbox与数据源绑定
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //将用户的历史记录显示到listbox中 
            //并实现选择某一项后显示详细信息
            //不再实时根据textbox的输入进行生成情感
            //通过sumbit按钮点击后生成情感
            //每点击一次就是一次历史记录
        }

    }
}
