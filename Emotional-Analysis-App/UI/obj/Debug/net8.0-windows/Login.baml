   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       UI.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   S OHandyControl, Version=3.5.1.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   localclr-namespace:UI  5   	   -   5        $��loginWindow��5
   k     � Title$  Login��6	   $	��300��6   $	��500��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6U    � Icon$ /img/love.png��6~   .��5      � ��5   
   �� 5       �� ImageSource$ img/login.png��6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��31* �6   �� 5      $	��91* �6   .+�5   
   �� $��username��6   $
��Left=�6#   $��	71,54,0,0q�6>   $	��Top=�6Q   $��2��6i   $��1��6}   ��5      #�5      Bold"�6#   5      �� 5   
   $��password��6   $
��Left=�6#   $��
71,127,0,0q�6>   $	��Top=�6R   $��2��6j   $��1��6~   ��5      #�5      Bold"�6#   5      #  HandyControl.Controls.TextBox  5   
   -   5        $��usernameBox��5      $
��Left=�6(   $��	53,54,0,0q�6C    �� TextWrapping$
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��158��6�   $��2��6�   
�������6�   '  !HandyControl.Controls.PasswordBox  5    
   -   5        $��passwordBox��5       $
��Left=�6,   $��
53,127,0,0q�6G   $	��Top=�6[   $	��158��6s   $��2��6   
�������6�   )  #MahApps.Metro.Controls.ToggleSwitch  5!   
   -   5        $��registSwitch��5!      $��50��6/   $��Register��6;   $��164,181,0,0q�6M   $	��Top=�6b   $��89��6z   $��2��6�   �� 5"   
   -   5        $��Login��5"      $
��Left=�6!   $��
78,204,0,0q�6<   $	��Top=�6P   $��1��6   ��5#      �� 5$       �� 
TargetType" ��6   .�5%      ��  �� Property � ��	 �� Value
	 ��ح�63   �� 5&       � ��
	 �����63   �� 5'       � ��
	 ���� 64   �� 5(       � ��$	 0q�68   �� 5)       � ��$	 10q�60   �� 5*       � ��$	 14(�61   �� 5+       � ��$
	 Bold"�63   �� 5,       �@�Cursor$
	 Hand��6/   �� 5-       � ��	 5.      �� 5/      
 �� 
TargetType"
 ��6.   .R�50   "   �� #��z��6)   #��z��6S   #��z��6    �� CornerRadius$ 5��6�   ._�51   &   �� $��Center=�67   $��Center=�6T   52   #   53      55       �� Triggers 56      P� 57       P� Property �@J�IsMouseOver P� Value$
 True��69   . �58      ��  � ��
	 ����6;   59      P� 5:       � ��$
 True��67   . �5;      ��  � ��
	 ��iA�6;   5<      5>      5@      5A      5B      