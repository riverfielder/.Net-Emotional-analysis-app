   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       UI.Register   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   S OHandyControl, Version=3.5.1.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   -   5        $��registerWindow��5
   �     � Title$  Register��6	   $	��400��6   $	��500��6'    � WindowStartupLocation$ CenterScreen=�63    � 
ResizeMode$ NoResize=�6X    � Icon$ /img/studyhard.png��6�   .��5      � ��5   
   �� 5       �� ImageSource$ img/regist.png��6   .+�5   
   #  HandyControl.Controls.TextBox  -   5        $��usernameBox��5      $
��Left=�6(   $��
250,63,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��147��6�   
�������6�     5   
   -   5        $��passwordBox��5      $
��Left=�6)   $��250,150,0,0q�6D   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��147��6�   
�������6�   �� 5   
   $��username��6   $
��Left=�6#   $��
114,64,0,0q�6>   $	��Top=�6R   ��5      #�5      Bold"�6#   5      �� 5   
   $��password��6   $
��Left=�6#   $��114,153,0,0q�6>   $	��Top=�6S   ��5      #�5      Bold"�6#   5      �� 5   
   $��password again��6   $
��Left=�6)   $��114,234,0,0q�6D   $	��Top=�6Y   ��5      #�5      Bold"�6#   5       �� 5!   
   -   5        $��regist��5!      $��Center=�6"   $��	0,325,0,0q�6?   $	��Top=�6R   $��66��6j   ��5"      �� 5#       �� 
TargetType" ��6   .�5$      ��  �� Property � �� �� Value
 ��ح�63   �� 5%       � ��
 �����63   �� 5&       � ��
 ���� 64   �� 5'       � ��$ 0q�68   �� 5(       � ��$ 10q�60   �� 5)       � ��$ 14(�61   �� 5*       � ��$
 Bold"�63   �� 5+       �@�Cursor$
 Hand��6/   �� 5,       � �� 5-      �� 5.      	 �� 
TargetType"	 ��6.   .R�5/   "   �� #��z��6)   #��z��6S   #��z��6   
 �� CornerRadius$
 5��6�   ._�50   &   �� $��Center=�67   $��Center=�6T   51   #   52      54       �� Triggers 55      P� 56       P� Property �@J�IsMouseOver P� Value$
 True��69   . �57      ��  � ��
 ����6;   58      P� 59       � ��$
 True��67   . �5:      ��  � ��
 ��iA�6;   5;      5=      5?      '  !HandyControl.Controls.PasswordBox  5@   
   -   5          Name$ repeatpasswordBox��5@      $
��Left=�64   $��250,234,0,0q�6O   $	��Top=�6d   $	��147��6|   
�������6�   5B      5C      